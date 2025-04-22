using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CadastroDeContatos.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string senha)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(senha);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var c in array)
            {
                strHexa.Append(c.ToString("X2"));
            }

            return strHexa.ToString();
        }
    }
}
