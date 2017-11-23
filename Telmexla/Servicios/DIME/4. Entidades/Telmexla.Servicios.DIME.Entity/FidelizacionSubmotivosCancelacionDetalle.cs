using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class FidelizacionSubmotivosCancelacionDetalle
    {
        public decimal Id { get; set; }
        public string Submotivo { get; set; }
        public decimal Eliminado { get; set; }
        public decimal FIDMotivoId { get; set; }
        public string NombreMotivo { get; set; }
        public System.DateTime? Registro { get; set; }
    }
}
