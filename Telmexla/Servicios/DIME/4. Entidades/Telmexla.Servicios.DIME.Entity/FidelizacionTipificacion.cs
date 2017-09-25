
namespace Telmexla.Servicios.DIME.Entity
{
    public class FidelizacionTipificacion
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Nota { get; set; }
        public decimal Eliminado { get; set; }
        public decimal Activo { get; set; }
        public decimal Modulo { get; set; }
        public decimal Nivel1 { get; set; }
        public decimal Nivel2 { get; set; }
        public decimal Nivel3 { get; set; }
        public int UsuarioId { get; set; }
        public System.DateTime? Registro { get; set; }
    }
}
