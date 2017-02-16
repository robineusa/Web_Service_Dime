using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Business
{
    public class GraficosBusiness
    {
        public List<Graficos> GraficoTrasladosGeneralAsesor(string UsuarioOut)
        {
            DimeContext dimContext = new DimeContext();
            List<Graficos> result = new List<Graficos>();
            DateTime FechaActual = DateTime.Now;
            
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 where a.UsuarioApertura.Equals(UsuarioOut) && (  a.FechaApertura >=DateTime.Now ) 
                                 group a by new { a.UsuarioApertura, a.TipoGestion } into grupo1
                                 select grupo1
                                 );

            foreach (var grupo1 in objetosResult)
            {
                Graficos grafico = new Graficos();
                grafico.Usuario = grupo1.Key.UsuarioApertura;
                grafico.TipoGestion = grupo1.Key.TipoGestion;
                grafico.Total = grupo1.Count();
                result.Add(grafico);

            }
            return result;

        }
        public List<Graficos> GraficoAsesorIngresosSac(string UsuarioOut)
        {
            DimeContext dimContext = new DimeContext();
            List<Graficos> result = new List<Graficos>();
            var objetosResult = (from a in dimContext.Ingresoes
                                 where a.UsuarioApertura.Equals(UsuarioOut)
                                 group a by new { a.UsuarioApertura, a.Macroproceso } into grupo1
                                 select grupo1
                                 );

            foreach (var grupo1 in objetosResult)
            {
                Graficos grafico = new Graficos();
                grafico.Usuario = grupo1.Key.UsuarioApertura;
                grafico.TipoGestion = grupo1.Key.Macroproceso;
                grafico.Total = grupo1.Count();
                result.Add(grafico);

            }
            return result;

        }
        public List<Graficos> GraficoAsesorNotasIngresosSac(string UsuarioOut)
        {
            DimeContext dimContext = new DimeContext();
            List<Graficos> result = new List<Graficos>();
            var objetosResult = (from a in dimContext.NotasIngresoes
                                 where a.Usuario.Equals(UsuarioOut)
                                 group a by new { a.Usuario } into grupo1
                                 select grupo1
                                 );

            foreach (var grupo1 in objetosResult)
            {
                Graficos grafico = new Graficos();
                grafico.Usuario = grupo1.Key.Usuario;
                grafico.Total = grupo1.Count();
                result.Add(grafico);

            }
            return result;

        }

    }
}
