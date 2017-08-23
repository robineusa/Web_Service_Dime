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
    public interface IPOMSolicitudesService
    {
        [OperationContract]
        void RegistrarSolicitud(POMSolicitudes Solicitud);
        [OperationContract]
        bool ValidarCuentaEnBaseSolicitudesPom(decimal CuentaCliente);
        [OperationContract]
        List<POMSolicitudes> ListaSolicitudesPom(DateTime FechaInicial, DateTime FechaFinal);
    }
}
