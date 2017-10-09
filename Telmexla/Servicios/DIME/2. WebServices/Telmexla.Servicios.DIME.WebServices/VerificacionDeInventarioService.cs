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
        public List<VIPSolicitudes> ConsultaSolicitudesPorFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            VerificacionDeInventarioBusiness VerificacionInventarioBusiness = new VerificacionDeInventarioBusiness();
            return VerificacionInventarioBusiness.ConsultaSolicitudesPorFecha(FechaInicial,FechaFinal);
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
     }
}
