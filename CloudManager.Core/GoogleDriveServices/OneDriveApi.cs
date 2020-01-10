using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager.Core
{ 
    public class OneDriveApi : GoogleAuthorizationData
    {
        private string grant_type= "refresh_token";

        /// <summary>
        /// Refreshing an access token
        /// </summary>
        public void RefreshingToken(string refreshingToken)
        {
            string requestString= string.Format("client_id={0}&client_secret={1}&refresh_token={2}&grant_type=refresh_token",
                clientID,
                clientSecret,
                refreshingToken);
        }

        public static object UserinfoCall(string access_token)
        {
            // builds the  request
            string userinfoRequestURI = "https://www.googleapis.com/oauth2/v3/userinfo";
            string userInfo;
            // sends the request
            HttpWebRequest userinfoRequest = (HttpWebRequest)WebRequest.Create(userinfoRequestURI);
            userinfoRequest.Method = "GET";
            userinfoRequest.Headers.Add(string.Format("Authorization: Bearer {0}", access_token));
            userinfoRequest.ContentType = "application/x-www-form-urlencoded";
            userinfoRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            // gets the response
            WebResponse userinfoResponse = userinfoRequest.GetResponse();
            using (StreamReader userinfoResponseReader = new StreamReader(userinfoResponse.GetResponseStream()))
            {
                // reads response body
                userInfo = userinfoResponseReader.ReadToEnd();
            }
            Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(userInfo);
            
            return tokenEndpointDecoded;
        }
    }
}
