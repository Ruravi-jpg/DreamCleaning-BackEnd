using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DC.WebApi.Core
{
    public class PasswordHelper : IPasswordHelper
    {
        public byte[] GenerateHash(string password, byte[] salt)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("The password cannot be null or empty");

            return KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 1000, 256);
        }

        public byte[] GenerateSalt()
        {
            using var provider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[128];
            provider.GetNonZeroBytes(salt);

            return salt;
            
        }
    }
}
