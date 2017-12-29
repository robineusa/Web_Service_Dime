using System.ServiceModel;
using System;



namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IDiasFestivosService
    {
        [OperationContract]
        int ConsultarDiasFestivos(DateTime FechaInicio, DateTime FechaFinal);
    }
}
