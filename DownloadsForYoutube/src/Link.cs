using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace ProjetoFinal.src.link
{
    public class Link
    {
        public Link(string url)
        { urlLink = url; }
        protected string urlLink;

        #pragma warning disable CA1416 
        protected string nomeDoComputador = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    }
}