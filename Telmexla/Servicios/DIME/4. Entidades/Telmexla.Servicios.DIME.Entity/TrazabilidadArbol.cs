

namespace Telmexla.Servicios.DIME.Entity
{
    public class TrazabilidadArbol
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int CuentaAsociada { get; set; }
        public int NodoActual { get; set; }
        public bool FinalizoProceso { get; set; }
    }
}
