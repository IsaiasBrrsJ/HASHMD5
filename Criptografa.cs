using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CriptografiaMD5
{
    public class Criptografa
    {
        public Criptografa() { }

        private string hashDoBanco = "81DC9BDB52D04DC20036DBD8313ED055";
        public string CriptografarSenha(string senhaUser)
        {
            using(var Md5Create = MD5.Create()) // Objeto MD5 criado. 
            {
               return GeraHashMD5(Md5Create, senhaUser);
            }
        }

        private string GeraHashMD5(MD5 md5, string senhUser)
        {
            byte[] senhaToByte = md5.ComputeHash(Encoding.UTF8.GetBytes(senhUser));

            StringBuilder sb = new StringBuilder();

            if(senhaToByte != null)
            {
                for (int i = 0; i < senhaToByte.Length; i++)
                {
                    sb.Append(senhaToByte[i].ToString("X2")); //X2 Converte para hexadecimal.
                }
            }

            return sb.ToString();
        }

        public bool VerificarHash(string senhaUser)
        {
            return ComparaSenha(senhaUser);
        }
        private bool ComparaSenha(string senha)
        {
           StringComparer comparar = StringComparer.OrdinalIgnoreCase;
            if (comparar.Compare(hashDoBanco, CriptografarSenha(senha)) == 0)
                 return true;


           return false;
        }
    }
}
