using System;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.IWebServices;
namespace Telmexla.Servicios.DIME.WebServices
{
   public class DiasFestivosService: IDiasFestivosService
    {
        public string ConsultarDiasFestivos(string FechaInicio, int Dias)
        {
            DiasFestivosBusiness ConsultarDiasFestivos = new DiasFestivosBusiness();
            return ConsultarDiasFestivos.ConsultarDiasFestivos(FechaInicio, Dias);
        }
    }
}
