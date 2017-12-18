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
    public interface ICierreExperienciaService 
    {
        //Desconexiones
        [OperationContract]
        CEPAsigDesconexiones TraeRegistroAsignacion(decimal Id);
        [OperationContract]
        void RegistrarDesconexion(CEPDesconexiones Desconexion, decimal IdBaseAsig);
        [OperationContract]
        void ActualizarDesconexion(CEPDesconexiones Desconexion);
        [OperationContract]
        List<CEMArbolesDeGestion> ArbolDeGestionAgente(decimal IdPadre);
        [OperationContract]
        void ActualizarArbolCierreExperiencia(CEMArbolesDeGestion Arbol);
        [OperationContract]
        void RegistrarNuevoArbolCierreExperiencia(CEMArbolesDeGestion Arbol);
        [OperationContract]
        CEMArbolesDeGestion TraerArbolCierreExperienciaPorId(decimal IdArbol);
        [OperationContract]
        List<CEPDesconexiones> ListaSeguimientosAgenteCierreExperiencia(decimal Usuario);
        [OperationContract]
        List<CELDesconexiones> ListaDeGestionAgenteCierreExperiencia(decimal Usuario);
        [OperationContract]
        List<CEPDesconexiones> ConsultaGeneralAdministradorCierreExperiencia(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        List<CELDesconexiones> ConsultaLogAdministradorCierreExperiencia(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        CEPDesconexiones TraeDesconexionPorId(decimal IdGestion);
    }
}
