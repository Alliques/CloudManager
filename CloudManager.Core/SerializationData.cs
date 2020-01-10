using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

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
        public static void Serialize(List<GoogleUserDataModel> usersData)
        {
            SymmetricEncryptionUtility.GenerateKey();
            using (FileStream fs = new FileStream(@"D:\Data.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, usersData);
                //using (CryptoStream cs = new CryptoStream(fs, SymmetricEncryptionUtility.GenerateKey().CreateEncryptor(), CryptoStreamMode.Write))
                //{
                //    formatter.Serialize(fs, usersData);
                //}
            }
        }
        public static List<GoogleUserDataModel> Deserilize()
        {
            List<GoogleUserDataModel> usersData = new List<GoogleUserDataModel>();
            using (FileStream fs = new FileStream(@"D:\Data.dat", FileMode.OpenOrCreate))
            {
                usersData = (List<GoogleUserDataModel>)formatter.Deserialize(fs);
                //using (CryptoStream cs = new CryptoStream(fs, SymmetricEncryptionUtility.GenerateKey().CreateDecryptor(), CryptoStreamMode.Read))
                //{
                //    try
                //    {
                //        usersData = (List<GoogleUserDataModel>)formatter.Deserialize(fs);
                //    }
                //    catch(Exception e)
                //    {

                //    }
                //}
            }
            return usersData;
        }

        public static List<GoogleUserDataModel> VeryfyExistFile()
        {
            if (System.IO.File.Exists(@"D:\Data.dat"))
            {
                return Deserilize();
            }
            else
            {
                return new List<GoogleUserDataModel>();
            }
        }
    }
}
