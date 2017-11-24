using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IRetencionService
    {
        [OperationContract]
        decimal RegistrarSolicitudRetencionAutomatico(RSPSeguimientos Solicitud);
        [OperationContract]
        decimal RegistrarSolicitudRetencionFormulario(RSPSeguimientos Solicitud);
        [OperationContract]
        List<RSMArboles> ListasDeArbolesRetencion(decimal IdPadre);
        [OperationContract]
        List<RSMArboles> ListasDeArbolesRetencionAdmin(decimal IdPadre);
        [OperationContract]
        void ActualizarArbolRetencion(RSMArboles Arbol);
        [OperationContract]
        void RegistrarNuevoArbol(RSMArboles Arbol);
        [OperationContract]
        RSMArboles TraerArbolPorId(decimal IdArbol);
        [OperationContract]
        List<RSPSeguimientos> ConsultaAdministradorPricipal(DateTime FechaInicio, DateTime FechaFin);
        [OperationContract]
        List<RSLSeguimientos> ConsultaAdministradorLog(DateTime FechaInicio, DateTime FechaFin);
    }
}
