using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class SiguienteMejorOferta
    {
        public decimal Id { get; set; }
        public System.DateTime? FechaGestion { get; set; }
        public string UsuarioGestion { get; set; }
        public string AliadoGestion { get; set; }
        public decimal CuentaCliente { get; set; }
        public decimal Ofrecimiento1 { get; set; }
        public decimal Ofrecimiento2 { get; set; }
        public decimal Ofrecimiento3 { get; set; }
        public string TipoContacto { get; set; }
        public string Gestion { get; set; }
        public string Cierre { get; set; }
        public string Razon { get; set; }
        public string Observaciones { get; set; }

    }
}
