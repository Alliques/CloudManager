using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthentificationService
{
    public class MicrosoftOauth
    {
        /// <summary>
        /// Client or application id for Microsoft Oauth autentification
        /// </summary>
        public string ClientId { get; } = "e6d2b189-15d4-472f-8ac9-ec6da36fcbed";

        public string Scope { get; set; } 
    }
}
