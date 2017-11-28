
namespace Telmexla.Servicios.DIME.Entity
{
    public class FidelizacionRecursivaVistaDetalle
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public decimal ParentId { get; set; }
        public string ParentName { get; set; }
        public string VerNivel { get; set; }
        public decimal Nivel { get; set; }
        public string Label { get; set; }
        public string Ordr { get; set; }
    }
}
