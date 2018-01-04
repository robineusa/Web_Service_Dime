using System;
using System.Linq;
using System.Globalization;
using Telmexla.Servicios.DIME.Data.Context;

namespace Telmexla.Servicios.DIME.Business
{
    public class DiasFestivosBusiness
    {
        public string ConsultarDiasFestivos(string FechaInicio,int Dias)
        {
            //string fechaInicial = FechaInicio.ToShortDateString();
            //string fechaInicial = FechaInicio.ToString(@"dd/MM/yyyy", new CultureInfo("en-US"));

            string consulta = string.Format("SELECT dbo.CONSULTAR_DIAS_HABILES(CONVERT(DATETIME,'{0}'),{1});", FechaInicio, Dias);


            MaestrosContext contexto = new MaestrosContext();
            var sql = contexto.Database.SqlQuery<string>(consulta).FirstOrDefault();
            //" AND TIPO_DIA_LUNES_VIERNES = '0' " + " ").ToList();
            //" GROUP BY TIPO_DIA_LUNES_VIERNES").FirstOrDefault();

            //string diasFestivos = sql.ToString();
            //string diasFestivos = sql.ToShortDateString();
            //string diasFestivos = sql.ToString(@"dd/MM/yyyy", new CultureInfo("en-US"));
            return sql;
        }
    }
}

//string consulta = string.Format("SELECT COUNT(TIPO_DIA_LUNES_VIERNES) AS CANTIDAD FROM TMP_MAESTRO_FESTIVOS" +
//                 " WHERE FECHA BETWEEN CONVERT(DATETIME,{0}, 103) AND CONVERT(DATETIME,{1}, 103) " +
//                 " AND TIPO_DIA_LUNES_VIERNES = 0 ", fechaInicial, fechaFinal);