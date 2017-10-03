 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class InventarioEquipos
    {
        public int Id { get; set; }
        public decimal? Cuenta { get; set; }
        public string Tipo { get; set; }
        public string FabEquipo { get; set; }
        public string SerieEquipo{ get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
    }
}
