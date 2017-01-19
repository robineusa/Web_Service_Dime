
namespace Telmexla.Servicios.DIME.Entity
{
    //TBL_NOTAS_TRASLADOS
    public class NotasTraslado
    {
        public decimal IdNota { get; set; } // ID_NOTA
        public decimal? IdTraslado { get; set; } // ID_TRASLADO
        public decimal CuentaCliente { get; set; } // CUENTA_CLIENTE
        public string Usuario { get; set; } // USUARIO 
        public string NombreLineaNota { get; set; } // NOMBRE_LINEA_NOTA 
        public System.DateTime? FechaNota { get; set; } // FECHA_NOTA
        public System.DateTime? HoraNota { get; set; } // HORA_NOTA
        public string Nota { get; set; } // NOTA 
        public string Razon { get; set; } // RAZON
        public string Subrazon { get; set; } // SUBRAZON
        public string Estado { get; set; } // ESTADO
    }
}
