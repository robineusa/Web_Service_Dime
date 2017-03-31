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
    public class SiembraHDBusiness
    {
        public void InsertarSiembraHDInbound(SiembraHD siembra)
        {
            try
            {
                siembra.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.ActivacionSiembraHD.Add(siembra);
                unitWork.Complete();


            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }


        }

        public void InsertarSMOInbound(SiguienteMejorOferta smo)
        {
            try
            {
                smo.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.SMO.Add(smo);
                unitWork.Complete();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }


        }

        public SmoTarifaActual ConsultaTarifaActualDeDatos(string estrato, string voz, string tv, string internet)
        {
            DimeContext dimeContext = new DimeContext();
            SmoTarifaActual result;
            result = dimeContext.Set<SmoTarifaActual>().Where(c => c.Tarifa.Equals("PLENA") && c.Estrato.Equals(estrato) && c.Voz.Equals(voz)
             && c.TipoTv.Equals(tv) && c.TipoInternet.Equals(internet)).Select(x => new
             {
                 Id = x.Id,
                 CodTarifaRes = x.CodTarifaRes,
                 IncluyeHd = x.IncluyeHd,
                 InclyeClarovideo = x.InclyeClarovideo,
                 IncluyePvr = x.IncluyePvr,
                 RentaTotal = x.RentaTotal
             }).ToList().Select(y => new SmoTarifaActual
             {
                 Id = y.Id,
                 CodTarifaRes = y.CodTarifaRes,
                 IncluyeHd = y.IncluyeHd,
                 InclyeClarovideo = y.InclyeClarovideo,
                 IncluyePvr = y.IncluyePvr,
                 RentaTotal = y.RentaTotal
             }).FirstOrDefault();

            return result;
        }

        public SmoRentaActual ConsultaRentaActualDeCuenta(string cuenta)
        { int cuentaFloat = Convert.ToInt32(cuenta);
            DimeContext dimeContext = new DimeContext();
           return  dimeContext.SmoRentaActuals.Where(c => c.Cuenta == cuentaFloat).FirstOrDefault();
        }
    }
}
