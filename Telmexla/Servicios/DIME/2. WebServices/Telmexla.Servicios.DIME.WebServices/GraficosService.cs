using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.WebServices;


namespace Telmexla.Servicios.DIME.WebServices
{
    public class GraficosService : IGraficosService
    {
        public List<Graficos> GraficoTrasladosGeneralAsesor(string UsuarioOut)
        {
            GraficosBusiness graficosbusi = new GraficosBusiness();
            return graficosbusi.GraficoTrasladosGeneralAsesor(UsuarioOut);
        }
        public List<Graficos> GraficoAsesorIngresosSac(string UsuarioOut)
        {
            GraficosBusiness graficosbusi = new GraficosBusiness();
            return graficosbusi.GraficoAsesorIngresosSac(UsuarioOut);
        }
        public List<Graficos> GraficoAsesorNotasIngresosSac(string UsuarioOut)
        {
            GraficosBusiness graficosbusi = new GraficosBusiness();
            return graficosbusi.GraficoAsesorNotasIngresosSac(UsuarioOut);
        }
    }
}
