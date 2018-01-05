using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class IndiceNodoArbol
    {
        public int IdNodo { get; set; }
        public int IdPadre { get; set; }
        public string NombreNodo { get; set; }
    }
}
