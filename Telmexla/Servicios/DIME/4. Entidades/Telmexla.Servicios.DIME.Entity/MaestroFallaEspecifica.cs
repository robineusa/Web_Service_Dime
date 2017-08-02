using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class MaestroFallaEspecifica
    {
        public int Id { get; set; }
        public int IdOpcionesRecurrencia { get; set; }
        public string FallaEspecificaCCAA { get; set; }
    }
}
