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
    public class FidelizacionBusiness
    {
        public List<FidelizacionMaestroServicios> getMaestroServiciosAll() {
            DimeContext dimeContext = new DimeContext();
            List<FidelizacionMaestroServicios> objTmp = new List<FidelizacionMaestroServicios>();
            var listado = (from maestroServicio in dimeContext.FidelizacionMaestroServicios
                           orderby maestroServicio.Nombre ascending
                           select new {
                               maestroServicio.IdRetencion,
                               maestroServicio.IdServicio,
                               maestroServicio.Nombre
                           }
                           ).ToList();

            for (int i = 0; i < listado.Count; i++) {
                objTmp.Add(new FidelizacionMaestroServicios());
                objTmp[i].IdRetencion = listado[i].IdRetencion;
                objTmp[i].IdServicio = listado[i].IdServicio;
                objTmp[i].Nombre = listado[i].Nombre;
             }

            return objTmp;
            
        }

        public FidelizacionMaestroServicios getMaestroServiciosById(string codServicio) {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionMaestroServicios fila = unidadTrabajo.FidelizacionMaestroServicios.Find(c => c.IdServicio == codServicio).FirstOrDefault();
            return fila;
        }

        public void setMotivosCancelacion(FidelizacionMotivosCancelacion MotivoCancelacion) {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            unidadTrabajo.FidelizacionMotivosCancelacion.Add(MotivoCancelacion);
            unidadTrabajo.Complete();
            unidadTrabajo.Dispose();
        }

        public FidelizacionMotivosCancelacion getMotivosCancelacionById(decimal codMotivo)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionMotivosCancelacion fila = unidadTrabajo.FidelizacionMotivosCancelacion.Find(y => y.Id == codMotivo).FirstOrDefault();
            return fila;
        }
        public List<FidelizacionMotivosCancelacion> getMotivosCancelacionAll()
        {
            DimeContext dimeConext = new DimeContext();
            List<FidelizacionMotivosCancelacion> objTmp = new List<FidelizacionMotivosCancelacion>();
            var listado = (from motivosCancelacion in dimeConext.FidelizacionMotivosCancelacion
                           orderby motivosCancelacion.Motivo ascending
                           select new
                           {
                               motivosCancelacion.Id,
                               motivosCancelacion.Motivo,
                               motivosCancelacion.OtrosCampos,
                               motivosCancelacion.OtrosOfrecimientos,
                               motivosCancelacion.Registro,
                               motivosCancelacion.Eliminado
                           }
                           ).ToList();

            
            for (int i = 0; i < listado.Count; i++)
            {
                objTmp.Add(new FidelizacionMotivosCancelacion());
                objTmp[i].Id = listado[i].Id;
                objTmp[i].Motivo = listado[i].Motivo;
                objTmp[i].OtrosCampos = listado[i].OtrosCampos;
                objTmp[i].OtrosOfrecimientos = listado[i].OtrosOfrecimientos;
                objTmp[i].Eliminado = listado[i].Eliminado;
                objTmp[i].Registro = listado[i].Registro;
            }

            return objTmp;

        }

        public List<FidelizacionSubmotivosCancelacion> getSubmotivosCancelacionAll()
        {
            DimeContext dimeConext = new DimeContext();
            List<FidelizacionSubmotivosCancelacion> objTmp = new List<FidelizacionSubmotivosCancelacion>();
            var listado = (from submotivosCancelacion in dimeConext.FidelizacionSubmotivosCancelacion
                           orderby submotivosCancelacion.Submotivo ascending
                           select new
                           {
                               submotivosCancelacion.Id,
                               submotivosCancelacion.Submotivo,
                               submotivosCancelacion.FIDMotivoId,
                               submotivosCancelacion.Registro,
                               submotivosCancelacion.Eliminado
                           }
                           ).ToList();


            for (int i = 0; i < listado.Count; i++)
            {
                objTmp.Add(new FidelizacionSubmotivosCancelacion());
                objTmp[i].Id = listado[i].Id;
                objTmp[i].Submotivo = listado[i].Submotivo;
                objTmp[i].Eliminado = listado[i].Eliminado;
                objTmp[i].Registro = listado[i].Registro;
                objTmp[i].FIDMotivoId = listado[i].FIDMotivoId;
            }

            return objTmp;

        }

        public FidelizacionSubmotivosCancelacion getSubmotivosCancelacionById(decimal idSubmotivo) {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionSubmotivosCancelacion fila = unidadTrabajo.FidelizacionSubmotivosCancelacion.Find(c=>c.Id == idSubmotivo).FirstOrDefault();
            return fila;
        }

        public void setSubmotivoCancelacion(FidelizacionSubmotivosCancelacion ObjFidelizacion) {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            unidadTrabajo.FidelizacionSubmotivosCancelacion.Add(ObjFidelizacion);
            unidadTrabajo.Complete();
            unidadTrabajo.Dispose();
        }

    }
}
