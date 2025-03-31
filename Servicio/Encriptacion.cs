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
        public void Hash(string text)
        {
            using (SHA256 encry= SHA256.Create())
            {
                byte[ ] b=Encoding.UTF8.GetBytes(text);
                byte[] bytehash = encry.ComputeHash(b); 
            }
        }
    }
}
