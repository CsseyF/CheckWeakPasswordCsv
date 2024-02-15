using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CheckWeakPasswordCsv
{
    public class CryptPass
    {
        public static string CryptSalt(string senha, string salt)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(senha + salt);
            SHA512 shaM = new SHA512Managed();
            Byte[] hashedBytes = shaM.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
        public static void ValidarSenha(string senha, string salt, string senhaBanco)
        {
            var senhaSalt = CryptSalt(senha, salt);
            Console.WriteLine(senhaSalt.Equals(senhaBanco));
        }
    }


}
