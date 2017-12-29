using System;
using System.Linq;
using Telmexla.Servicios.DIME.Data.Context;

namespace Telmexla.Servicios.DIME.Business
{
    public class DiasFestivosBusiness
    {
        public int ConsultarDiasFestivos(DateTime FechaInicio,DateTime FechaFinal)
        {
            string fechaInicial = FechaInicio.ToShortDateString();
            string fechaFinal = FechaFinal.ToShortDateString();
            string consulta = "SELECT COUNT(TIPO_DIA_LUNES_VIERNES) AS CANTIDAD FROM TMP_MAESTRO_FESTIVOS" +
                             " WHERE FECHA BETWEEN CONVERT(DATETIME,'28/12/2017', 103) AND CONVERT(DATETIME,'01/01/2018', 103) " +
                             " AND TIPO_DIA_LUNES_VIERNES = 0 ";


            MaestrosContext contexto = new MaestrosContext();
            var l = contexto.Database.SqlQuery<int>(consulta).FirstOrDefault();
            //" AND TIPO_DIA_LUNES_VIERNES = '0' " + " ").ToList();
            //" GROUP BY TIPO_DIA_LUNES_VIERNES").FirstOrDefault();
            int diasFestivos = Convert.ToInt32(l);
            return diasFestivos;
        }
    }
}
