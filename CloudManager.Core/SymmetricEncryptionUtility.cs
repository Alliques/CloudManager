using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager.Core
{
    public static class SymmetricEncryptionUtility
    {
        public static SymmetricAlgorithm GenerateKey()
        {
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create("DES");
            Algorithm.GenerateKey();

            // Получить ключ
            //byte[] Key = Algorithm.Key;

            //if (ProtectKey)
            //{
            //    // Использовать DPAPI для шифрования ключа
            //    Key = ProtectedData.Protect(
            //        Key, null, DataProtectionScope.LocalMachine);
            //}
            return Algorithm;
        }

        //public static void ReadKey(RSACryptoServiceProvider algorithm, string keyFile)
        //{
        //    byte[] KeyBytes;

        //    using (FileStream fs = new FileStream(keyFile, FileMode.Open))
        //    {
        //        KeyBytes = new byte[fs.Length];
        //        fs.Read(KeyBytes, 0, (int)fs.Length);
        //    }

        //    KeyBytes = ProtectedData.Unprotect(KeyBytes,
        //            null, DataProtectionScope.LocalMachine);

        //    algorithm.FromXmlString(Convert.ToBase64String(KeyBytes));
        //}

        //public static byte[] EncryptData(string data, string publicKey)
        //{
        //    // Создать алгоритм на основе открытого ключа
        //    RSACryptoServiceProvider Algorithm = new RSACryptoServiceProvider();
        //    Algorithm.FromXmlString(publicKey);

        //    // Зашифровать данные
        //    return Algorithm.Encrypt(
        //           Convert.FromBase64String(data), true);
        //}

        //public static string DecryptData(byte[] data, string keyFile)
        //{
        //    RSACryptoServiceProvider Algorithm = new RSACryptoServiceProvider();
        //    ReadKey(Algorithm, keyFile);

        //    byte[] ClearData = Algorithm.Decrypt(data, true);
        //    return Convert.ToString(
        //           Convert.ToBase64String(ClearData));
        //}
    }
}
