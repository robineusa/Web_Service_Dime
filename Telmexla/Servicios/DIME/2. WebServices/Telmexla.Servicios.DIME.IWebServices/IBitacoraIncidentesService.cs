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
        List<BIPBitacoraIncidentes> ListaDeIncidentesEnGestion(decimal Cedula);
        [OperationContract]
        void AgregarAliado(BIMAliados AliadoNuevo);
        [OperationContract]
        void ActualizarAliado(BIMAliados Aliado);
        [OperationContract]
        void AgregarGerencia(BIMGerencias GerenciaNueva);
        [OperationContract]
        void ActualizarGerencia(BIMGerencias Gerencia);
        [OperationContract]
        void AgregarOperaciones(BIMOperaciones OperacionNueva);
        [OperationContract]
        void ActualizarOperacion(BIMOperaciones Operacion);
        [OperationContract]
        List<BIMGerencias> ListaDeGerenciasAdmin();
        [OperationContract]
        List<BIMAliados> ListaDeAliadosAdmin();
        [OperationContract]
        List<ViewModelIncidentesOperaciones> ListaDeOperacionesAdmin();
        [OperationContract]
        BIMGerencias GerenciaPorId(int Id);
        [OperationContract]
        BIMAliados AliadoPorId(int Id);
        [OperationContract]
        BIMOperaciones OperacionPorId(int Id);
        [OperationContract]
        BILBitacoraIncidentes TraeLogIncidentePorId(int IdRegistro);
        [OperationContract]
        List<ViewModelIncidentesOperaciones> ListaDeAliadosAfectados(decimal IdRegistro);
        [OperationContract]
        List<BILBitacoraIncidentes> LogDeIncidentesPorId(decimal IdRegistro);
        [OperationContract]
        bool ValidarSolicitudIncidente(string CasoSD);
        [OperationContract]
        bool TransaccionIncidenteEnGestion(string Cedula, decimal IdRegistro);
        [OperationContract]
        BIMHerramientas HerramientasPorId(int Id);
        [OperationContract]
        BIMPrioridades PrioridadesPorId(int Id);
        [OperationContract]
        BIMTipoFalla TipoFallaPorId(int Id);
        [OperationContract]
        void AgregarHerramienta(BIMHerramientas HerramientaNueva);
        [OperationContract]
        void ActualizarHerramienta(BIMHerramientas Herramienta);
        [OperationContract]
        void AgregarPrioridad(BIMPrioridades PrioridadNueva);
        [OperationContract]
        void ActualizarPrioridad(BIMPrioridades Prioridad);
        [OperationContract]
        void AgregarTipoFalla(BIMTipoFalla TipoFallaNueva);
        [OperationContract]
        void ActualizarTipoFalla(BIMTipoFalla TipoFalla);
        [OperationContract]
        List<BIMHerramientas> ListaDeHerramientasAdmin();
        [OperationContract]
        List<BIMTipoFalla> ListaTiposDeFallasAdmin();
        [OperationContract]
        List<BIMPrioridades> ListaDePrioridadesAdmin();
        [OperationContract]
        BIPBitacoraIncidentes TraeIncidentePorCasoSD(string CasoSD);
        [OperationContract]
        List<BIPBitacoraIncidentes> ConsultaPrincipalIncidentes(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        List<BILBitacoraIncidentes> ConsultaLogIncidentes(DateTime FechaInicial, DateTime FechaFinal);
    }
}
