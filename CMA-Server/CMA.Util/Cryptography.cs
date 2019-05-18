using System;

namespace CMA.Utility
{
    public static class Cryptography
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hMac.Key;
                passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool IsValidPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }

            }

            return true;
        }
    }
}
