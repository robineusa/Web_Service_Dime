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
    public interface IVerificacionDeInventarioService
    {
        [OperationContract]
        decimal ReistrarSolicitud(VIPSolicitudes Solicitud);
        [OperationContract]
        void ActualizarSolicitud(VIPSolicitudes Solicitud);
        [OperationContract]
        List<VIMTipoDeRequerimiento> ListaTiposDeRequerimientos();
        [OperationContract]
        void RegistrarEquiposPorSolicitud(VIPSolicitudesPorEquipo Equipos);
        [OperationContract]
        List<VIPSolicitudesPorEquipo> ListaDeEquiposPorSolicitud(decimal IdSolicitud);
        [OperationContract]
        void EliminarEquiposPorSolicitud(decimal Id);
        [OperationContract]
        void ActualizarEquiposPorSolicitud(VIPSolicitudesPorEquipo Equipos);
        [OperationContract]
        VIPSolicitudesPorEquipo TraeEquipoPorId(int Id);
        [OperationContract]
        List<VIMTipoDeEquipos> ListaTipoDeEquipos();
        [OperationContract]
        bool ExisteSolicitudEscalada(decimal CuentaCliente);
        [OperationContract]
        List<VIPSolicitudes> ConsultaSolicitudesPorCliente(decimal CuentaCliente);
        [OperationContract]
        List<VIPSolicitudes> ConsultaAdminSolicitudesPrincipal(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        List<VILSolicitudes> ListaDeInteraccionesPorSolicitud(decimal IdSolicitud);
        [OperationContract]
        VIPSolicitudes ApartarCuentaVerificacionInventario(decimal Cedula, int noRecursividad);
        [OperationContract]
        VIPSolicitudes ConsultarSolicitudPorIdInventario(decimal Id);
        [OperationContract]
        List<VIMGestion> ListaDeGestion();
        [OperationContract]
        List<VIMSubrazon> ListaSubrazon(decimal IdGestion);
        [OperationContract]
        List<VIMAliadoTecnico> ListaAliadosTecnicos();
        [OperationContract]
        VIMSubrazon TraeSubrazonporIdGestion(int Id);
        [OperationContract]
        List<VIPSolicitudes> SolicitudesEnSeguimiento(decimal Usuario);
        [OperationContract]
        List<VILSolicitudes> ConsultaDeGestionBack(decimal Cedula, DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        List<VILSolicitudes> ConsultaAdminSolicitudesLog(DateTime FechaInicial, DateTime FechaFinal);
        //procesos admin
        [OperationContract]
        List<VIMTipoDeRequerimiento> ListaTiposDeRequerimientosAdmin();
        [OperationContract]
        List<VIMTipoDeEquipos> ListaTipoDeEquiposAdmin();
        [OperationContract]
        List<VIMGestion> ListaDeGestionAdmin();
        [OperationContract]
        List<VIMSubrazon> ListaSubrazonAdmin(decimal IdGestion);
        [OperationContract]
        List<VIMAliadoTecnico> ListaAliadosTecnicosAdmin();
        [OperationContract]
        void AgregarTiposDeRequerimientos(VIMTipoDeRequerimiento TipoRequerimiento);
        [OperationContract]
        void ActualizarTiposDeRequerimientos(VIMTipoDeRequerimiento TipoRequerimiento);
        [OperationContract]
        void AgregarTipoDeEquipos(VIMTipoDeEquipos TipoEquipos);
        [OperationContract]
        void ActualizarTipoDeEquipos(VIMTipoDeEquipos TipoEquipos);
        [OperationContract]
        void AgregarGestion(VIMGestion Gestion);
        [OperationContract]
        void ActualizarGestion(VIMGestion Gestion);
        [OperationContract]
        void AgregarSubrazon(VIMSubrazon DataSubrazon);
        [OperationContract]
        void ActualizarSubrazon(VIMSubrazon DataSubrazon);
        [OperationContract]
        void AgregarAliadoTecnico(VIMAliadoTecnico DataAliado);
        [OperationContract]
        void ActualizarAliadoTecnico(VIMAliadoTecnico DataAliado);
    }
}
