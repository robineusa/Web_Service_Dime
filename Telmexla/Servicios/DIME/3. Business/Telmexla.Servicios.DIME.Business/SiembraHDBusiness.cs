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
    }
}
