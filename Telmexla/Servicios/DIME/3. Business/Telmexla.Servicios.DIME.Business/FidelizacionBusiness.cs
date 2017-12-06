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
        public List<FidelizacionMaestroServicios> getMaestroServiciosAll()
        {
            DimeContext dimeContext = new DimeContext();
            List<FidelizacionMaestroServicios> objTmp = new List<FidelizacionMaestroServicios>();
            var listado = (from maestroServicio in dimeContext.FidelizacionMaestroServicios
                           orderby maestroServicio.Nombre ascending
                           select new
                           {
                               maestroServicio.IdRetencion,
                               maestroServicio.IdServicio,
                               maestroServicio.Nombre
                           }
                           ).ToList();

            for (int i = 0; i < listado.Count; i++)
            {
                objTmp.Add(new FidelizacionMaestroServicios());
                objTmp[i].IdRetencion = listado[i].IdRetencion;
                objTmp[i].IdServicio = listado[i].IdServicio;
                objTmp[i].Nombre = listado[i].Nombre;
            }

            return objTmp;

        }

        public FidelizacionMaestroServicios getMaestroServiciosById(string codServicio)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionMaestroServicios fila = unidadTrabajo.FidelizacionMaestroServicios.Find(c => c.IdServicio == codServicio).FirstOrDefault();
            return fila;
        }

        public void setMotivosCancelacion(FidelizacionMotivosCancelacion MotivoCancelacion)
        {
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
        public List<FidelizacionMotivosCancelacion> getMotivosCancelacionAll(decimal eliminado)
        {
            DimeContext dimeConext = new DimeContext();
            List<FidelizacionMotivosCancelacion> objTmp = new List<FidelizacionMotivosCancelacion>();
            var listado = (from motivosCancelacion in dimeConext.FidelizacionMotivosCancelacion
                           where motivosCancelacion.Eliminado == eliminado
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

        public List<FidelizacionSubmotivosCancelacionDetalle> getSubmotivosCancelacionAll(decimal estado, decimal idMotivo)
        {
            DimeContext dimeConext = new DimeContext();
            List<FidelizacionSubmotivosCancelacionDetalle> objTmp = new List<FidelizacionSubmotivosCancelacionDetalle>();
            var listado = (from submotivosCancelacion in dimeConext.FidelizacionSubmotivosCancelacion
                           join b in (from m in dimeConext.FidelizacionMotivosCancelacion select new { m.Id, m.Motivo }).Distinct() on submotivosCancelacion.FIDMotivoId equals b.Id
                           where submotivosCancelacion.Eliminado == estado 
                           orderby submotivosCancelacion.Submotivo ascending
                           select new
                           {
                               submotivosCancelacion.Id,
                               submotivosCancelacion.Submotivo,
                               submotivosCancelacion.FIDMotivoId,
                               submotivosCancelacion.Registro,
                               submotivosCancelacion.Eliminado,
                               b.Motivo
                           }
                           ).ToList();

            var j = 0;
            for (int i = 0; i < listado.Count; i++)
            {
                if (idMotivo == 0)
                {
                    objTmp.Add(new FidelizacionSubmotivosCancelacionDetalle());
                    objTmp[i].Id = listado[i].Id;
                    objTmp[i].Submotivo = listado[i].Submotivo;
                    objTmp[i].Eliminado = listado[i].Eliminado;
                    objTmp[i].Registro = listado[i].Registro;
                    objTmp[i].FIDMotivoId = listado[i].FIDMotivoId;
                    objTmp[i].NombreMotivo = listado[i].Motivo;
                }
                else if (listado[i].FIDMotivoId == idMotivo) {
                    objTmp.Add(new FidelizacionSubmotivosCancelacionDetalle());
                    objTmp[j].Id = listado[i].Id;
                    objTmp[j].Submotivo = listado[i].Submotivo;
                    objTmp[j].Eliminado = listado[i].Eliminado;
                    objTmp[j].Registro = listado[i].Registro;
                    objTmp[j].FIDMotivoId = listado[i].FIDMotivoId;
                    objTmp[j].NombreMotivo = listado[i].Motivo;
                    j++;
                }
            }

            return objTmp;

        }

        public FidelizacionSubmotivosCancelacion getSubmotivosCancelacionById(decimal idSubmotivo)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionSubmotivosCancelacion fila = unidadTrabajo.FidelizacionSubmotivosCancelacion.Find(c => c.Id == idSubmotivo).FirstOrDefault();
            return fila;
        }

        public void setSubmotivoCancelacion(FidelizacionSubmotivosCancelacion ObjFidelizacion)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            unidadTrabajo.FidelizacionSubmotivosCancelacion.Add(ObjFidelizacion);
            unidadTrabajo.Complete();
            unidadTrabajo.Dispose();
        }

        public void setOtrosOfrecimientos(FidelizacionOtrosOfrecimientos ObjOfrecimientos)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            unidadTrabajo.FidelizacionOtrosOfrecimientos.Add(ObjOfrecimientos);
            unidadTrabajo.Complete();
            unidadTrabajo.Dispose();
        }

        public FidelizacionOtrosOfrecimientos getOtrosOfrecimientosById(decimal idOfrecimiento)
        {
            UnitOfWork UnidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionOtrosOfrecimientos fila = UnidadTrabajo.FidelizacionOtrosOfrecimientos.Find(c => c.Id == idOfrecimiento).FirstOrDefault();
            return fila;
        }

        public List<FidelizacionOtrosOfrecimientos> getOtrosOfrecimientosAll()
        {
            DimeContext dimeContex = new DimeContext();
            List<FidelizacionOtrosOfrecimientos> objTmp = new List<FidelizacionOtrosOfrecimientos>();
            var lisado = (from otrosOfrecimientos in dimeContex.FidelizacionOtrosOfrecimientos
                          orderby otrosOfrecimientos.Nombre ascending
                          select new
                          {
                              otrosOfrecimientos.Activo,
                              otrosOfrecimientos.Eliminado,
                              otrosOfrecimientos.Id,
                              otrosOfrecimientos.Nombre,
                              otrosOfrecimientos.UsuarioId,
                          }
                          ).ToList();

            for (var i = 0; i < lisado.Count; i++)
            {
                objTmp.Add(new FidelizacionOtrosOfrecimientos());
                objTmp[i].Activo = lisado[i].Activo;
                objTmp[i].Eliminado = lisado[i].Eliminado;
                objTmp[i].Id = lisado[i].Id;
                objTmp[i].Nombre = lisado[i].Nombre;
                objTmp[i].UsuarioId = lisado[i].UsuarioId;
            }
            return objTmp;
        }

        public void setTipificacion(FidelizacionTipificacion objTipificacion)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            unidadTrabajo.FidelizacionTipificacion.Add(objTipificacion);
            unidadTrabajo.Complete();
            unidadTrabajo.Dispose();
        }

        public void setRecursiva(FidelizacionRecursiva objRecursiva)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            unidadTrabajo.FidelizacionRecursiva.Add(objRecursiva);
            unidadTrabajo.Complete();
            unidadTrabajo.Dispose();
        }

        public FidelizacionRecursiva getRecursivaById(decimal idRecursiva)
        {
            UnitOfWork UnidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionRecursiva fila = UnidadTrabajo.FidelizacionRecursiva.Find(c => c.Id == idRecursiva).FirstOrDefault();
            return fila;

        }
        public List<FidelizacionRecursiva> getRecursivaAll(decimal idPadre = 0,decimal nivel = 0)
        {
            DimeContext dimeContext = new DimeContext();
            List<FidelizacionRecursiva> objTmp = new List<FidelizacionRecursiva>();
            
            if (idPadre == 0)
            {
               
                var listado = (from recursiva in dimeContext.FidelizacionRecursiva
                                   where recursiva.ParentId != null && 
                                   ((nivel == 0)?1==1:((nivel == 1)? recursiva.VerNivel.StartsWith("1") :((nivel == 3)? recursiva.VerNivel.EndsWith("1") : ((nivel == 2)?(recursiva.VerNivel.EndsWith("10") || recursiva.VerNivel.EndsWith("11") || recursiva.VerNivel.StartsWith("01") || recursiva.VerNivel.StartsWith("11")) :1==1))))
                               orderby recursiva.Nombre ascending
                                   select new
                                   {
                                       recursiva.Id,
                                       recursiva.Label,
                                       recursiva.Nivel,
                                       recursiva.Nombre,
                                       recursiva.ParentId,
                                       recursiva.VerNivel
                                   }
                               ).ToList();
                
                for (var i = 0; i < listado.Count; i++)
                {
                    objTmp.Add(new FidelizacionRecursiva());
                    objTmp[i].Id = listado[i].Id;
                    objTmp[i].Label = listado[i].Label;
                    objTmp[i].Nivel = listado[i].Nivel;
                    objTmp[i].Nombre = listado[i].Nombre;
                    objTmp[i].ParentId = listado[i].ParentId;
                    objTmp[i].VerNivel = listado[i].VerNivel;
                }
                return objTmp;
            }
            else {
                
                var listado = (from recursiva in dimeContext.FidelizacionRecursiva
                               where recursiva.ParentId == idPadre &&
                               ((nivel == 0) ? 1 == 1 : ((nivel == 1) ? recursiva.VerNivel.StartsWith("1") : ((nivel == 3) ? recursiva.VerNivel.EndsWith("1") : ((nivel == 2) ? (recursiva.VerNivel.EndsWith("10") || recursiva.VerNivel.EndsWith("11") || recursiva.VerNivel.StartsWith("01") || recursiva.VerNivel.StartsWith("11")) : 1 == 1))))
                               orderby recursiva.Nombre ascending
                               select new
                               {
                                   recursiva.Id,
                                   recursiva.Label,
                                   recursiva.Nivel,
                                   recursiva.Nombre,
                                   recursiva.ParentId,
                                   recursiva.VerNivel
                               }
                               ).ToList();
                for (var i = 0; i < listado.Count; i++)
                {
                    objTmp.Add(new FidelizacionRecursiva());
                    objTmp[i].Id = listado[i].Id;
                    objTmp[i].Label = listado[i].Label;
                    objTmp[i].Nivel = listado[i].Nivel;
                    objTmp[i].Nombre = listado[i].Nombre;
                    objTmp[i].ParentId = listado[i].ParentId;
                    objTmp[i].VerNivel = listado[i].VerNivel;
                }
                return objTmp;
            }
            
            

        }
        public List<FidelizacionTipificacion> getTipificacionAll(decimal eliminado,decimal nivel=0)
        {
            int a =0;
            int b = 0;
            int c = 0;
            if (nivel == 3)
                c = 1;
            else if (nivel == 2)
                b = 1;
            else if (nivel == 1)
                a = 1;
            DimeContext dimeContext = new DimeContext();
            List<FidelizacionTipificacion> objTmp = new List<FidelizacionTipificacion>();

            var listado = (from tipificacion in dimeContext.FidelizacionTipificacion
                           where tipificacion.Eliminado == eliminado && tipificacion.Nivel1 == a && tipificacion.Nivel2 == b && tipificacion.Nivel3 == c
                           orderby tipificacion.Nombre ascending
                           select new
                           {
                               tipificacion.Activo,
                               tipificacion.Eliminado,
                               tipificacion.Id,
                               tipificacion.Modulo,
                               tipificacion.Nivel1,
                               tipificacion.Nivel2,
                               tipificacion.Nivel3,
                               tipificacion.Nombre,
                               tipificacion.Nota,
                               tipificacion.Registro,
                               tipificacion.UsuarioId,
                               tipificacion.ValidaRetencion

                           }
                           ).ToList();

            for (var i = 0; i < listado.Count; i++)
            {
                objTmp.Add(new FidelizacionTipificacion());
                objTmp[i].Activo = listado[i].Activo;
                objTmp[i].Eliminado = listado[i].Eliminado;
                objTmp[i].Id = listado[i].Id;
                objTmp[i].Modulo = listado[i].Modulo;
                objTmp[i].Nombre = listado[i].Nombre;
                objTmp[i].Nivel1 = listado[i].Nivel1;
                objTmp[i].Nivel2 = listado[i].Nivel2;
                objTmp[i].Nivel3 = listado[i].Nivel3;
                objTmp[i].Nota = listado[i].Nota;
                objTmp[i].Registro = listado[i].Registro;
                objTmp[i].UsuarioId = listado[i].UsuarioId;
                objTmp[i].ValidaRetencion = listado[i].ValidaRetencion;
            }
            return objTmp;
        }
        public FidelizacionTipificacion getTipificacionById(decimal idTipificacion)
        {
            UnitOfWork UnidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionTipificacion fila = UnidadTrabajo.FidelizacionTipificacion.Find(c => c.Id == idTipificacion).FirstOrDefault();
            return fila;

        }
        public void setRegistro(FidelizacionRegistro objRegistro)
        {
            UnitOfWork UnidadTrabajo = new UnitOfWork(new DimeContext());
            UnidadTrabajo.FidelizacionRegistro.Add(objRegistro);
            UnidadTrabajo.Complete();
            UnidadTrabajo.Dispose();
        }

        public List<FidelizacionRegistro> getRegistroAll()
        {
            DimeContext dimeContext = new DimeContext();
            List<FidelizacionRegistro> objTmp = new List<FidelizacionRegistro>();
            var listado = (from registro in dimeContext.FidelizacionRegistro
                           orderby registro.FechaRegistro ascending
                           select new
                           {
                               registro.Cuenta,
                               registro.DiaCorte,
                               registro.FechaCorte,
                               registro.FechaRegistro,
                               registro.Id,
                               registro.Notas,
                               registro.Permanencia,
                               registro.RecursivaIdA,
                               registro.RecursivaIdB,
                               registro.RecursivaIdC,
                               registro.ServiciosId,
                               registro.ServiciosRetenidosId,
                               registro.SubmotivoId,
                               registro.TipificacionId,
                               registro.UsuarioId,
                               registro.UsuarioTransfiere,
                               registro.Renta,
                               registro.Direccion,
                               registro.Ticket,
                               registro.Nivel

                           }
                           ).ToList();

            for (var i = 0; i < listado.Count; i++)
            {
                objTmp.Add(new FidelizacionRegistro());
                objTmp[i].Cuenta = listado[i].Cuenta;
                objTmp[i].DiaCorte = listado[i].DiaCorte;
                objTmp[i].FechaCorte = listado[i].FechaCorte;
                objTmp[i].FechaRegistro = listado[i].FechaRegistro;
                objTmp[i].Id = listado[i].Id;
                objTmp[i].Notas = listado[i].Notas;
                objTmp[i].RecursivaIdA = listado[i].RecursivaIdA;
                objTmp[i].RecursivaIdB = listado[i].RecursivaIdB;
                objTmp[i].RecursivaIdC = listado[i].RecursivaIdC;
                objTmp[i].ServiciosId = listado[i].ServiciosId;
                objTmp[i].ServiciosRetenidosId = listado[i].ServiciosRetenidosId;
                objTmp[i].SubmotivoId = listado[i].SubmotivoId;
                objTmp[i].TipificacionId = listado[i].TipificacionId;
                objTmp[i].UsuarioId = listado[i].UsuarioId;
                objTmp[i].Renta = listado[i].Renta;
                objTmp[i].UsuarioTransfiere = listado[i].UsuarioTransfiere;
                objTmp[i].Direccion = listado[i].Direccion;
                objTmp[i].Ticket = listado[i].Ticket;
                objTmp[i].Nivel = listado[i].Nivel;
            }
            return objTmp;
        }
        public void updateMaestroServicios(FidelizacionMaestroServicios objServicio)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionMaestroServicios servicioActualizado = unidadTrabajo.FidelizacionMaestroServicios.Get(Convert.ToInt32(objServicio.IdServicio));

            servicioActualizado.IdRetencion = objServicio.IdRetencion;
            servicioActualizado.IdServicio = objServicio.IdServicio;
            servicioActualizado.Nombre = objServicio.Nombre;

            unidadTrabajo.Complete();
        }
        
        public void updateMotivoCancelacion(FidelizacionMotivosCancelacion objMotivo)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionMotivosCancelacion motivoActualizado = unidadTrabajo.FidelizacionMotivosCancelacion.Get(Convert.ToInt32(objMotivo.Id));

            motivoActualizado.Eliminado = objMotivo.Eliminado;
            motivoActualizado.Motivo = objMotivo.Motivo;
            motivoActualizado.OtrosCampos = objMotivo.OtrosCampos;
            motivoActualizado.OtrosOfrecimientos = objMotivo.OtrosOfrecimientos;
            motivoActualizado.Registro = DateTime.Now;
            unidadTrabajo.Complete();

        }
        public void updateSubmotivoCancelacion(FidelizacionSubmotivosCancelacion objSubmotivo)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionSubmotivosCancelacion submotivoActualizado = unidadTrabajo.FidelizacionSubmotivosCancelacion.Get(Convert.ToInt32(objSubmotivo.Id));

            submotivoActualizado.Eliminado = objSubmotivo.Eliminado;
            submotivoActualizado.FIDMotivoId = objSubmotivo.FIDMotivoId;
            submotivoActualizado.Id = objSubmotivo.Id;
            submotivoActualizado.Registro = objSubmotivo.Registro;
            submotivoActualizado.Submotivo = objSubmotivo.Submotivo;

            unidadTrabajo.Complete();
        }
        public void updateOtrosOfrecimientos(FidelizacionOtrosOfrecimientos objOtros)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionOtrosOfrecimientos otrosActualizado = unidadTrabajo.FidelizacionOtrosOfrecimientos.Get(Convert.ToInt32(objOtros.Id));

            otrosActualizado.Activo = objOtros.Activo;
            otrosActualizado.Eliminado = objOtros.Eliminado;
            otrosActualizado.Id = objOtros.Id;
            otrosActualizado.Nombre = objOtros.Nombre;
            otrosActualizado.UsuarioId = objOtros.UsuarioId;

            unidadTrabajo.Complete();
        }
        public void updateTipificacion(FidelizacionTipificacion objTipificacion)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionTipificacion tipificacionActualizado = unidadTrabajo.FidelizacionTipificacion.Get(Convert.ToInt32(objTipificacion.Id));

            tipificacionActualizado.Activo = objTipificacion.Activo;
            tipificacionActualizado.Eliminado = objTipificacion.Eliminado;
            tipificacionActualizado.Id = objTipificacion.Id;
            tipificacionActualizado.Modulo = objTipificacion.Modulo;
            tipificacionActualizado.Nivel1 = objTipificacion.Nivel1;
            tipificacionActualizado.Nivel2 = objTipificacion.Nivel2;
            tipificacionActualizado.Nivel3 = objTipificacion.Nivel3;
            tipificacionActualizado.Nombre = objTipificacion.Nombre;
            tipificacionActualizado.Nota = objTipificacion.Nota;
            tipificacionActualizado.Registro = objTipificacion.Registro;
            tipificacionActualizado.UsuarioId = objTipificacion.UsuarioId;
            tipificacionActualizado.ValidaRetencion = objTipificacion.ValidaRetencion
                ;

            unidadTrabajo.Complete();
        }
        public void updateRecursiva(FidelizacionRecursiva objRecursiva)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionRecursiva recursivaActualizado = unidadTrabajo.FidelizacionRecursiva.Get(Convert.ToInt32(objRecursiva.Id));

            recursivaActualizado.Id = objRecursiva.Id;
            recursivaActualizado.Label = objRecursiva.Label;
            recursivaActualizado.Nivel = objRecursiva.Nivel;
            recursivaActualizado.Nombre = objRecursiva.Nombre;
            recursivaActualizado.ParentId = objRecursiva.ParentId;
            recursivaActualizado.VerNivel = objRecursiva.VerNivel;
            unidadTrabajo.Complete();
        }
        public void updateRegistro(FidelizacionRegistro objRegistro)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionRegistro registroActualizado = unidadTrabajo.FidelizacionRegistro.Get(Convert.ToInt32(objRegistro.Id));

            registroActualizado.Cuenta = objRegistro.Cuenta;
            registroActualizado.DiaCorte = objRegistro.DiaCorte;
            registroActualizado.FechaCorte = objRegistro.FechaCorte;
            registroActualizado.FechaRegistro = objRegistro.FechaRegistro;
            registroActualizado.Id = objRegistro.Id;
            registroActualizado.Notas = objRegistro.Notas;
            registroActualizado.Permanencia = objRegistro.Permanencia;
            registroActualizado.RecursivaIdA = objRegistro.RecursivaIdA;
            registroActualizado.RecursivaIdB = objRegistro.RecursivaIdB;
            registroActualizado.RecursivaIdC = objRegistro.RecursivaIdC;
            registroActualizado.ServiciosId = objRegistro.ServiciosId;
            registroActualizado.ServiciosRetenidosId = objRegistro.ServiciosRetenidosId;
            registroActualizado.SubmotivoId = objRegistro.SubmotivoId;
            registroActualizado.TipificacionId = objRegistro.TipificacionId;
            registroActualizado.UsuarioId = objRegistro.UsuarioId;

            unidadTrabajo.Complete();
        }
        public void updateOtrosCampos(FidelizacionOtrosCampos objOtrosCampos)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionOtrosCampos registroActualizado = unidadTrabajo.FidelizacionOtrosCampos.Get(Convert.ToInt32(objOtrosCampos.Id));

            registroActualizado.Eliminado = objOtrosCampos.Eliminado;
            registroActualizado.Id = objOtrosCampos.Id;
            registroActualizado.Nivel = objOtrosCampos.Nivel;
            registroActualizado.Nombre = objOtrosCampos.Nombre;
            registroActualizado.Opciones = objOtrosCampos.Opciones;
            registroActualizado.Tipo = objOtrosCampos.Tipo;

            unidadTrabajo.Complete();
        }
        public void setOtrosCampos(FidelizacionOtrosCampos objOtrosCampos)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            unidadTrabajo.FidelizacionOtrosCampos.Add(objOtrosCampos);
            unidadTrabajo.Complete();
            unidadTrabajo.Dispose();
        }

        public FidelizacionOtrosCampos getOtrosCamposById(decimal idOtrosCampos)
        {
            UnitOfWork UnidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionOtrosCampos fila = UnidadTrabajo.FidelizacionOtrosCampos.Find(c => c.Id == idOtrosCampos).FirstOrDefault();
            return fila;

        }
        public List<FidelizacionRecursiva> getRecursivaArbol(decimal idHijo) {
            DimeContext contexto = new DimeContext();
            var l = contexto.Database.SqlQuery<decimal>("WITH Tree AS ( SELECT ID, NOMBRE, PARENT_ID FROM TBL_FID_RECURSIVA WHERE ID = "+ idHijo + " UNION ALL SELECT P.ID, P.NOMBRE, P.PARENT_ID FROM  Tree AS C INNER JOIN dbo.TBL_FID_RECURSIVA AS P ON C.PARENT_ID = P.ID ) SELECT ID FROM Tree WHERE PARENT_ID is not null ORDER BY ID ASC").ToList();
            List<FidelizacionRecursiva> objTmp = new List<FidelizacionRecursiva>();
            var t =l[0];

            for (var i = 0; i < l.Count; i++)
            {
                var listado = getRecursivaById(l[i]);
                //test.
                objTmp.Add(new FidelizacionRecursiva());
                objTmp[i].Id = listado.Id;
                objTmp[i].Label = listado.Label;
                objTmp[i].Nivel = listado.Nivel;
                objTmp[i].Nombre = listado.Nombre;
                objTmp[i].ParentId = listado.ParentId;
                objTmp[i].VerNivel = listado.VerNivel;
                //objTmp.Add(getRecursivaById(l[i]));
            }

            return objTmp;
            
        }
        public List<FidelizacionOtrosCampos> getOtrosCamposAll(decimal eliminado,decimal nivel=0)
        {
            string filter = "0";
            
            if (nivel == 3)
                filter = "/1";
            else if (nivel == 2)
                filter = "/1/";
            else if (nivel == 1)
                filter = "1/";

            DimeContext dimeContext = new DimeContext();
            List<FidelizacionOtrosCampos> objTmp = new List<FidelizacionOtrosCampos>();
            var listado = (from otrosCampos in dimeContext.FidelizacionOtrosCampos
                           where otrosCampos.Nivel == filter
                           orderby otrosCampos.Nombre ascending
                           select new
                           {
                               otrosCampos.Eliminado,
                               otrosCampos.Id,
                               otrosCampos.Nivel,
                               otrosCampos.Nombre,
                               otrosCampos.Opciones,
                               otrosCampos.Tipo,
                           }
                           ).ToList();

            for (var i = 0; i < listado.Count; i++)
            {
                objTmp.Add(new FidelizacionOtrosCampos());
                objTmp[i].Eliminado = listado[i].Eliminado;
                objTmp[i].Id = listado[i].Id;
                objTmp[i].Nivel = listado[i].Nivel;
                objTmp[i].Nombre = listado[i].Nombre;
                objTmp[i].Opciones = listado[i].Opciones;
                objTmp[i].Tipo = listado[i].Tipo;
            }
            return objTmp;
        }

        public void setRegistroCampos(FidelizacionRegistroCampos objRegistroCampos)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            unidadTrabajo.FidelizacionRegistroCampos.Add(objRegistroCampos);
            unidadTrabajo.Complete();
            unidadTrabajo.Dispose();
        }

        public FidelizacionRegistroCampos getRegistroCamposById(decimal idRegistro)
        {
            UnitOfWork UnidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionRegistroCampos fila = UnidadTrabajo.FidelizacionRegistroCampos.Find(c => c.RegistroId == idRegistro).FirstOrDefault();
            return fila;

        }
        public List<FidelizacionRegistroCampos> getRegistroCamposAll()
        {
            DimeContext dimeContext = new DimeContext();
            List<FidelizacionRegistroCampos> objTmp = new List<FidelizacionRegistroCampos>();
            var listado = (from registroCampos in dimeContext.FidelizacionRegistroCampos
                           orderby registroCampos.RegistroId, registroCampos.OtrosCamposId ascending
                           select new
                           {
                               registroCampos.OtrosCamposId,
                               registroCampos.RegistroId,
                               registroCampos.Valor
                           }
                           ).ToList();

            for (var i = 0; i < listado.Count; i++)
            {
                objTmp.Add(new FidelizacionRegistroCampos());
                objTmp[i].OtrosCamposId = listado[i].OtrosCamposId;
                objTmp[i].RegistroId = listado[i].RegistroId;
                objTmp[i].Valor = listado[i].Valor;
            }
            return objTmp;
        }
        public void updateRegistroCampos(FidelizacionRegistroCampos objRegistroCampos)
        {
            UnitOfWork unidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionRegistroCampos registroActualizado = unidadTrabajo.FidelizacionRegistroCampos.Get(Convert.ToInt32(objRegistroCampos.Id));

            registroActualizado.Id = objRegistroCampos.Id;
            registroActualizado.OtrosCamposId = objRegistroCampos.OtrosCamposId;
            registroActualizado.RegistroId = objRegistroCampos.RegistroId;
            registroActualizado.Valor = objRegistroCampos.Valor;

            unidadTrabajo.Complete();
        }

        public List<FidelizacionRecursivaVistaDetalle> getRecursivaVistaAll()
        {
            DimeContext dimeContext = new DimeContext();
            List<FidelizacionRecursivaVistaDetalle> objTmp = new List<FidelizacionRecursivaVistaDetalle>();
            dimeContext.GeneraJerarquiaRecursiva();
            var listado = (from recursivaVista in dimeContext.FidelizacionRecursivaVista
                           join b in (from m in dimeContext.FidelizacionRecursivaVista select new { m.Id, m.Nombre }).Distinct() on recursivaVista.ParentId equals b.Id
                           orderby recursivaVista.Ordr ascending
                           where recursivaVista.ParentId != null
                           select new
                           {
                               recursivaVista.Id,
                               recursivaVista.Label,
                               recursivaVista.Nivel,
                               recursivaVista.Nombre,
                               recursivaVista.ParentId,
                               recursivaVista.VerNivel,
                               NombrePadre = b.Nombre
                               
                           }
                           ).ToList();

            for (var i = 0; i < listado.Count; i++)
            {
                objTmp.Add(new FidelizacionRecursivaVistaDetalle());
                objTmp[i].Id = listado[i].Id;
                objTmp[i].Label = listado[i].Label;
                objTmp[i].Nivel = listado[i].Nivel;
                objTmp[i].Nombre = new String('-', Convert.ToInt32(listado[i].Nivel)) +listado[i].Nombre;
                objTmp[i].ParentId = listado[i].ParentId;
                objTmp[i].VerNivel = listado[i].VerNivel;
                objTmp[i].ParentName = listado[i].NombrePadre;
            }
            return objTmp;
        }
        public FidelizacionRecursivaVista getRecursivaVistaById(decimal idRecursiva)
        {
            UnitOfWork UnidadTrabajo = new UnitOfWork(new DimeContext());
            FidelizacionRecursivaVista fila = UnidadTrabajo.FidelizacionRecursivaVista.Find(c => c.Id == idRecursiva).FirstOrDefault();
            return fila;

        }
        public List<MaestroFestivos> getMaestrosByCorteId(decimal numDias, decimal corte)
        {
            var numDia = "01";
            if (corte == 2)
                numDia = "02";
            if (corte == 3)
                numDia = "03";
            MaestrosContext contexto = new MaestrosContext();
            var l = contexto.Database.SqlQuery<DateTime>("SELECT TOP " + Convert.ToString(numDias) + " FECHA FROM TMP_MAESTRO_FESTIVOS WHERE TIPO_DIA_LUNES_VIERNES = '1' AND FECHA <= (select CONCAT(year(dateadd(month, 1, getdate())), '-', month(dateadd(month, 1, getdate())), '-" + numDia + "')) ORDER BY ID DESC").ToList();
            List<MaestroFestivos> objTmp = new List<MaestroFestivos>();
            var t = l[0];

            for (var i = 0; i < l.Count; i++)
            {
                objTmp.Add(new MaestroFestivos());
                objTmp[i].Fecha= l[i];
            }

            return objTmp;
        }
    }
}
