﻿using System;
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
        List<FidelizacionMotivosCancelacion> getMotivosCancelacionAll();
        [OperationContract]
        List<FidelizacionSubmotivosCancelacion> getSubmotivosCancelacionAll();
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
        List<FidelizacionRecursiva> getRecursivaAll();
        [OperationContract]
        void setRegistro(FidelizacionRegistro objRegistro);
        [OperationContract]
        List<FidelizacionRegistro> getRegistroAll();

    }
}
