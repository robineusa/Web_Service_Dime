using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface ISignalRService
    {
        [OperationContract]
        void InsertarNotificacionSignalR(NotificacionSignalR model);

        [OperationContract]
        List<NotificacionSignalR> ListaNoNotificados(decimal Usuario);

        [OperationContract]
        void InsertarUsuarioNotificadoSignalR(List<string> ListaNotificaciones, UsuariosNotificadosSignalR model);
    }
}
