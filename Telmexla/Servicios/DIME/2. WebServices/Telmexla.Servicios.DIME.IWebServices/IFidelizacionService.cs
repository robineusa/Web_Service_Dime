using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IFidelizacionService
    {
        [OperationContract]
        List<FidelizacionMaestroServicios> getMaestroServiciosAll();
        [OperationContract]
        FidelizacionMaestroServicios getMaestroServiciosById(string codServicio);
        [OperationContract]
        void setMotivosCancelacion(FidelizacionMotivosCancelacion MotivoCancelacion);
        [OperationContract]
        FidelizacionMotivosCancelacion getMotivosCancelacionById(decimal codMotivo);
        [OperationContract]
        List<FidelizacionMotivosCancelacion> getMotivosCancelacionAll(decimal eliminado);
        [OperationContract]
        List<FidelizacionSubmotivosCancelacionDetalle> getSubmotivosCancelacionAll(decimal estado, decimal idMotivo);
        [OperationContract]
        FidelizacionSubmotivosCancelacion getSubmotivosCancelacionById(decimal idSubmotivo);
        [OperationContract]
        void setSubmotivoCancelacion(FidelizacionSubmotivosCancelacion ObjFidelizacion);
        [OperationContract]
        void setOtrosOfrecimientos(FidelizacionOtrosOfrecimientos ObjOfrecimientos);
        [OperationContract]
        FidelizacionOtrosOfrecimientos getOtrosOfrecimientosById(decimal idOfrecimiento);
        [OperationContract]
        List<FidelizacionOtrosOfrecimientos> getOtrosOfrecimientosAll();
        [OperationContract]
        void setTipificacion(FidelizacionTipificacion objTipificacion);
        [OperationContract]
        void setRecursiva(FidelizacionRecursiva objRecursiva);
        [OperationContract]
        FidelizacionRecursiva getRecursivaById(decimal idRecursiva);
        [OperationContract]
        List<FidelizacionRecursiva> getRecursivaAll(decimal idPadre = 0, decimal nivel = 0);
        [OperationContract]
        void setRegistro(FidelizacionRegistro objRegistro);
        [OperationContract]
        List<FidelizacionRegistro> getRegistroAll();
        [OperationContract]
        void updateMotivoCancelacion(FidelizacionMotivosCancelacion objMotivo);
        [OperationContract]
        void updateMaestroServicios(FidelizacionMaestroServicios objServicio);
        [OperationContract]
        void updateSubmotivoCancelacion(FidelizacionSubmotivosCancelacion objSubmotivo);
        [OperationContract]
        void updateOtrosOfrecimientos(FidelizacionOtrosOfrecimientos objOtros);
        [OperationContract]
        void updateTipificacion(FidelizacionTipificacion objTipificacion);
        [OperationContract]
        void updateRecursiva(FidelizacionRecursiva objRecursiva);
        [OperationContract]
        void updateRegistro(FidelizacionRegistro objRegistro);
        [OperationContract]
        List<FidelizacionTipificacion> getTipificacionAll(decimal eliminado, decimal nivel = 0);
        [OperationContract]
        FidelizacionTipificacion getTipificacionById(decimal idTipificacion);
        [OperationContract]
        void updateOtrosCampos(FidelizacionOtrosCampos objOtrosCampos);
        [OperationContract]
        void setOtrosCampos(FidelizacionOtrosCampos objOtrosCampos);
        [OperationContract]
        FidelizacionOtrosCampos getOtrosCamposById(decimal idOtrosCampos);
        [OperationContract]
        List<FidelizacionOtrosCampos> getOtrosCamposAll(decimal eliminado, decimal nivel = 0);
        [OperationContract]
        void setRegistroCampos(FidelizacionRegistroCampos objRegistroCampos);
        [OperationContract]
        FidelizacionRegistroCampos getRegistroCamposById(decimal idRegistro);
        [OperationContract]
        List<FidelizacionRegistroCampos> getRegistroCamposAll();
        [OperationContract]
        void updateRegistroCampos(FidelizacionRegistroCampos objRegistroCampos);
        [OperationContract]
        List<FidelizacionRecursivaVistaDetalle> getRecursivaVistaAll();
        [OperationContract]
        FidelizacionRecursivaVista getRecursivaVistaById(decimal idRecursiva);
        [OperationContract]
        List<FidelizacionRecursiva> getRecursivaArbol(decimal idHijo);
        [OperationContract]
        List<MaestroFestivos> getMaestrosByCorteId(decimal numDias, decimal corte);
    }
}
