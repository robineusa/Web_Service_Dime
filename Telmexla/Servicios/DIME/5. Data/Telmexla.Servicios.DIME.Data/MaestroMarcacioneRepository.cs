using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class MaestroMarcacioneRepository : Repository<MaestroMarcacione> , IMaestroMarcacioneRepository
    {

        public MaestroMarcacioneRepository(DimeContext context) : base(context)
        {

        }

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }

        public MaestroMarcacioneCollection EncontrarPosiblesMarcaciones(string key)
        {

           var result =( from m in dimeContext.MaestroMarcaciones
                         where (m.Descripcion.Contains(key) || m.Submarcacion.Contains(key)) && m.EstadoMarcacion.Equals("ACTIVA")
                         select   new { m.Id,m.Submarcacion, m.Descripcion }).Distinct().ToList();
            MaestroMarcacioneCollection transforma = new MaestroMarcacioneCollection();
            foreach (var item in result)
            {
                transforma.Add(new MaestroMarcacione() {Id=item.Id, Submarcacion=item.Submarcacion , Descripcion= item.Descripcion     });
            }
            return transforma;
        }
    }
}
