using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BaixarVideo.Class
{
    public class TratamentoDeTexto
    {
        public string Titulo(string texto)
        {
            texto = texto.Replace(" ", "_");
            texto = texto.Replace("-", "_");
            texto = texto.Replace("|", "");
            texto = texto.Replace("(","");
            texto = texto.Replace(")", "");
            texto = texto.Replace("__", "");
            texto = texto.ToLower();

            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";

            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i], semAcentos[i]);
            }

            return texto;
        }
    }
}
