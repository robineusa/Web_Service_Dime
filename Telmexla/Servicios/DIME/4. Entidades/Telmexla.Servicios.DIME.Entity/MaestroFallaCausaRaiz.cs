using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class MaestroFallaCausaRaiz
    {
        public int Id { get; set; }
        public int IdFallaEspecifica { get; set; }
        public string FallaCausaRaiz { get; set; }
    }
}
