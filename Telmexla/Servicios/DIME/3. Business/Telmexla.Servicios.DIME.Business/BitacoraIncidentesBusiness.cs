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
    public class BitacoraIncidentesBusiness
    {
        public void RegistrarIncidente(BIPBitacoraIncidentes Bitacora)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.BIPBitacoraIncidentes.Add(Bitacora);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public List<BIMGerencias> ListaDeGerencias()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMGerencias> result = new List<BIMGerencias>();
            var objetosResult = (from a in dimContext.BIMGerencias
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.NombreGerencia ascending
                                 select new
                                 {
                                     a.IdGerencia,
                                     a.NombreGerencia

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMGerencias());
                result[i].IdGerencia = objetosResult[i].IdGerencia;
                result[i].NombreGerencia = objetosResult[i].NombreGerencia;

            }
            return result;
        }
        public List<BIMAliados> ListaDeAliados()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMAliados> result = new List<BIMAliados>();
            var objetosResult = (from a in dimContext.BIMAliados
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.NombreAliado ascending
                                 select new
                                 {
                                     a.IdAliado,
                                     a.NombreAliado

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMAliados());
                result[i].IdAliado = objetosResult[i].IdAliado;
                result[i].NombreAliado = objetosResult[i].NombreAliado;

            }
            return result;
        }
        public List<BIMOperaciones> ListaOperaciones()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMOperaciones> result = new List<BIMOperaciones>();
            var objetosResult = (from a in dimContext.BIMOperaciones
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.NombreOperacion ascending
                                 select new
                                 {
                                     a.IdOperacion,
                                     a.IdGerencia,
                                     a.IdAliado,
                                     a.NombreOperacion

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMOperaciones());
                result[i].IdOperacion = objetosResult[i].IdOperacion;
                result[i].IdGerencia = objetosResult[i].IdGerencia;
                result[i].IdAliado = objetosResult[i].IdAliado;
                result[i].NombreOperacion = objetosResult[i].NombreOperacion;

            }
            return result;
        }
    }
}
