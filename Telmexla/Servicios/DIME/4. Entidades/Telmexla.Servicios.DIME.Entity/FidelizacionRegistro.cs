
namespace Telmexla.Servicios.DIME.Entity
{
    public class FidelizacionRegistro
    {
        public decimal Id { get; set; }
        public decimal SubmotivoId { get; set; }
        public decimal RecursivaIdA { get; set; }
        public decimal? RecursivaIdB { get; set; }
        public decimal? RecursivaIdC { get; set; }
        public string ServiciosId { get; set; }
        public string Permanencia{ get; set; }
        public decimal DiaCorte { get; set; }
        public System.DateTime? FechaCorte { get; set; }
        public System.DateTime? FechaRegistro { get; set; }
        public int UsuarioId { get; set; }
        public decimal Cuenta { get; set; }
        public decimal TipificacionId { get; set; }
        public string ServiciosRetenidosId { get; set; }
        public string Notas { get; set; }
        public string UsuarioTransfiere { get; set; }
        public decimal Renta { get; set; }
        public string Direccion { get; set; }
        public decimal Ticket { get; set; }
        public decimal Nivel { get; set; }
    }
}
