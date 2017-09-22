using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.WebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    [ServiceContract]
    public class FidelizacionService : IFidelizacionService
    {
        [OperationContract]
        public List<FidelizacionMaestroServicios> getMaestroServiciosAll()
        {
            FidelizacionBusiness FildelizacionServicio = new FidelizacionBusiness();
            return FildelizacionServicio.getMaestroServiciosAll();
        }
        [OperationContract]
        public FidelizacionMaestroServicios getMaestroServiciosById(string codServicio)
        {
            FidelizacionBusiness FildelizacionServicio = new FidelizacionBusiness();
            return FildelizacionServicio.getMaestroServiciosById(codServicio);
        }

        public void setMotivosCancelacion(FidelizacionMotivosCancelacion MotivoCancelacion)
        {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            Fidelizacion.setMotivosCancelacion(MotivoCancelacion);
        }

        public FidelizacionMotivosCancelacion getMotivosCancelacionById(decimal codMotivo)
        {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            return Fidelizacion.getMotivosCancelacionById(codMotivo);
        }

        public List<FidelizacionMotivosCancelacion> getMotivosCancelacionAll()
        {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            return Fidelizacion.getMotivosCancelacionAll();
        }

        public List<FidelizacionSubmotivosCancelacion> getSubmotivosCancelacionAll()
        {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            return Fidelizacion.getSubmotivosCancelacionAll();
        }
        public FidelizacionSubmotivosCancelacion getSubmotivosCancelacionById(decimal idSubmotivo)
        {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            return Fidelizacion.getSubmotivosCancelacionById(idSubmotivo);
        }

        public void setSubmotivoCancelacion(FidelizacionSubmotivosCancelacion ObjFidelizacion)
        {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            Fidelizacion.setSubmotivoCancelacion(ObjFidelizacion);
        }
        public void setOtrosOfrecimientos(FidelizacionOtrosOfrecimientos ObjOfrecimientos) {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            Fidelizacion.setOtrosOfrecimientos(ObjOfrecimientos);
        }
        public FidelizacionOtrosOfrecimientos getOtrosOfrecimientosById(decimal idOfrecimiento) {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            return Fidelizacion.getOtrosOfrecimientosById(idOfrecimiento);
        }
        public List<FidelizacionOtrosOfrecimientos> getOtrosOfrecimientosAll() {
            FidelizacionBusiness Fidelizacion = new FidelizacionBusiness();
            return Fidelizacion.getOtrosOfrecimientosAll();
        }
    }
}
