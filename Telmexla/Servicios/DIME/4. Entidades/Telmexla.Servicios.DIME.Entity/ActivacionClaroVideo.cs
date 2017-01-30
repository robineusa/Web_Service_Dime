
namespace Telmexla.Servicios.DIME.Entity
{
    public class ActivacionClaroVideo
    {
       public decimal IdActivacion { get; set; }
        public System.DateTime? FechaGestion { get; set; } 
        public string UsuarioGestion { get; set; }
        public string NombreUsuario { get; set; }
        public string AliadoGestion { get; set; }
        public decimal CuentaCliente { get; set; }
        public string AceptacionClaroVideo { get; set; }
    }
}
