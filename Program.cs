using System.Text;

namespace CriptografiaMD5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
          Criptografa criptografar = new Criptografa();

          string senha = "1234";

          var hashCrip = criptografar.CriptografarSenha(senha);

          var a = criptografar.VerificarHash(senha);

            Console.WriteLine(a);
        }
    }
}
