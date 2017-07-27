using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
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

        public void SetGestionResidencialPredictivo(CcGestionResidencialPredictivo gestionResdPred)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.CcGestionResidencialPredictivo.Add(gestionResdPred);
        }

        public CcBaseMejoramiento GetBaseMejoramientoDeResdPredInfo(double cuenta, string problemaEdAMotivo, DateTime ultimaFechaDeCuenta)
        {
            DimeContext dimContext = new DimeContext();
            CcBaseMejoramiento resultado = dimContext.CcBaseMejoramientoes.Where(c => c.Cuenta == cuenta
                                   && c.Motivo.Equals(problemaEdAMotivo) && c.Fecha == ultimaFechaDeCuenta).FirstOrDefault();
            return resultado;
        }

        public DateTime GetUltimaFechaDeCuentaBaseMejora(double cuenta, string problemaEdAMotivo)
        {
            DimeContext dimContext = new DimeContext();
            DateTime? resultado = dimContext.CcBaseMejoramientoes.Where(c=>c.Cuenta==cuenta && c.Motivo.Equals(problemaEdAMotivo)).OrderByDescending(x => x.Fecha).First().Fecha;
            return Convert.ToDateTime(resultado);
        }

        public CcResidencialPredictivoInfo RecibirResidencialPredictivoInfoPorId(int id)
        {
            DimeContext dimContext = new DimeContext();
            CcResidencialPredictivoInfo result = new CcResidencialPredictivoInfo();
            result = dimContext.CcResidencialPredictivoInfoes.Where(c => c.Id == id).FirstOrDefault();
            return result;
        }

  
    }
}
