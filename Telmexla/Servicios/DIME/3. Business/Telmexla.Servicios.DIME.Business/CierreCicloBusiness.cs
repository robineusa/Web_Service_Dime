using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class CierreCicloBusiness
    {
        public List<DatoConsultaCCResidencialPredictivo> HistorialDeCuentaResidencialPredictivo(float cuenta)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaCCResidencialPredictivo> resultado = new List<DatoConsultaCCResidencialPredictivo>();
            var preResult = dimContext.CcResidencialPredictivoInfoes.Where(c=>c.Cuenta == cuenta).ToList();
            foreach(var item in preResult)
            {
                DatoConsultaCCResidencialPredictivo nuevoDato = new DatoConsultaCCResidencialPredictivo();
                nuevoDato.Id = item.Id;
                nuevoDato.Cuenta = item.Cuenta;
                nuevoDato.EstadoInicial = item.EstadoInicial;
                nuevoDato.MarcacionBd = item.MarcacionBd;
                nuevoDato.MarcacionBdIi = item.MarcacionBdIi;
                nuevoDato.Nombre = item.Nombre;
                nuevoDato.ProblemaDelEdificio = item.ProblemaDelEdificio;
                resultado.Add(nuevoDato);
            }

            foreach(var item in resultado)
            {
                if(dimContext.CcGestionResidencialPredictivoes.Where(c=>c.IdResdPredInfo == item.Id).Any())
                {
                    item.Verificado = true;
                }
                else { item.Verificado = false; }

            }

            return resultado;
        }
    }
}
