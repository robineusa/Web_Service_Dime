using System.ServiceModel;
using System;



namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IDiasFestivosService
    {
        [OperationContract]
        string ConsultarDiasFestivos(DateTime FechaInicio, int Dias);
    }
}
