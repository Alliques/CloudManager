using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager.Core
{
    public static class GoogleUserData
    {
        public static Dictionary<string, GoogleUserDataModel> KeysDictionary { get; set; }

        static GoogleUserData()
        {
            KeysDictionary = new Dictionary<string, GoogleUserDataModel>();
        }
    }
}
