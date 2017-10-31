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
    public interface IVisitasAutorizadasService
    {
        [OperationContract]
        void AgregarNuevaVisita(VisitasAutorizadas Visita);
        [OperationContract]
        List<VisitasAutorizadas> ConsultaBaseVisitasAutorizadas(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        List<VAMotivosSolicitud> ListaMotivosSolicitud();

    }
}
