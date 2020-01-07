using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CloudManager
{
    class MailRuService
    {
        public static string LoginProp { get; set; }
        public static string PassProp { get; set; }
        public static string mailRuAuthUrlAdress = "https://connect.mail.ru/oauth/authorize?client_id=756786&response_type=token&redirect_uri=http%3A%2F%2Fconnect.mail.ru%2Foauth%2Fsuccess.html";
        public static string mailRuAuthScript = string.Format("document.getElementById('login').value='{0}';" +
                        "document.getElementById('password').value='{1}'; var link = document.getElementById('login-form');" +
                        "link.submit();;", "airat1100@bk.ru", "3240022156zyitg5e4");


        public static string GetUserInfo(string Url)
        {
            string accesToken = string.Empty;
            if (Url.IndexOf("access_token") != -1)
            {
                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(Url))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        accesToken = m.Groups["value"].Value;
                    }
                }
            }
            return accesToken;
        }
    }
}
