using System;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.IWebServices;
namespace Telmexla.Servicios.DIME.WebServices
{
   public class DiasFestivosService: IDiasFestivosService
    {
        public int ConsultarDiasFestivos(DateTime FechaInicio, DateTime FechaFinal)
        {
            DiasFestivosBusiness ConsultarDiasFestivos = new DiasFestivosBusiness();
            return ConsultarDiasFestivos.ConsultarDiasFestivos(FechaInicio, FechaFinal);
        }
    }
}
