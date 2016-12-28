using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Business
{
    public class GestionDeCelulaUsr
    {

        public decimal IdNota { get; set; } // ID_NOTA
        public decimal? IdIngreso { get; set; } // ID_INGRESO
        public System.DateTime? FechaNota { get; set; } // FECHA_NOTA
        public System.DateTime? HoraNota { get; set; } // HORA_NOTA
        public string Usuario { get; set; } // USUARIO (length: 100)
        public string Nota { get; set; } // NOTA (length: 1073741823)
        public string UsuarioApertura { get; set; } // USUARIO_APERTURA (length: 100)
        public decimal CuentaCliente { get; set; } // CUENTA
        public System.DateTime? FechaApertura { get; set; } // FECHA_APERTURA
        public string Macroproceso { get; set; } // MACROPROCESO (length: 100)
        public string Marcacion { get; set; } // MARCACION (length: 100)
        public string NombreLineaIngreso { get; set; } // NOMBRE_LINEA_INGRESO (length: 50)
        public string NombreLineaEscalado { get; set; } // NOMBRE_LINEA_ESCALADO (length: 50)
        public string Semaforo { get; set; } // SEMAFORO (length: 100)
        public int? IdEstado { get; set; } // ID_ESTADO



    }
}
