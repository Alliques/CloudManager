using System;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudManager.Core
{
    public class GoogleAuthorization : GoogleAuthorizationData
    {
        #region Constructor
        public GoogleAuthorization()
        {
            state = RandomDataBase64url(32);
            code_verifier = RandomDataBase64url(32);
            code_challenge = Base64urlencodeNoPadding(Sha256(code_verifier));
            redirectURI = string.Format("http://{0}:{1}/", IPAddress.Loopback, GetRandomUnusedPort());
        }

        #endregion
        /// <summary>
        /// Generating a string, for a authorization code receiving
        /// </summary>
        /// <returns></returns>
        public string AuthorizationCodeRequestString()
        {
            return string.Format(
                "{0}?response_type=code&scope=openid%20profile%20email&redirect_uri={1}&client_id={2}&state={3}&code_challenge={4}&code_challenge_method={5}",
               authorizationEndpoint,
               System.Uri.EscapeDataString(redirectURI),
               clientID,
               state,
               code_challenge,
               code_challenge_method);
        }

        public async void Authorization()
        {
            Notify?.Invoke(AuthorizationCodeRequestString());
            var http = new HttpListener();
            http.Prefixes.Add(redirectURI);
            //output("Listening..");
            http.Start();
            var context = await http.GetContextAsync();
            var response = context.Response;
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>");
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
            });

            if (context.Request.QueryString.Get("error") != null)
            {
                //output(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.Get("error")));
                return;
            }
            if (context.Request.QueryString.Get("code") == null
                || context.Request.QueryString.Get("state") == null)
            {
                //output("Malformed authorization response. " + context.Request.QueryString);
                return;
            }
            var code = context.Request.QueryString.Get("code");
            var incoming_state = context.Request.QueryString.Get("state");

            if (incoming_state != state)
            {
                //output(String.Format("Received request with invalid state ({0})", incoming_state));
                return;
            }
            //output("Authorization code: " + code);

            PerformCodeExchange(code, code_verifier, redirectURI);
        }


        public string output(string output)//test
        {
            output += (output + Environment.NewLine);
            return output;
        }

        /// <summary>
        /// Receiving Acces and refresh tokens
        /// </summary>
        /// <param name="code">Authorization code</param>
        /// <param name="code_verifier"></param>
        /// <param name="redirectURI"></param>
        async void PerformCodeExchange(string code, string code_verifier, string redirectURI)
        {
            string tokenRequestURI = "https://www.googleapis.com/oauth2/v4/token";
            string tokenRequestBody = string.Format("code={0}&redirect_uri={1}&client_id={2}&code_verifier={3}&client_secret={4}&scope=&grant_type=authorization_code",
                code,
                System.Uri.EscapeDataString(redirectURI),
                clientID,
                code_verifier,
                clientSecret
               );

            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(tokenRequestURI);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "application/x-www-form-urlencoded";
            tokenRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            byte[] _byteVersion = Encoding.ASCII.GetBytes(tokenRequestBody);
            tokenRequest.ContentLength = _byteVersion.Length;
            Stream stream = tokenRequest.GetRequestStream();
            await stream.WriteAsync(_byteVersion, 0, _byteVersion.Length);
            stream.Close();

            try
            {
                // gets the response
                WebResponse tokenResponse = await tokenRequest.GetResponseAsync();
                using (StreamReader reader = new StreamReader(tokenResponse.GetResponseStream()))
                {
                    // reads response body
                    string responseText = await reader.ReadToEndAsync();
                    output(responseText);

                    // converts to dictionary
                    Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                    string access_token = tokenEndpointDecoded["access_token"];
                    var userInfo = OneDriveApi.UserinfoCall(access_token) as Dictionary<string,string>;

                   
                    var usersData= SerializationData.VeryfyExistFile();
                    var b = usersData.Exists(x => x.Email != userInfo["email"]);

                    //if account already exist
                    if (!usersData.Exists(x=>x.Email==userInfo["email"]))
                    {
                        usersData.Add(new GoogleUserDataModel
                        {
                            AccessToken = access_token,
                            RefreshToken = tokenEndpointDecoded["refresh_token"],
                            Email = userInfo["email"],
                            PhotoUrl = userInfo["picture"]
                        });
                        SerializationData.Serialize(usersData);
                    }

                    IoC.Get<ApplicationViewModel>().UserDatas = usersData;
                    //close page when token received
                    TokenReceivedEvent?.Invoke();
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        output("HTTP: " + response.StatusCode);
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            // reads response body
                            string responseText = await reader.ReadToEndAsync();
                            output(responseText);
                        }
                    }

                }
            }
        }

        #region Events
        public delegate void UriChanged(string uri);
        public event UriChanged Notify;

        public delegate void TokenReceived();
        public event TokenReceived TokenReceivedEvent; 
        #endregion

       
    }
}
