using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.IData;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class ArbolesDeTipificacion
    {

        public MaestroOutboundTipoContactoCollection GetTipoContactosPorGestion(decimal gestionId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            List<MaestroOutboundTipoContacto> tiposContacto = unitOfWork.maestrosOutboundTipoContactos.Find(c => c.IdTipoGestion == gestionId).ToList();
            MaestroOutboundTipoContactoCollection result = new MaestroOutboundTipoContactoCollection();
            result.AddRange(tiposContacto);
            return result;
        }



        public MaestroOutboundCierreCollection GetTipoCierrePorContacto(decimal contactoId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            MaestroOutboundCierreCollection result = new MaestroOutboundCierreCollection();
            result.AddRange(unitOfWork.maestrosOutboundCierres.Find(c => c.IdTipoContacto == contactoId).ToList());
            return result;

        }




        public MaestroOutboundRazonCollection GetTipoRazonPorTipoCierre(decimal cierreId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            MaestroOutboundRazonCollection result = new MaestroOutboundRazonCollection();
            result.AddRange(unitOfWork.maestrosOutboundRazon.Find(c => c.IdCierre  == cierreId).ToList());
            return result;

        }



        public MaestroOutboundCausaCollection GetTipoCausanPorTipoRazon(decimal razonId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            MaestroOutboundCausaCollection result = new MaestroOutboundCausaCollection();
            result.AddRange(unitOfWork.maestrosOutboundCausa.Find(c => c.IdRazon == razonId).ToList());
            return result;

        }

        public MaestroOutboundMotivoCollection GetTipoMotivoPorTipoCausa(decimal causaId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            MaestroOutboundMotivoCollection result = new MaestroOutboundMotivoCollection();
            result.AddRange(unitOfWork.maestrosOutboundMotivo.Find(c => c.IdCausa == causaId).ToList());
            return result;

        }

        public List<RazonIngresoSoporte> GetRazonesDeSoporteIngreso()
        {
            DimeContext dimContext = new DimeContext();
            return dimContext.RazonIngresoSoportes.ToList();
        }

        public List<Subrazon1IngresoSoporte> GetSubrazonDeRazonSoporteIngresos(int idRazon)
        {
            DimeContext context = new DimeContext();
           return  context.Subrazon1IngresoSoporte.Where(c => c.IdRazon == idRazon).ToList();
        }

        public List<Subrazon2IngresoSoporte> GetSubrazones2DeSubrazon1SoporteIngresos(int idSubrazon1)
        {
            DimeContext context = new DimeContext();
            return context.Subrazon2IngresoSoporte.Where(c => c.IdSubrazon1== idSubrazon1).ToList();
        }
        //Departamentos
        public List<Departamento> TraeListaDepartamentos()
        {
            DimeContext dimContext = new DimeContext();
            List<Departamento> result = new List<Departamento>();
            var objetosResult = (from a in dimContext.Departamentos
                                 orderby a.NombreDepartamento ascending
                                 select new{ a.NombreDepartamento } 
                                 ).Distinct().ToList();
            
            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new Departamento());
                result[i].NombreDepartamento = objetosResult[i].NombreDepartamento;
            }
            result = result.OrderBy(m => m.NombreDepartamento).ToList();
            return result;
        }
        public List<Departamento> TraeListaCiudades(string Departamento) {

            DimeContext dimContext = new DimeContext();
            List<Departamento> result = new List<Departamento>();
            var objetosResult = (from a in dimContext.Departamentos
                                 where a.NombreDepartamento == Departamento
                                 orderby a.NombreComunidad ascending
                                 select new { a.NombreComunidad }
                                 ).Distinct().ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new Departamento());
                result[i].NombreComunidad = objetosResult[i].NombreComunidad;
            }
            return result;
        }
        public List<Departamento> TraeListaComunidad(string Departamento, string NombreComunidad)
        {
            DimeContext dimContext = new DimeContext();
            List<Departamento> result = new List<Departamento>();
            var objetosResult = (from a in dimContext.Departamentos
                                 where a.NombreDepartamento == Departamento && a.NombreComunidad== NombreComunidad
                                 orderby a.Comunidad ascending
                                 select new { a.Comunidad }
                                 ).Distinct().ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new Departamento());
                result[i].Comunidad = objetosResult[i].Comunidad;
            }
            return result;
        }
        public List<Departamento> TraeListaRed(string Departamento, string NombreComunidad, string Comunidad)
        {
            DimeContext dimContext = new DimeContext();
            List<Departamento> result = new List<Departamento>();
            var objetosResult = (from a in dimContext.Departamentos
                                 where a.NombreDepartamento == Departamento && a.NombreComunidad == NombreComunidad && a.Comunidad== Comunidad
                                 orderby a.Red ascending
                                 select new { a.Red }
                                 ).Distinct().ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new Departamento());
                result[i].Red = objetosResult[i].Red;
            }
            return result;
        }
        public List<MaestroLineasBlending> GetLineasBlending(string Aliado)
        {
            MaestrosContext MaestContext = new MaestrosContext();
            return MaestContext.MaestroLineasBlending.Where(a=> a.Aliado == Aliado).ToList();
        }
    }
}
