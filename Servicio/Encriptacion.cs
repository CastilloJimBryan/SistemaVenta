using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class Encriptacion
    {
        public static string Hash(string text)
        {
            using (SHA256 encry= SHA256.Create())
            {
                byte[ ] b=Encoding.UTF8.GetBytes(text);
                byte[] bytehash = encry.ComputeHash(b);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytehash.Length; i++)
                {
                    sb.Append(bytehash[i].ToString("x2")); // Formato hexadecimal
                }
                return sb.ToString();
            }
        }
    }
}
