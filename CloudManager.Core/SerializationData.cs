using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager.Core
{
    public static class SerializationData
    {
        private static BinaryFormatter formatter;
        private static string AlgorithmName = "DES";

        static SerializationData()
        {
            formatter = new BinaryFormatter();
        }
        public static void Serialize(Dictionary<GoogleUserDataModel> usersData)
        {
            SymmetricEncryptionUtility.GenerateKey();
            using (FileStream fs = new FileStream("Data.dat", FileMode.OpenOrCreate))
            {
                using (CryptoStream cs = new CryptoStream(fs, SymmetricEncryptionUtility.GenerateKey().CreateEncryptor(), CryptoStreamMode.Write))
                {
                    formatter.Serialize(fs, usersData);
                }
            }
        }
        public static Dictionary<GoogleUserDataModel> Deserilize()
        {
            Dictionary<GoogleUserDataModel> usersData = new Dictionary<GoogleUserDataModel>();
            using (FileStream fs = new FileStream("Data.dat", FileMode.OpenOrCreate))
            {
                using (CryptoStream cs = new CryptoStream(fs, SymmetricEncryptionUtility.GenerateKey().CreateDecryptor(), CryptoStreamMode.Read))
                {
                    usersData = (Dictionary<GoogleUserDataModel>)formatter.Deserialize(fs);
                }
            }
            return usersData;
        }
    }
}
