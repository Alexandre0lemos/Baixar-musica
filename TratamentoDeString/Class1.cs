using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BaixarVideo.Class
{
    public class TratamentoDeTexto
    {
        public string NomeDeMusica(string texto)
        {
            var invalidCharsRegex = new Regex($"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]");

            var cleanTitle = invalidCharsRegex.Replace(texto, "_");

            return cleanTitle;
        }

        public string NomeDePasta(string texto)
        {
            var cleanTitle = NomeDeMusica(texto).Replace(" ", "").Replace("__", "_").ToLower();
            return cleanTitle;
        }
    }
}
