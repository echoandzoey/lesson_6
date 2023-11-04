// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NanoModule.ExcelToBytes.ExporterHandler
{
    public static class MD5Handler
    {
        public static string ComputeFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            using (MD5 md5Hash = MD5.Create())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] hash = md5Hash.ComputeHash(fs);
                    fs.Close();
                    return HashByteArrayToString(hash);
                }
            }
        }

        public static string ComputeByteArray(byte[] input)
        {
            if (null == input)
            {
                return null;
            }

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(input);
                return HashByteArrayToString(data);
            }
        }

        private static string HashByteArrayToString(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
