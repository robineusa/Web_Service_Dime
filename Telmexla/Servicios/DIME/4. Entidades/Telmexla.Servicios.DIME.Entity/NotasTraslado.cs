
namespace Telmexla.Servicios.DIME.Entity
{
    //TBL_NOTAS_TRASLADOS
    public class NotasTraslado
    {
        public decimal Id { get; set; } // ID INCREMENTAL DE LA TABLA
        public decimal? IdTransaccion { get; set; } // ID DE LA TRANSACCION GLOBAL
        public string UsuarioTransaccion { get; set; } //USUARIO QUE GENERA LA TRANSACCION
        public string CanalTransaccion { get; set; } //CANAL DONDE SE GENERA LA TRANSACCION
        public System.DateTime? FechaTransaccion { get; set; } // FECHA DE LA TRANSACCION
        public string NombreLineaTransaccion { get; set; } // NOMBRE DE LA LINEA DE LA TRANSACCION
        public decimal CuentaCliente { get; set; } // CUENTA DEL CLIENTE
        public string DireccionACrear { get; set; } //DIRECCION A CREAR
        public string Estrato { get; set; }// ESTRATO DEL CLIENTE
        public string Nodo { get; set; } // NODO
        public string TelefonoCelular { get; set; } // TELEFONO CELULAR DEL CLIENTE
        public string TelefonoFijo { get; set; }// TELEFONO FIJO DEL CLIENTE
        public string Razon { get; set; }// RAZON
        public string Subrazon { get; set; }//SUBRAZON
        public string Observacion { get; set; }// OBSERVACION REALIZADA
        public string EstadoTransaccion { get; set; } // ESTADO DE LA TRANSACCION
        public string UsuarioBackOffice { get; set; }//USUARIO DEL BACK
        public string UsuarioBackOutbound { get; set; }//USUARIO OUTBOUND
    }
}
