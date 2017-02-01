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
    public class CuentasSiembraHDBusiness
    {
        public List<CuentasSiembraHD> BuscarCuentaSiembraHD(decimal cuentacliente)
        {
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            CuentasSiembraHDCollection result = new CuentasSiembraHDCollection();
            result.AddRange(unitwork.CuentasSiembraHD.Find(c => c.CuentaCliente == cuentacliente).Select(a => new CuentasSiembraHD
            {
                Id = a.Id,
                CuentaCliente= a.CuentaCliente,
                Ofrecimiento = a.Ofrecimiento
            }).ToList());           

            return result;

        }
    }
}
