using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Majorizor.Resources.Security
{
    public class Security
    {
        /// <summary>
        /// Generates a random salt of the given size
        /// </summary>
        /// <param name="size">Size, in characters, of the salt to generate</param>
        /// <returns>A salt whose length is the number of characters specified by "size"</returns>
        public static string generateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// Hashes a given password with a given salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns>A satled and hashed password</returns>
        public static string generateHash(string password, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            SHA256Managed hashString = new SHA256Managed();
            byte[] hash = hashString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}