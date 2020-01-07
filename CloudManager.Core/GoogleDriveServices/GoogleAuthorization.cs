using System;
using System.Security.Cryptography;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;

namespace CloudManager.Core.GoogleDriveServices
{
    public static class GoogleAuthorization
    {
        const string clientID = "942014504403-hfafq9qk08i8jdbn4310hmd8jfpncuhe.apps.googleusercontent.com";
        const string clientSecret = "AIzaSyAaUV3f8vlbwyk3mSp-LeMaWPjdXfXoP8g";
        const string authorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        const string code_challenge_method = "S256";

        public static async void AutorizationStart()
        {
            string state = RandomDataBase64url(32);
            string code_verifier = RandomDataBase64url(32);
            string code_challenge = Base64urlencodeNoPadding(Sha256(code_verifier));

            string redirectURI = string.Format("http://{0}:{1}/", IPAddress.Loopback, GetRandomUnusedPort());
            var http = new HttpListener();
            http.Prefixes.Add(redirectURI);
            //output("Listening..");
            http.Start();

            // OAuth 2.0 authorization request.
            string authorizationRequest = string.Format(
                "{0}?response_type=code&scope=openid%20profile&redirect_uri={1}&client_id={2}&state={3}&code_challenge={4}&code_challenge_method={5}",
               authorizationEndpoint,
               System.Uri.EscapeDataString(redirectURI),
               clientID,
               state,
               code_challenge,
               code_challenge_method);


        }

        private static string RandomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return Base64urlencodeNoPadding(bytes);
        }
        private static string Base64urlencodeNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url.
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            base64 = base64.Replace("=", "");

            return base64;
        }
        private static int GetRandomUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
        public static byte[] Sha256(string inputStirng)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputStirng);
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(bytes);
        }
    }
}
