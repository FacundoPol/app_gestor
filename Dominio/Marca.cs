using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public int idMarca;
        public string nombreMarca;

        public override string ToString()
        {
            return nombreMarca;
        }
    }
}
