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

     }
}
