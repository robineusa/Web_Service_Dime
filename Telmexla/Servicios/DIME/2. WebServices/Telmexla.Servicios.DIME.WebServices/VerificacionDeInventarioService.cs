using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class VerificacionDeInventarioService : IVerificacionDeInventarioService
    {
        public decimal ReistrarSolicitud(VIPSolicitudes Solicitud)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ReistrarSolicitud(Solicitud);
        }
        public void ActualizarSolicitud(VIPSolicitudes Solicitud)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.ActualizarSolicitud(Solicitud);
        }
        public List<VIMTipoDeRequerimiento> ListaTiposDeRequerimientos()
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaTiposDeRequerimientos();
        }
        public void RegistrarEquiposPorSolicitud(VIPSolicitudesPorEquipo Equipos)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.RegistrarEquiposPorSolicitud(Equipos);
        }
        public List<VIPSolicitudesPorEquipo> ListaDeEquiposPorSolicitud(decimal IdSolicitud)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaDeEquiposPorSolicitud(IdSolicitud);
        }
        public void EliminarEquiposPorSolicitud(decimal Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.EliminarEquiposPorSolicitud(Id);
        }
        public void ActualizarEquiposPorSolicitud(VIPSolicitudesPorEquipo Equipos)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.ActualizarEquiposPorSolicitud(Equipos);
        }
        public VIPSolicitudesPorEquipo TraeEquipoPorId(int Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.TraeEquipoPorId(Id);
        }
        public List<VIMTipoDeEquipos> ListaTipoDeEquipos()
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaTipoDeEquipos();
        }
        public bool ExisteSolicitudEscalada(decimal CuentaCliente)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ExisteSolicitudEscalada(CuentaCliente);
        }
        public List<VIPSolicitudes> ConsultaSolicitudesPorCliente(decimal CuentaCliente)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ConsultaSolicitudesPorCliente(CuentaCliente);

        }
        public List<VIPSolicitudes> ConsultaAdminSolicitudesPrincipal(DateTime FechaInicial, DateTime FechaFinal)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ConsultaAdminSolicitudesPrincipal(FechaInicial,FechaFinal);
        }
        public List<VILSolicitudes> ListaDeInteraccionesPorSolicitud(decimal IdSolicitud)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaDeInteraccionesPorSolicitud(IdSolicitud);
        }
        public VIPSolicitudes ApartarCuentaVerificacionInventario(decimal Cedula, int noRecursividad)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ApartarCuentaVerificacionInventario(Cedula,noRecursividad);
        }
        public VIPSolicitudes ConsultarSolicitudPorIdInventario(decimal Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ConsultarSolicitudPorIdInventario(Id);
        }
        public List<VIMGestion> ListaDeGestion()
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaDeGestion();
        }
        public List<VIMSubrazon> ListaSubrazon(decimal IdGestion)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaSubrazon(IdGestion);
        }
        public List<VIMAliadoTecnico> ListaAliadosTecnicos()
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaAliadosTecnicos();
        }
        public VIMSubrazon TraeSubrazonporIdGestion(int Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.TraeSubrazonporIdGestion(Id);
        }
        public List<VIPSolicitudes> SolicitudesEnSeguimiento(decimal Usuario)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.SolicitudesEnSeguimiento(Usuario);
        }
        public List<VILSolicitudes> ConsultaDeGestionBack(decimal Cedula, DateTime FechaInicial, DateTime FechaFinal)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ConsultaDeGestionBack(Cedula,FechaInicial,FechaFinal);
        }
        public List<VILSolicitudes> ConsultaAdminSolicitudesLog(DateTime FechaInicial, DateTime FechaFinal)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ConsultaAdminSolicitudesLog(FechaInicial, FechaFinal);
        }
        //procesos admin
        public List<VIMTipoDeRequerimiento> ListaTiposDeRequerimientosAdmin()
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaTiposDeRequerimientosAdmin();
        }
        public List<VIMTipoDeEquipos> ListaTipoDeEquiposAdmin()
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaTipoDeEquiposAdmin();
        }
        public List<VIMGestion> ListaDeGestionAdmin()
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaDeGestionAdmin();
        }
        public List<VIMSubrazon> ListaSubrazonAdmin(decimal IdGestion)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaSubrazonAdmin(IdGestion);
        }
        public List<VIMAliadoTecnico> ListaAliadosTecnicosAdmin()
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ListaAliadosTecnicosAdmin();
        }
        public void AgregarTiposDeRequerimientos(VIMTipoDeRequerimiento TipoRequerimiento)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.AgregarTiposDeRequerimientos(TipoRequerimiento);
        }
        public void ActualizarTiposDeRequerimientos(VIMTipoDeRequerimiento TipoRequerimiento)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.ActualizarTiposDeRequerimientos(TipoRequerimiento);
        }
        public void AgregarTipoDeEquipos(VIMTipoDeEquipos TipoEquipos)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.AgregarTipoDeEquipos(TipoEquipos);
        }
        public void ActualizarTipoDeEquipos(VIMTipoDeEquipos TipoEquipos)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.ActualizarTipoDeEquipos(TipoEquipos);
        }
        public void AgregarGestion(VIMGestion Gestion)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.AgregarGestion(Gestion);
        }
        public void ActualizarGestion(VIMGestion Gestion)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.ActualizarGestion(Gestion);
        }
        public void AgregarSubrazon(VIMSubrazon DataSubrazon)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.AgregarSubrazon(DataSubrazon);
        }
        public void ActualizarSubrazon(VIMSubrazon DataSubrazon)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.ActualizarSubrazon(DataSubrazon);
        }
        public void AgregarAliadoTecnico(VIMAliadoTecnico DataAliado)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.AgregarAliadoTecnico(DataAliado);
        }
        public void ActualizarAliadoTecnico(VIMAliadoTecnico DataAliado)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            VerificacionInventarioBusiness.ActualizarAliadoTecnico(DataAliado);

        }
        public VIMTipoDeRequerimiento TipoDeRequerimientoPorId(int Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.TipoDeRequerimientoPorId(Id);
        }
        public VIMTipoDeEquipos TipoDeEquiposPorId(int Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.TipoDeEquiposPorId(Id);
        }
        public VIMGestion GestionPorId(int Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.GestionPorId(Id);
        }
        public VIMSubrazon SubrazonPorId(int Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.SubrazonPorId(Id);
        }
        public VIMAliadoTecnico AliadoTecnicoPorId(int Id)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.AliadoTecnicoPorId(Id);
        }
     }
}
