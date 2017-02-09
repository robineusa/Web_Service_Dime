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
    public interface INotificacionesBuenServicioService
    {
        [OperationContract]
        void RegistrarNotificado(NotificacionesBuenServicio notificacion);

        [OperationContract]
        NotificacionesBuenServicioCollection ListaImagenesBuenServicio();

        [OperationContract]
        NotificacionesBuenServicio ImagenporId(int id);

    }
}
