namespace Telmexla.Servicios.DIME.Entity
{
    //TBL_INGRESOS TRASLADOS
    public class IngresoTraslado
    {
        public decimal IdTraslado { get; set; } // ID_TRASLADO (Primary key)
        public decimal CuentaCliente { get; set; } //CUENTA DEL CLIENTE
        public string Direccion { get; set; }//DIRECCION A CREAR
        public string Estrato { get; set; }//ESTRATO CLIENTE
        public string Nodo { get; set; }//NODO CLIENTE
        public string TelefonoCelular { get; set; }//TELEFONO CELULAR
        public string TelefonoFijo { get; set; }//TELEFONO FIJO
        public System.DateTime? FechaApertura { get; set; } // FECHA_APERTURA
        public System.DateTime? HoraApertura { get; set; } // HORA APERTURA
        public System.DateTime? FechaCierre { get; set; } // FECHA CIERRE
        public System.DateTime? HoraCierre { get; set; } // HORA CIERRE
        public string UsuarioApertura { get; set; }// USUARIO APERTURA
        public string UsuarioCierre { get; set; }//USUARIO CIERRE
        public System.DateTime? FechaUltimaActualizacion { get; set; } // FECHA ULTIMA ACTUALIZACION
        public string UsuarioUltimaActualizacion { get; set; } //USUARIO ULTIMA ACTUALIZACION
        public System.DateTime? HoraUltimaActualizacion { get; set; } // HORA ULTIMA ACTUALIZACION
        public string Razon { get; set; }//RAZON
        public string Subrazon { get; set; }//SUBRAZON
        public string EstadoCaso { get; set; }//ESTADO DEL CLASO
        public string EstadoBackoffice { get; set; } //ESTADO CASO BACKOFFICE
        public string UsuarioBackoffice { get; set; }// USUARIO DEL BACK
        public System.DateTime? FechaInicioGestionBackoffice { get; set; } // FECHA INICIO DE GESTION DELBACK
        public string UsuarioGestionOutbound { get; set; }// USUARIO DE OUTBOUND
        public System.DateTime? FechaInicioGestionOutbound { get; set; } // FECHA DE INICIO DE GESTION OUTBOUND
        public string AliadoApertura { get; set; }//ALIADO DE APERTURA
        public string NombreLineaIngreso { get; set; }//NOMBRE DE LINEA DE INGRESO
        public string NombreLineaEscalado { get; set; }//NOMBRE DE LINEA ESCALADO

    }
}
