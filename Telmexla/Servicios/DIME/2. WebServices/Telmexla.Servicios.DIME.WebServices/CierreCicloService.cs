using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class CierreCicloService : ICierreCicloService
    {
        public List<DatoConsultaCCResidencialPredictivo> ListaResidencialPredictivoDeCuenta(float cuenta)
        {
            CierreCicloBusiness cierreCicloBusi = new CierreCicloBusiness();
           return  cierreCicloBusi.HistorialDeCuentaResidencialPredictivo(cuenta);
        }

        public CcResidencialPredictivoInfo GetResidencialPredictivoInfoPorId(int id)
        {
            CierreCicloBusiness cierreCicloBusi = new CierreCicloBusiness();
            return cierreCicloBusi.RecibirResidencialPredictivoInfoPorId(id);
        }

        public CcBaseMejoramiento RecibirBaseMejoramientoDeResdPredInfo(double cuenta, string problemaEdAMotivo)
        {
            CierreCicloBusiness cierreCicloBusi = new CierreCicloBusiness();
            DateTime ultimaFechaDeCuentaBaseMejora = cierreCicloBusi.GetUltimaFechaDeCuentaBaseMejora(cuenta, problemaEdAMotivo);
            return cierreCicloBusi.GetBaseMejoramientoDeResdPredInfo(cuenta, problemaEdAMotivo, ultimaFechaDeCuentaBaseMejora);
        }

        public void IngresarGestionResidencialPredictivo(CcGestionResidencialPredictivo gestionResdPred)
        {
            CierreCicloBusiness cierreCicloBusi = new CierreCicloBusiness();
            cierreCicloBusi.SetGestionResidencialPredictivo(gestionResdPred);
        }




    }
}
