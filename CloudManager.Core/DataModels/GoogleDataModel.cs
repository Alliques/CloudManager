using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager.Core
{
    public class GoogleUserDataModel
    {
        public string RefreshToken { get; set; }

        public string AccessToken { get; set; }

        public string Email { get; set; }

        public string PhotoUrl { get; set; }
    }
}
