using System;
using System.Security.Cryptography;
using System.Text;

namespace LibraryApp.Application.Common
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}


