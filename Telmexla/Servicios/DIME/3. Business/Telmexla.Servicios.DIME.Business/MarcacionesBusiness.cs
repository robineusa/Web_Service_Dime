using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class MarcacionesBusiness
    {
        public void RegistrarNuevaMarcacion(MaestroMarcacione marcacion) {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
        
        }
    }
}
