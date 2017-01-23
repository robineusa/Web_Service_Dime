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
    public interface  ICasosAdminService
    {
        [OperationContract]
        IngresoCollection ListaIngresosPorTicketRr(string noTicket);


        [OperationContract]
        IngresoCollection ListaIngresosPorUsuarioCreacion(string ccUsuario);


        [OperationContract]
        List<DatoConsultaPaloteo> ListaPaloteo(DateTime inicial, DateTime final);

        [OperationContract]
        List<String> ListaAliadosActualesDeHolos();

        [OperationContract]
        List<DatoConsultaGestionAdmin> ListaGestionAdmin(DateTime inicial, DateTime final, string aliado); 

    }
}
