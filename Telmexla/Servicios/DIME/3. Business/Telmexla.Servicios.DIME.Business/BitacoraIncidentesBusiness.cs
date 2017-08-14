using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class BitacoraIncidentesBusiness
    {
        public void RegistrarIncidente(BIPBitacoraIncidentes Bitacora)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.BIPBitacoraIncidentes.Add(Bitacora);
            unitWork.Complete();
            unitWork.Dispose();
        }
    }
}
