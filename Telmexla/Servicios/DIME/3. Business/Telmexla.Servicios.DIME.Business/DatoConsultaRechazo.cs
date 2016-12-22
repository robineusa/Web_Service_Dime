using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Business
{
   public  class DatoConsultaRechazo
    {
        public decimal? IdIngreso { get; set; } // ID_INGRESO
        public System.DateTime? FechaCreacionCaso { get; set; } // FECHA_CREACION_CASO
        public string HoraCreacionCaso { get; set; } // HORA_CREACION_CASO (length: 50)
        public string UsuarioCreacionCaso { get; set; } // USUARIO_CREACION_CASO (length: 50)
        public string NotasRechazo { get; set; } // NOTAS_RECHAZO (length: 500)
        public string UsuarioRechaza { get; set; } // USUARIO_RECHAZA (length: 50)
        public System.DateTime? FechaRechazo { get; set; } // FECHA_RECHAZO
        public System.DateTime? HoraRechazo { get; set; } // HORA_RECHAZO
        public string NombreUsuarioCreacion { get; set; }
        public string NombreUsuarioRechaza { get; set; }
        public string NombreLineaUsuarioRechaza { get; set; }
        public string  AliadoUsuarioRechaza { get; set; }
    }
}
