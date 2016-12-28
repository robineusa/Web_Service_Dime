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
    public interface  ICasosAdminService
    {
        [OperationContract]
        IngresoCollection ListaIngresosPorTicketRr(string noTicket);


        [OperationContract]
        IngresoCollection ListaIngresosPorUsuarioCreacion(string ccUsuario);
    }
}
