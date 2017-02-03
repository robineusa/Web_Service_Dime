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
    public class NotificaionesBuenServicioService : INotificacionesBuenServicioService
    {
        public void RegistrarNotificado(NotificacionesBuenServicio notificacion)
        {
            NotificacionesBuenServicioBusiness notificacionbusiness = new NotificacionesBuenServicioBusiness();
            notificacionbusiness.Registrarnotificado(notificacion);
        }
    }
}
