using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class SignalRService
    {
        public void InsertarNotificacionSignalR(NotificacionSignalR model)
        {
            SignalRBusiness signalRBusiness = new SignalRBusiness();
            signalRBusiness.InsertarNotificacionSignalR(model);
        }
        public List<NotificacionSignalR> ListaNoNotificados(decimal Usuario)
        {
            SignalRBusiness signalRBusiness = new SignalRBusiness();
            return signalRBusiness.ListaNoNotificados(Usuario);
        }
        public void InsertarUsuarioNotificadoSignalR(List<string> ListaNotificaciones, UsuariosNotificadosSignalR model)
        {
            SignalRBusiness signalRBusiness = new SignalRBusiness();
            signalRBusiness.InsertarUsuarioNotificadoSignalR(ListaNotificaciones, model);
        }
    }
}
