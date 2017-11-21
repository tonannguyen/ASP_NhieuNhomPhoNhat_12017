using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Web.UI
{
    public static class Common
    {
        /// <summary>
        /// Connection SQL
        /// </summary>
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());

        public static SqlConnection Connect
        {
            get
            {
                return con;
            }
        }

        /// <summary>
        /// Mã hóa MD5 thời kỳ đầu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MD5Raw(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Mã hóa MD5
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HashMD5(string data)
        {
            //create new instance of md5
            using (MD5 md5 = MD5.Create())
            {
                //convert the input text to array of bytes
                byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

                //create new instance of StringBuilder to save hashed data
                StringBuilder returnValue = new StringBuilder();

                //loop for each byte and add it to StringBuilder
                for (int i = 0; i < hashData.Length; i++)
                {
                    returnValue.Append(hashData[i].ToString());
                }

                // return hexadecimal string
                return returnValue.ToString();
            }
        }

        /// <summary>
        /// Mã hóa SHA1
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HashSHA1(string data)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                //convert the input text to array of bytes
                byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

                //create new instance of StringBuilder to save hashed data
                StringBuilder returnValue = new StringBuilder();

                //loop for each byte and add it to StringBuilder
                for (int i = 0; i < hashData.Length; i++)
                {
                    returnValue.Append(hashData[i].ToString());
                }

                // return hexadecimal string
                return returnValue.ToString();
            }
        }

        /// <summary>
        /// Mã hóa password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="keyDefault"></param>
        /// <returns></returns>
        public static string HashPassword(string password, string keyDefault)
        {
            string result = "" + password;

            string hashMd5 = HashMD5(password);
            string hashSha1 = HashSHA1(password);
            //structure hashPassword = md5(sha1(md5(md5(password) + sha1(password)) + md5(password)));
            result = HashMD5((HashSHA1(HashMD5((hashMd5 + hashSha1 + keyDefault + hashMd5)))));

            return result;
        }

        /// <summary>
        /// Tạo mã string random
        /// </summary>
        /// <returns></returns>
        public static string GenerateString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

    }
}