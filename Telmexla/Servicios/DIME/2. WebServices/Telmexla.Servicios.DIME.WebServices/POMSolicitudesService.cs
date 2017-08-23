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
    public class POMSolicitudesService : IPOMSolicitudesService
    {
        public void RegistrarSolicitudPom(POMSolicitudes Solicitud)
        {
            POMSolicitudesBusiness PomBussines = new POMSolicitudesBusiness();
            PomBussines.RegistrarSolicitudPom(Solicitud);
        }
        public bool ValidarCuentaEnBaseSolicitudesPom(decimal CuentaCliente)
        {
            POMSolicitudesBusiness PomBussines = new POMSolicitudesBusiness();
            return PomBussines.ValidarCuentaEnBaseSolicitudesPom(CuentaCliente);
        }
        public List<POMSolicitudes> ListaSolicitudesPom(DateTime FechaInicial, DateTime FechaFinal)
        {
            POMSolicitudesBusiness PomBussines = new POMSolicitudesBusiness();
            return PomBussines.ListaSolicitudesPom(FechaInicial,FechaFinal);
        }
    }
}
