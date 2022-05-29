using System;
using System.Security.Cryptography;
using System.Text;

namespace Automarket.Domain.Helpers
{
    public static class HashPasswordHelper
    {
        public static string HashPassowrd(string password)
        {
            using(var sha256 = SHA256.Create())  
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); 
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}