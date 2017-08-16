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
    public interface IBitacoraIncidentesService
    {
        [OperationContract]
        decimal RegistrarIncidente(BIPBitacoraIncidentes Bitacora);
        [OperationContract]
        void ActualizarRegistroIncidente(BIPBitacoraIncidentes Bitacora);
        [OperationContract]
        void RegistrarOperacionesPorIncidente(List<string> Operaciones, decimal IdRegistro);
        [OperationContract]
        void EliminarIncidenteOperacion(decimal Id);
        [OperationContract]
        List<BIMGerencias> ListaDeGerencias();
        [OperationContract]
        List<BIMAliados> ListaDeAliados();
        [OperationContract]
        List<BIMOperaciones> ListaOperaciones();
        [OperationContract]
        List<BIMHerramientas> ListaDeHerramientas();
        [OperationContract]
        List<BIMTipoFalla> ListaTiposDeFallas();
        [OperationContract]
        List<BIMPrioridades> ListaDePrioridades();
        [OperationContract]
        List<BIMOperaciones> ListaDeOperaciones();
        [OperationContract]
        List<BIMAliados> ListaDeAliadosPorGerencia(List<string> Gerencias);
        [OperationContract]
        List<BIMOperaciones> ListaDeOperacionesPorgerenciaYAliado(List<string> Gerencias, List<string> Aliados);
        [OperationContract]
        void RegistrarOperacionesEnIncidente(List<string> Operaciones, decimal IdRegistro);
        [OperationContract]
        BIPBitacoraIncidentes TraeIncidentePorId(int IdRegistro);
        [OperationContract]
        List<ViewModelIncidentesOperaciones> ListaDeIncidentesOperacionPorRegistro(decimal IdRegistro);
        [OperationContract]
        void EliminarOpoeracionDeIncidente(int Id);
        [OperationContract]
        List<BIPBitacoraIncidentes> ListaDeIncidentesEnGestion();
    }
}
