using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class MarcacionesBusiness
    {
        public void RegistrarNuevaMarcacion(MaestroMarcacione marcacion) {
            string nuevo = Regex.Replace(marcacion.QueHacerHtml, "<.*?>", String.Empty);
            nuevo = Regex.Replace(nuevo, "\\r", String.Empty);
            nuevo = Regex.Replace(nuevo, "\\t", " ");
            nuevo = Regex.Replace(nuevo, "\\n", " ");
            nuevo = Regex.Replace(nuevo, "&nbsp;", " ");
            nuevo = Regex.Replace(nuevo, "&otilde;", String.Empty);
            marcacion.QueHacer = nuevo;
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            unitOfWork.maestroMarcaciones.Add(marcacion);
            unitOfWork.Complete();
        }




        public MaestroMarcacioneCollection ObtenerMarcacionesPorPalabra(string key )
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
           return  unitOfWork.maestroMarcaciones.EncontrarPosiblesMarcaciones(key);
        }


         public MaestroMarcacione ObtenerMarcacionPorId(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.maestroMarcaciones.Get(id);
        }

        public MaestroMarcacioneCollection ObtenerListaMarcaciones()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<MaestroMarcacione> listaMarcaciones =unitOfWork.maestroMarcaciones.GetAll().ToList();
            MaestroMarcacioneCollection listaEnTipoDato = new MaestroMarcacioneCollection();
            listaEnTipoDato.AddRange(listaMarcaciones); 
            return listaEnTipoDato ;

        }

        public void RemoverMarcacion(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
 
            unitOfWork.maestroMarcaciones.Remove(unitOfWork.maestroMarcaciones.Get(id));
            unitOfWork.Complete();
        }

        public MaestroMarcacione GetMarcacionDeId(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
           return unitOfWork.maestroMarcaciones.Get(id);
        }

        public void ActualizarMarcacion(MaestroMarcacione marcacion)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            MaestroMarcacione marcacionActualizable = unitOfWork.maestroMarcaciones.Get(marcacion.Id);
            marcacionActualizable.AreaResponsable = marcacion.AreaResponsable;
            marcacionActualizable.AreayUsuarioEscala = marcacion.AreayUsuarioEscala;
            marcacionActualizable.Canal = marcacion.Canal;
            marcacionActualizable.CanalHabilitado = marcacion.CanalHabilitado;
            marcacionActualizable.CantidadDias = marcacion.CantidadDias;
            marcacionActualizable.Clase = marcacion.Clase;
            marcacionActualizable.Descripcion = marcacion.Descripcion;
            marcacionActualizable.EstadoMarcacion = marcacion.EstadoMarcacion;
            marcacionActualizable.FechaActualizacion = DateTime.Now;
            marcacionActualizable.Macroproceso = marcacion.Macroproceso;
            marcacionActualizable.PosibleCausa = marcacion.PosibleCausa;
            marcacionActualizable.Qmf = marcacion.Qmf;
            string nuevo = Regex.Replace(marcacion.QueHacerHtml, "<.*?>", String.Empty);
            nuevo = Regex.Replace(nuevo, "\\r", String.Empty);
            nuevo = Regex.Replace(nuevo, "\\t", " ");
            nuevo = Regex.Replace(nuevo, "\\n", " ");
            nuevo = Regex.Replace(nuevo, "&nbsp;", " ");
            nuevo = Regex.Replace(nuevo, "&otilde;", String.Empty);
            marcacionActualizable.QueHacer = nuevo;
            marcacionActualizable.QueHacerHtml = marcacion.QueHacerHtml;
            marcacionActualizable.QuienFinaliza = marcacion.QuienFinaliza;
            marcacionActualizable.Razon = marcacion.Razon;
            marcacionActualizable.ReporteTrimestral = marcacion.ReporteTrimestral;
            marcacionActualizable.Responsable = marcacion.Responsable;
            marcacionActualizable.Servicios = marcacion.Servicios;
            marcacionActualizable.Spc = marcacion.Spc;
            marcacionActualizable.Submarcacion = marcacion.Submarcacion;
            marcacionActualizable.Subrazon = marcacion.Subrazon;
            marcacionActualizable.TipologiasCun = marcacion.TipologiasCun;
            marcacionActualizable.TipoMarcacion = marcacion.TipoMarcacion;
            marcacionActualizable.UsuarioActualizacion = marcacion.UsuarioCreacion;
            unitOfWork.Complete();

        }

        public PqrMaestroCodCierre GetCodigoCierrePorId(int idCierre)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
           return  unitWork.pqrMaestroCodigos.Get(idCierre);
        }

        public PqrMaestroCodCierre GetCodigosCierreTotal(int idCierre)
        {
            throw new NotImplementedException();
        }

        public void UpdateCodigoCierre(PqrMaestroCodCierre codigoCierre)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            PqrMaestroCodCierre codAActualizar =   unitWork.pqrMaestroCodigos.Get(codigoCierre.Id);
            codAActualizar.Clase = codigoCierre.Clase;
            codAActualizar.CodigoCierre = codigoCierre.CodigoCierre;
            codAActualizar.CodigoRr = codigoCierre.CodigoRr;
            codAActualizar.Producto = codigoCierre.Producto;
            codAActualizar.Razon = codigoCierre.Razon;
            codAActualizar.ReporteSic = codigoCierre.ReporteSic;
            codAActualizar.SubRazon = codigoCierre.SubRazon;
            unitWork.Complete();
        }

        public void InsertCodigoCierre(PqrMaestroCodCierre codigoCierre)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.pqrMaestroCodigos.Add(codigoCierre);
            unitWork.Complete();
        }

        public void EliminarCodigoCierre(int id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.pqrMaestroCodigos.Remove(unitWork.pqrMaestroCodigos.Get(id));
            unitWork.Complete();
        }

        public PqrMaestroCodCierreCollection GetCodigosCierreTotal()
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            PqrMaestroCodCierreCollection result = new PqrMaestroCodCierreCollection();
            result.AddRange(unitWork.pqrMaestroCodigos.GetAll().ToList());
            return result;
        }

        public List<string> GetListraNombreCodigo( string submarcacion)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<string> result = unitOfWork.pqrMaestroCodigos.Find(c => c.SubRazon.Equals(submarcacion)).Select(x=>x.CodigoCierre).ToList();
            List<double?> resultCodigos  = unitOfWork.pqrMaestroCodigos.Find(c => c.SubRazon.Equals(submarcacion)).Select(x => x.CodigoRr).ToList();

            for(int i = 0; i< result.Count;i++)
            {
                result[i] = "Codigo RR: " + resultCodigos[i] + ". Descripción: " + result[i]+".";
            }
            return result;
        }

        public int GetIdMarcacion(string nombre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
           return   unitOfWork.maestroMarcaciones.Find(c => c.Submarcacion.Equals(nombre)).Select(x => x.Id).SingleOrDefault();
         
        }

    }
}
