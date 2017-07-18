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
        public List<CuentasSiguienteMejorOferta> BuscarCuentaSMO(decimal cuentacliente)
        {
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            CuentasSiguienteMejorOfertaCollection result = new CuentasSiguienteMejorOfertaCollection();
            result.AddRange(unitwork.CuentaSMO.Find(c => c.CuentaCliente == cuentacliente).Select(a => new CuentasSiguienteMejorOferta
            {
                Id = a.Id,
                CuentaCliente = a.CuentaCliente,
                Ofrecimiento1 = a.Ofrecimiento1,
                Ofrecimiento2 = a.Ofrecimiento2,
                Ofrecimiento3 = a.Ofrecimiento3,
            }).ToList());

            return result;

        }
        public List<CuentasMejorasTecnicas> BuscarCuentaMejorasTecnicas(decimal cuentacliente)
        {
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            CuentasMejorasTecnicasCollection result = new CuentasMejorasTecnicasCollection();
            result.AddRange(unitwork.CuentasMejorasTecnicas.Find(c => c.Cuenta == cuentacliente).Select(a => new CuentasMejorasTecnicas
            {
                Id = a.Id,
                Cuenta = a.Cuenta,
                Accionable = a.Accionable
            }).ToList());

            return result;

        }

        public CargaBaseFoxInbound BuscarCuentaFoxInbound(decimal cuentacliente)
        {
            DimeContext context = new DimeContext();
            return context.CargaBaseFoxInbound.Where(c => c.Cuenta == cuentacliente).FirstOrDefault();
        }
    }
}
