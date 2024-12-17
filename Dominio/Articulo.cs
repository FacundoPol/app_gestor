using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public string codigoArt { get; set; }
        public string nombreArt { get; set; }
        public string descripcionArt { get; set; }
        public string imgArt { get; set; }
        public decimal precio { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
    }
}
