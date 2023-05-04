using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
namespace projetAPI2.Methode
{
    public class HashPasword
    {

        public static string hashPasword(string password) {

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashedstring = BitConverter.ToString(bytes).Replace("-", "");

                return hashedstring;
            }
}
    }
}

