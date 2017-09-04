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
        public decimal RegistrarIncidente(BIPBitacoraIncidentes Bitacora)
        {
            //registra incidente tabla principal
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DateTime Fecha = DateTime.Now;
            Bitacora.FechaDeRegistro = Fecha;
            Bitacora.FechaUltimaActualizacion = Fecha;
            Bitacora.EstadoDelCaso = "EN GESTION";
            Bitacora.UsuarioGestionando = 0;
            unitWork.BIPBitacoraIncidentes.Add(Bitacora);
            unitWork.Complete();
            unitWork.Dispose();

            //registra incidente en la tabla del log
            UnitOfWork unitWorklog = new UnitOfWork(new DimeContext());
            BILBitacoraIncidentes BitacoraLog = new BILBitacoraIncidentes();

            BitacoraLog.IdRegistro = Bitacora.IdRegistro;
            BitacoraLog.UsuarioCreacion = Bitacora.UsuarioCreacion;
            BitacoraLog.NombreUsuarioCreacion = Bitacora.NombreUsuarioCreacion;
            BitacoraLog.FechaDeRegistro = Bitacora.FechaDeRegistro;
            BitacoraLog.FechaUltimaActualizacion = Bitacora.FechaUltimaActualizacion;
            BitacoraLog.UsuarioUltimaActualizacion = Bitacora.UsuarioUltimaActualizacion;
            BitacoraLog.NombreUsuarioUltimaActualizacion = Bitacora.NombreUsuarioUltimaActualizacion;
            BitacoraLog.CasoSD = Bitacora.CasoSD;
            BitacoraLog.IM = Bitacora.IM;
            BitacoraLog.FechaDeCreacionTicket = Bitacora.FechaDeCreacionTicket;
            BitacoraLog.FechaDeCierreTicket = Bitacora.FechaDeCierreTicket;
            BitacoraLog.FechaDeCierreAfectacion = Bitacora.FechaDeCierreAfectacion;
            BitacoraLog.Herramienta = Bitacora.Herramienta;
            BitacoraLog.TipoDeFalla = Bitacora.TipoDeFalla;
            BitacoraLog.ModuloAfectado = Bitacora.ModuloAfectado;
            BitacoraLog.DescripcionAfectacion = Bitacora.DescripcionAfectacion;
            BitacoraLog.Prioridad = Bitacora.Prioridad;
            BitacoraLog.EscaladoA = Bitacora.EscaladoA;
            BitacoraLog.CantidadUsuariosAfectados = Bitacora.CantidadUsuariosAfectados;
            BitacoraLog.ComentariosDeCierre = Bitacora.ComentariosDeCierre;
            BitacoraLog.EstadoDelCaso = Bitacora.EstadoDelCaso;

            unitWorklog.BILBitacoraIncidentes.Add(BitacoraLog);
            unitWorklog.Complete();
            unitWorklog.Dispose();
            return Bitacora.IdRegistro;
        }
        public void ActualizarRegistroIncidente(BIPBitacoraIncidentes Bitacora)
        {
            //busca la informacion para actualizar
            UnitOfWork UnitOfWorkActualizar = new UnitOfWork(new DimeContext());
            BIPBitacoraIncidentes IncidenteActualizable = UnitOfWorkActualizar.BIPBitacoraIncidentes.Find(c => c.IdRegistro == Bitacora.IdRegistro).FirstOrDefault();
            DateTime Fecha = DateTime.Now;
            IncidenteActualizable.FechaUltimaActualizacion = Fecha;
            IncidenteActualizable.UsuarioUltimaActualizacion = Bitacora.UsuarioUltimaActualizacion;
            IncidenteActualizable.NombreUsuarioUltimaActualizacion = Bitacora.NombreUsuarioUltimaActualizacion;
            IncidenteActualizable.CasoSD = Bitacora.CasoSD;
            IncidenteActualizable.IM = Bitacora.IM;
            IncidenteActualizable.FechaDeCreacionTicket = Bitacora.FechaDeCreacionTicket;
            IncidenteActualizable.FechaDeCierreTicket = Bitacora.FechaDeCierreTicket;
            IncidenteActualizable.FechaDeCierreAfectacion = Bitacora.FechaDeCierreAfectacion;
            IncidenteActualizable.Herramienta = Bitacora.Herramienta;
            IncidenteActualizable.TipoDeFalla = Bitacora.TipoDeFalla;
            IncidenteActualizable.ModuloAfectado = Bitacora.ModuloAfectado;
            IncidenteActualizable.DescripcionAfectacion = Bitacora.DescripcionAfectacion;
            IncidenteActualizable.Prioridad = Bitacora.Prioridad;
            IncidenteActualizable.EscaladoA = Bitacora.EscaladoA;
            IncidenteActualizable.CantidadUsuariosAfectados = Bitacora.CantidadUsuariosAfectados;
            IncidenteActualizable.ComentariosDeCierre = Bitacora.ComentariosDeCierre;
            IncidenteActualizable.EstadoDelCaso = Bitacora.EstadoDelCaso;

            UnitOfWorkActualizar.Complete();
            UnitOfWorkActualizar.Dispose();

            //registra el log de la transaccion realizada;
            //registra incidente en la tabla del log
            UnitOfWork unitWorklog = new UnitOfWork(new DimeContext());
            BILBitacoraIncidentes BitacoraLog = new BILBitacoraIncidentes();

            BitacoraLog.IdRegistro = IncidenteActualizable.IdRegistro;
            BitacoraLog.UsuarioCreacion = IncidenteActualizable.UsuarioCreacion;
            BitacoraLog.NombreUsuarioCreacion = IncidenteActualizable.NombreUsuarioCreacion;
            BitacoraLog.FechaDeRegistro = IncidenteActualizable.FechaDeRegistro;
            BitacoraLog.FechaUltimaActualizacion = IncidenteActualizable.FechaUltimaActualizacion;
            BitacoraLog.UsuarioUltimaActualizacion = IncidenteActualizable.UsuarioUltimaActualizacion;
            BitacoraLog.NombreUsuarioUltimaActualizacion = IncidenteActualizable.NombreUsuarioUltimaActualizacion;
            BitacoraLog.CasoSD = IncidenteActualizable.CasoSD;
            BitacoraLog.IM = IncidenteActualizable.IM;
            BitacoraLog.FechaDeCreacionTicket = IncidenteActualizable.FechaDeCreacionTicket;
            BitacoraLog.FechaDeCierreTicket = IncidenteActualizable.FechaDeCierreTicket;
            BitacoraLog.FechaDeCierreAfectacion = IncidenteActualizable.FechaDeCierreAfectacion;
            BitacoraLog.Herramienta = IncidenteActualizable.Herramienta;
            BitacoraLog.TipoDeFalla = IncidenteActualizable.TipoDeFalla;
            BitacoraLog.ModuloAfectado = IncidenteActualizable.ModuloAfectado;
            BitacoraLog.DescripcionAfectacion = IncidenteActualizable.DescripcionAfectacion;
            BitacoraLog.Prioridad = IncidenteActualizable.Prioridad;
            BitacoraLog.EscaladoA = IncidenteActualizable.EscaladoA;
            BitacoraLog.CantidadUsuariosAfectados = IncidenteActualizable.CantidadUsuariosAfectados;
            BitacoraLog.ComentariosDeCierre = IncidenteActualizable.ComentariosDeCierre;
            BitacoraLog.EstadoDelCaso = IncidenteActualizable.EstadoDelCaso;

            unitWorklog.BILBitacoraIncidentes.Add(BitacoraLog);
            unitWorklog.Complete();
            unitWorklog.Dispose();

        }
        public void RegistrarOperacionesPorIncidente(List<string> Operaciones, decimal IdRegistro)
        {
            List<decimal> IdOperaciones = Operaciones.ConvertAll(s => Convert.ToDecimal(s));
            foreach (decimal ID_OPERACION in IdOperaciones)
            {
                UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
                BIMOperaciones Operacion = UnitOfWork.BIMOperaciones.Find(c => c.IdOperacion == ID_OPERACION && c.Estado.Equals("ACTIVO")).FirstOrDefault();
                if (Operacion != null)
                {
                    UnitOfWork unitWorkvalida = new UnitOfWork(new DimeContext());
                    BIPIncidentesPorOperacion OperacionRegistrada = unitWorkvalida.BIPIncidentesPorOperacion.Find(c => c.IdOperacion == Operacion.IdOperacion && c.IdRegistro == IdRegistro).FirstOrDefault();

                    if (OperacionRegistrada != null)
                    {
                        unitWorkvalida.Dispose();
                        UnitOfWork.Dispose();
                    }
                    else
                    {
                        //registra Incidente por operacion
                        UnitOfWork unitWorkincidente = new UnitOfWork(new DimeContext());
                        BIPIncidentesPorOperacion Incidente = new BIPIncidentesPorOperacion();
                        Incidente.IdRegistro = IdRegistro;
                        Incidente.IdGerencia = Operacion.IdGerencia;
                        Incidente.IdAliado = Operacion.IdAliado;
                        Incidente.IdOperacion = Operacion.IdOperacion;
                        unitWorkincidente.BIPIncidentesPorOperacion.Add(Incidente);
                        unitWorkincidente.Complete();
                        unitWorkincidente.Dispose();
                    }
                }
            }

        }
        public void EliminarIncidenteOperacion(decimal Id)
        {

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIPIncidentesPorOperacion RegistroEliminar = unitWork.BIPIncidentesPorOperacion.Find(c => c.Id == Id).FirstOrDefault();

            if (RegistroEliminar != null)
            {
                unitWork.BIPIncidentesPorOperacion.Remove(RegistroEliminar);
                unitWork.Complete();
            }
            else { }
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
        public List<BIMHerramientas> ListaDeHerramientas()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMHerramientas> result = new List<BIMHerramientas>();
            var objetosResult = (from a in dimContext.BIMHerramientas
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.NombreHerramienta ascending
                                 select new
                                 {
                                     a.IdHerramienta,
                                     a.NombreHerramienta
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMHerramientas());
                result[i].IdHerramienta = objetosResult[i].IdHerramienta;
                result[i].NombreHerramienta = objetosResult[i].NombreHerramienta;

            }
            return result;
        }
        public List<BIMTipoFalla> ListaTiposDeFallas()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMTipoFalla> result = new List<BIMTipoFalla>();
            var objetosResult = (from a in dimContext.BIMTipoFalla
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.TipoFalla ascending
                                 select new
                                 {
                                     a.IdTipoFalla,
                                     a.TipoFalla
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMTipoFalla());
                result[i].IdTipoFalla = objetosResult[i].IdTipoFalla;
                result[i].TipoFalla = objetosResult[i].TipoFalla;

            }
            return result;
        }
        public List<BIMPrioridades> ListaDePrioridades()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMPrioridades> result = new List<BIMPrioridades>();
            var objetosResult = (from a in dimContext.BIMPrioridades
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.Prioridad ascending
                                 select new
                                 {
                                     a.IdPrioridad,
                                     a.Prioridad
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMPrioridades());
                result[i].IdPrioridad = objetosResult[i].IdPrioridad;
                result[i].Prioridad = objetosResult[i].Prioridad;

            }
            return result;
        }
        public List<BIMOperaciones> ListaDeOperaciones()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMOperaciones> result = new List<BIMOperaciones>();
            var objetosResult = (from a in dimContext.BIMOperaciones
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.NombreOperacion ascending
                                 select new
                                 {
                                     a.IdOperacion,
                                     a.NombreOperacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMOperaciones());
                result[i].IdOperacion = objetosResult[i].IdOperacion;
                result[i].NombreOperacion = objetosResult[i].NombreOperacion;

            }
            return result;
        }
        public List<BIMAliados> ListaDeAliadosPorGerencia(List<string> Gerencias)
        {
            List<decimal> IdGerencias = Gerencias.ConvertAll(s => Convert.ToDecimal(s));
            List<BIMAliados> result = new List<BIMAliados>();
            foreach (decimal Id in IdGerencias)
            {
                DimeContext dimContext = new DimeContext();
                List<BIMOperaciones> Operaciones = dimContext.BIMOperaciones.Where(c => c.IdGerencia == Id && c.Estado.Equals("ACTIVO")).ToList();
                if (Operaciones.Count > 0)
                {

                    var objetosResult = (from a in dimContext.BIMAliados
                                         join b in (from m in dimContext.BIMOperaciones select new { m.IdAliado, m.IdGerencia }).Distinct() on a.IdAliado equals b.IdAliado
                                         where b.IdGerencia == Id && a.Estado.Equals("ACTIVO")
                                         select new
                                         {
                                             a.IdAliado,
                                             a.NombreAliado

                                         }
                                         ).Distinct().ToList();
                    List<decimal> IdAliados = objetosResult.ConvertAll(s => Convert.ToDecimal(s.IdAliado));
                    foreach (decimal IdAliado in IdAliados)
                    {
                        BIMAliados NuevoAliado = dimContext.BIMAliados.Where(c => c.IdAliado == IdAliado && c.Estado.Equals("ACTIVO")).FirstOrDefault();
                        if (NuevoAliado != null)
                        {
                            BIMAliados AliadoExistente = result.Find(x => x.IdAliado == NuevoAliado.IdAliado);
                            if (AliadoExistente== null)
                            {
                                result.Add(NuevoAliado);
                            }
                        }
                    }

                }
                else { }
            }
            
            return result;
        }
        public List<BIMOperaciones> ListaDeOperacionesPorgerenciaYAliado(List<string> Gerencias, List<string>Aliados)
        {
            List<decimal> IdGerencias = Gerencias.ConvertAll(s => Convert.ToDecimal(s));
            List<decimal> IdAliados = Aliados.ConvertAll(s => Convert.ToDecimal(s));
            List<BIMOperaciones> result = new List<BIMOperaciones>();
            foreach (decimal Id in IdGerencias)
            {
                DimeContext dimContext = new DimeContext();
                List<BIMOperaciones> Operaciones = dimContext.BIMOperaciones.Where(c => c.IdGerencia == Id && c.Estado.Equals("ACTIVO")).ToList();
                if (Operaciones.Count > 0)
                {
                    foreach (decimal Ids in IdAliados)
                    {
                        List<BIMAliados> Aliadosexistentes = dimContext.BIMAliados.Where(c => c.IdAliado == Ids && c.Estado.Equals("ACTIVO")).ToList();
                        if (Aliadosexistentes != null)
                        {
                            var objetosResult = (from a in dimContext.BIMOperaciones
                                                 where a.IdAliado == Ids && a.IdGerencia== Id && a.Estado.Equals("ACTIVO")
                                                 select new
                                                 {
                                                     a.IdOperacion,
                                                     a.NombreOperacion

                                                 }
                                         ).Distinct().ToList();
                            List<decimal> IdOperaciones = objetosResult.ConvertAll(s => Convert.ToDecimal(s.IdOperacion));
                            foreach (decimal IdOperacion in IdOperaciones)
                            {
                                BIMOperaciones NuevaOperacion = dimContext.BIMOperaciones.Where(c => c.IdOperacion == IdOperacion && c.Estado.Equals("ACTIVO")).FirstOrDefault();
                                if (NuevaOperacion != null)
                                {
                                    BIMOperaciones OperacionExistente = result.Find(x => x.IdOperacion == NuevaOperacion.IdOperacion);
                                    if (OperacionExistente == null)
                                    {
                                        result.Add(NuevaOperacion);
                                    }
                                }
                            }
                        }
                    }


                }
                else { }
            }

            return result;
        }

        public void RegistrarOperacionesEnIncidente(List<string> Operaciones, decimal IdRegistro)
        {
            List<decimal> IdOperaciones = Operaciones.ConvertAll(s => Convert.ToDecimal(s));
            foreach (decimal Id in IdOperaciones)
            {
                DimeContext dimContext = new DimeContext();
                BIMOperaciones ExisteOperacion = dimContext.BIMOperaciones.Where(c => c.IdOperacion == Id && c.Estado.Equals("ACTIVO")).FirstOrDefault();
                if (ExisteOperacion != null)
                {
                    UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                    BIPIncidentesPorOperacion Incidente = new BIPIncidentesPorOperacion();
                    Incidente.IdOperacion = Id;
                    Incidente.IdGerencia = ExisteOperacion.IdGerencia;
                    Incidente.IdAliado = ExisteOperacion.IdAliado;
                    Incidente.IdRegistro = IdRegistro;
                    unitWork.BIPIncidentesPorOperacion.Add(Incidente);
                    unitWork.Complete();
                    unitWork.Dispose();

                }
                else { }
            }
        }
        public BIPBitacoraIncidentes TraeIncidentePorId(int IdRegistro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.BIPBitacoraIncidentes.Get(IdRegistro);
        }
        public List<ViewModelIncidentesOperaciones> ListaDeIncidentesOperacionPorRegistro(decimal IdRegistro)
        {
            DimeContext dimContext = new DimeContext();
            List<ViewModelIncidentesOperaciones> result = new List<ViewModelIncidentesOperaciones>();
            var objetosResult = (from a in dimContext.BIPIncidentesPorOperacion
                                 join b in (from m in dimContext.BIMGerencias select new { m.IdGerencia, m.NombreGerencia }).Distinct() on a.IdGerencia equals b.IdGerencia
                                 join c in (from x in dimContext.BIMAliados select new { x.IdAliado, x.NombreAliado }).Distinct() on a.IdAliado equals c.IdAliado
                                 join d in (from y in dimContext.BIMOperaciones select new { y.IdOperacion, y.NombreOperacion }).Distinct() on a.IdOperacion equals d.IdOperacion
                                 where a.IdRegistro == IdRegistro
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.IdRegistro,
                                     b.IdGerencia,
                                     b.NombreGerencia,
                                     c.IdAliado,
                                     c.NombreAliado,
                                     d.IdOperacion,
                                     d.NombreOperacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new ViewModelIncidentesOperaciones());
                result[i].Id = objetosResult[i].Id;
                result[i].IdRegistro = objetosResult[i].IdRegistro;
                result[i].IdGerencia = objetosResult[i].IdGerencia;
                result[i].NombreGerencia = objetosResult[i].NombreGerencia;
                result[i].IdAliado = objetosResult[i].IdAliado;
                result[i].NombreAliado = objetosResult[i].NombreAliado;
                result[i].IdOperacion = objetosResult[i].IdOperacion;
                result[i].NombreOperacion = objetosResult[i].NombreOperacion;

            }
            return result;
        }
        public void EliminarOpoeracionDeIncidente(int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIPIncidentesPorOperacion RegistroAEliminar = unitWork.BIPIncidentesPorOperacion.Get(Id);
            unitWork.BIPIncidentesPorOperacion.Remove(RegistroAEliminar);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public List<BIPBitacoraIncidentes> ListaDeIncidentesEnGestion(decimal Cedula)
        {
            DimeContext dimContext = new DimeContext();
            List<BIPBitacoraIncidentes> result = new List<BIPBitacoraIncidentes>();
            var objetosResult = (from a in dimContext.BIPBitacoraIncidentes
                                 where a.EstadoDelCaso.Equals("EN GESTION") && ( a.UsuarioGestionando== 0 || a.UsuarioGestionando == Cedula)
                                 orderby a.FechaUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdRegistro,
                                     a.UsuarioCreacion,
                                     a.NombreUsuarioCreacion,
                                     a.FechaDeRegistro,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.CasoSD,
                                     a.IM,
                                     a.FechaDeCreacionTicket,
                                     a.FechaDeCierreTicket,
                                     a.FechaDeCierreAfectacion,
                                     a.Herramienta,
                                     a.TipoDeFalla,
                                     a.ModuloAfectado,
                                     a.DescripcionAfectacion,
                                     a.Prioridad,
                                     a.EscaladoA,
                                     a.CantidadUsuariosAfectados,
                                     a.ComentariosDeCierre,
                                     a.EstadoDelCaso
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIPBitacoraIncidentes());
                result[i].IdRegistro = objetosResult[i].IdRegistro;
                result[i].UsuarioCreacion = objetosResult[i].UsuarioCreacion;
                result[i].NombreUsuarioCreacion = objetosResult[i].NombreUsuarioCreacion;
                result[i].FechaDeRegistro = objetosResult[i].FechaDeRegistro;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].CasoSD = objetosResult[i].CasoSD;
                result[i].IM = objetosResult[i].IM;
                result[i].FechaDeCreacionTicket = objetosResult[i].FechaDeCreacionTicket;
                result[i].FechaDeCierreTicket = objetosResult[i].FechaDeCierreTicket;
                result[i].FechaDeCierreAfectacion = objetosResult[i].FechaDeCierreAfectacion;
                result[i].Herramienta = objetosResult[i].Herramienta;
                result[i].TipoDeFalla = objetosResult[i].TipoDeFalla;
                result[i].ModuloAfectado = objetosResult[i].ModuloAfectado;
                result[i].DescripcionAfectacion = objetosResult[i].DescripcionAfectacion;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].EscaladoA = objetosResult[i].EscaladoA;
                result[i].CantidadUsuariosAfectados = objetosResult[i].CantidadUsuariosAfectados;
                result[i].ComentariosDeCierre = objetosResult[i].ComentariosDeCierre;
                result[i].EstadoDelCaso = objetosResult[i].EstadoDelCaso;

            }
            return result;

        }
        public void AgregarAliado(BIMAliados AliadoNuevo)
        {
            //verifica si el aliado Existe
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMAliados AliadoExistente = unitWork.BIMAliados.Find(c => c.NombreAliado.Equals(AliadoNuevo.NombreAliado)).FirstOrDefault();
            if (AliadoExistente == null)
            {
                unitWork.BIMAliados.Add(AliadoNuevo);
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public void ActualizarAliado(BIMAliados Aliado)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMAliados AliadoActualizable = unitWork.BIMAliados.Find(c => c.IdAliado == Aliado.IdAliado).FirstOrDefault();
            if (AliadoActualizable != null)
            {
                AliadoActualizable.NombreAliado = Aliado.NombreAliado;
                AliadoActualizable.Estado = Aliado.Estado;
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public void AgregarGerencia(BIMGerencias GerenciaNueva)
        {
            //verifica si el aliado Existe
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMGerencias GerenciaExistente = unitWork.BIMGerencias.Find(c => c.NombreGerencia.Equals(GerenciaNueva.NombreGerencia)).FirstOrDefault();
            if (GerenciaExistente == null)
            {
                unitWork.BIMGerencias.Add(GerenciaNueva);
                unitWork.Complete();
                unitWork.Dispose();
            }

        }
        public void ActualizarGerencia(BIMGerencias Gerencia)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMGerencias GerenciaActualizable = unitWork.BIMGerencias.Find(c => c.IdGerencia == Gerencia.IdGerencia).FirstOrDefault();
            if (GerenciaActualizable != null)
            {
                GerenciaActualizable.NombreGerencia = Gerencia.NombreGerencia;
                GerenciaActualizable.Estado = Gerencia.Estado;
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public void AgregarOperaciones(BIMOperaciones OperacionNueva)
        {
            //verifica si el aliado Existe
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMOperaciones OperacionExistente = unitWork.BIMOperaciones.Find(c => c.NombreOperacion.Equals(OperacionNueva.NombreOperacion)).FirstOrDefault();
            if (OperacionExistente == null)
            {
                unitWork.BIMOperaciones.Add(OperacionNueva);
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public void ActualizarOperacion(BIMOperaciones Operacion)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMOperaciones OperacionActualizable = unitWork.BIMOperaciones.Find(c => c.IdOperacion == Operacion.IdOperacion).FirstOrDefault();
            if (OperacionActualizable != null)
            {
                OperacionActualizable.NombreOperacion = Operacion.NombreOperacion;
                OperacionActualizable.Estado = Operacion.Estado;
                OperacionActualizable.IdGerencia = Operacion.IdGerencia;
                OperacionActualizable.IdAliado = Operacion.IdAliado;
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public List<BIMGerencias> ListaDeGerenciasAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMGerencias> result = new List<BIMGerencias>();
            var objetosResult = (from a in dimContext.BIMGerencias
                                 orderby a.NombreGerencia ascending
                                 select new
                                 {
                                     a.IdGerencia,
                                     a.NombreGerencia,
                                     a.Estado

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMGerencias());
                result[i].IdGerencia = objetosResult[i].IdGerencia;
                result[i].NombreGerencia = objetosResult[i].NombreGerencia;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public List<BIMAliados> ListaDeAliadosAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMAliados> result = new List<BIMAliados>();
            var objetosResult = (from a in dimContext.BIMAliados
                                 orderby a.NombreAliado ascending
                                 select new
                                 {
                                     a.IdAliado,
                                     a.NombreAliado,
                                     a.Estado

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMAliados());
                result[i].IdAliado = objetosResult[i].IdAliado;
                result[i].NombreAliado = objetosResult[i].NombreAliado;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public List<ViewModelIncidentesOperaciones> ListaDeOperacionesAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<ViewModelIncidentesOperaciones> result = new List<ViewModelIncidentesOperaciones>();
            var objetosResult = (from a in dimContext.BIMOperaciones
                                 join b in (from m in dimContext.BIMGerencias select new { m.IdGerencia, m.NombreGerencia }).Distinct() on a.IdGerencia equals b.IdGerencia
                                 join c in (from x in dimContext.BIMAliados select new { x.IdAliado, x.NombreAliado }).Distinct() on a.IdAliado equals c.IdAliado
                                 orderby a.NombreOperacion ascending
                                 select new
                                 {
                                     
                                     b.IdGerencia,
                                     b.NombreGerencia,
                                     c.IdAliado,
                                     c.NombreAliado,
                                     a.IdOperacion,
                                     a.NombreOperacion,
                                     a.Estado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new ViewModelIncidentesOperaciones());
                result[i].IdGerencia = objetosResult[i].IdGerencia;
                result[i].NombreGerencia = objetosResult[i].NombreGerencia;
                result[i].IdAliado = objetosResult[i].IdAliado;
                result[i].NombreAliado = objetosResult[i].NombreAliado;
                result[i].IdOperacion = objetosResult[i].IdOperacion;
                result[i].NombreOperacion = objetosResult[i].NombreOperacion;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public BIMGerencias GerenciaPorId(int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMGerencias Gerencia = unitWork.BIMGerencias.Get(Id);
            if(Gerencia!= null) { return Gerencia; }else { return null; }
        }
        public BIMAliados AliadoPorId(int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMAliados Aliado = unitWork.BIMAliados.Get(Id);
            if (Aliado != null) { return Aliado; } else { return null; }
        }
        public BIMOperaciones OperacionPorId(int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMOperaciones Operacion = unitWork.BIMOperaciones.Get(Id);
            if (Operacion != null) { return Operacion; } else { return null; }
        }
        public BILBitacoraIncidentes TraeLogIncidentePorId(int IdRegistro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.BILBitacoraIncidentes.Get(IdRegistro);
        }
        public List<ViewModelIncidentesOperaciones> ListaDeAliadosAfectados(decimal IdRegistro)
        {
            DimeContext dimContext = new DimeContext();
            List<ViewModelIncidentesOperaciones> result = new List<ViewModelIncidentesOperaciones>();
            var objetosResult = (from a in dimContext.BIPIncidentesPorOperacion
                                 join b in (from m in dimContext.BIMGerencias select new { m.IdGerencia, m.NombreGerencia }).Distinct() on a.IdGerencia equals b.IdGerencia
                                 join c in (from x in dimContext.BIMAliados select new { x.IdAliado, x.NombreAliado }).Distinct() on a.IdAliado equals c.IdAliado
                                 join d in (from y in dimContext.BIMOperaciones select new { y.IdOperacion, y.NombreOperacion }).Distinct() on a.IdOperacion equals d.IdOperacion
                                 where a.IdRegistro == IdRegistro
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.IdRegistro,
                                     c.IdAliado,
                                     c.NombreAliado
                                     
                                 }
                                 ).Distinct().ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new ViewModelIncidentesOperaciones());
                result[i].IdRegistro = objetosResult[i].IdRegistro;
                result[i].IdAliado = objetosResult[i].IdAliado;
                result[i].NombreAliado = objetosResult[i].NombreAliado;
                
            }
            return result;
        }
        public List<BILBitacoraIncidentes> LogDeIncidentesPorId(decimal IdRegistro)
        {
            DimeContext dimContext = new DimeContext();
            List<BILBitacoraIncidentes> result = new List<BILBitacoraIncidentes>();
            var objetosResult = (from a in dimContext.BILBitacoraIncidentes
                                 where a.IdRegistro == IdRegistro
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.IdRegistro,
                                     a.UsuarioCreacion,
                                     a.NombreUsuarioCreacion,
                                     a.FechaDeRegistro,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.CasoSD,
                                     a.IM,
                                     a.FechaDeCreacionTicket,
                                     a.FechaDeCierreTicket,
                                     a.FechaDeCierreAfectacion,
                                     a.Herramienta,
                                     a.TipoDeFalla,
                                     a.ModuloAfectado,
                                     a.DescripcionAfectacion,
                                     a.Prioridad,
                                     a.EscaladoA,
                                     a.CantidadUsuariosAfectados,
                                     a.ComentariosDeCierre,
                                     a.EstadoDelCaso
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BILBitacoraIncidentes());
                result[i].Id = objetosResult[i].Id;
                result[i].IdRegistro = objetosResult[i].IdRegistro;
                result[i].UsuarioCreacion = objetosResult[i].UsuarioCreacion;
                result[i].NombreUsuarioCreacion = objetosResult[i].NombreUsuarioCreacion;
                result[i].FechaDeRegistro = objetosResult[i].FechaDeRegistro;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].CasoSD = objetosResult[i].CasoSD;
                result[i].IM = objetosResult[i].IM;
                result[i].FechaDeCreacionTicket = objetosResult[i].FechaDeCreacionTicket;
                result[i].FechaDeCierreTicket = objetosResult[i].FechaDeCierreTicket;
                result[i].FechaDeCierreAfectacion = objetosResult[i].FechaDeCierreAfectacion;
                result[i].Herramienta = objetosResult[i].Herramienta;
                result[i].TipoDeFalla = objetosResult[i].TipoDeFalla;
                result[i].ModuloAfectado = objetosResult[i].ModuloAfectado;
                result[i].DescripcionAfectacion = objetosResult[i].DescripcionAfectacion;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].EscaladoA = objetosResult[i].EscaladoA;
                result[i].CantidadUsuariosAfectados = objetosResult[i].CantidadUsuariosAfectados;
                result[i].ComentariosDeCierre = objetosResult[i].ComentariosDeCierre;
                result[i].EstadoDelCaso = objetosResult[i].EstadoDelCaso;

            }
            return result;

        }
        public bool ValidarSolicitudIncidente(string CasoSD)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.BIPBitacoraIncidentes.Find(c => c.CasoSD.Equals(CasoSD)).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool TransaccionIncidenteEnGestion(string Cedula,decimal IdRegistro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            decimal CedulaUsuario = Convert.ToDecimal(Cedula);
            decimal result = Convert.ToDecimal(unitWork.BIPBitacoraIncidentes.ApartarCuentaIncidente(CedulaUsuario, IdRegistro));
            if (result == CedulaUsuario) return false;
            else return true;
        }
        //admin
        public BIMHerramientas HerramientasPorId(int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMHerramientas Herramienta = unitWork.BIMHerramientas.Get(Id);
            if (Herramienta != null) { return Herramienta; } else { return null; }
        }
        public BIMPrioridades PrioridadesPorId(int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMPrioridades Prioridad = unitWork.BIMPrioridades.Get(Id);
            if (Prioridad != null) { return Prioridad; } else { return null; }
        }
        public BIMTipoFalla TipoFallaPorId(int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMTipoFalla TipoFalla = unitWork.BIMTipoFalla.Get(Id);
            if (TipoFalla != null) { return TipoFalla; } else { return null; }
        }
        public void AgregarHerramienta(BIMHerramientas HerramientaNueva)
        {
            //verifica si la herramienta Existe
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMHerramientas HerramientaExistente = unitWork.BIMHerramientas.Find(c => c.NombreHerramienta.Equals(HerramientaNueva.NombreHerramienta)).FirstOrDefault();
            if (HerramientaExistente == null)
            {
                unitWork.BIMHerramientas.Add(HerramientaNueva);
                unitWork.Complete();
                unitWork.Dispose();
            }

        }
        public void ActualizarHerramienta(BIMHerramientas Herramienta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMHerramientas HerramientaActualizable = unitWork.BIMHerramientas.Find(c => c.IdHerramienta == Herramienta.IdHerramienta).FirstOrDefault();
            if (HerramientaActualizable != null)
            {
                HerramientaActualizable.NombreHerramienta = Herramienta.NombreHerramienta;
                HerramientaActualizable.Estado = Herramienta.Estado;
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public void AgregarPrioridad(BIMPrioridades PrioridadNueva)
        {
            //verifica si la herramienta Existe
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMPrioridades PrioridadExistente = unitWork.BIMPrioridades.Find(c => c.Prioridad.Equals(PrioridadNueva.Prioridad)).FirstOrDefault();
            if (PrioridadExistente == null)
            {
                unitWork.BIMPrioridades.Add(PrioridadNueva);
                unitWork.Complete();
                unitWork.Dispose();
            }

        }
        public void ActualizarPrioridad(BIMPrioridades Prioridad)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMPrioridades PrioridadActualizable = unitWork.BIMPrioridades.Find(c => c.IdPrioridad == Prioridad.IdPrioridad).FirstOrDefault();
            if (PrioridadActualizable != null)
            {
                PrioridadActualizable.Prioridad = Prioridad.Prioridad;
                PrioridadActualizable.Estado = Prioridad.Estado;
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public void AgregarTipoFalla(BIMTipoFalla TipoFallaNueva)
        {
            //verifica si la herramienta Existe
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMTipoFalla TipoFallaExistente = unitWork.BIMTipoFalla.Find(c => c.TipoFalla.Equals(TipoFallaNueva.TipoFalla)).FirstOrDefault();
            if (TipoFallaExistente == null)
            {
                unitWork.BIMTipoFalla.Add(TipoFallaNueva);
                unitWork.Complete();
                unitWork.Dispose();
            }

        }
        public void ActualizarTipoFalla(BIMTipoFalla TipoFalla)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIMTipoFalla TipoFallaActualizable = unitWork.BIMTipoFalla.Find(c => c.IdTipoFalla == TipoFalla.IdTipoFalla).FirstOrDefault();
            if (TipoFallaActualizable != null)
            {
                TipoFallaActualizable.TipoFalla = TipoFalla.TipoFalla;
                TipoFallaActualizable.Estado = TipoFalla.Estado;
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public List<BIMHerramientas> ListaDeHerramientasAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMHerramientas> result = new List<BIMHerramientas>();
            var objetosResult = (from a in dimContext.BIMHerramientas
                                 orderby a.NombreHerramienta ascending
                                 select new
                                 {
                                     a.IdHerramienta,
                                     a.NombreHerramienta,
                                     a.Estado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMHerramientas());
                result[i].IdHerramienta = objetosResult[i].IdHerramienta;
                result[i].NombreHerramienta = objetosResult[i].NombreHerramienta;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public List<BIMTipoFalla> ListaTiposDeFallasAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMTipoFalla> result = new List<BIMTipoFalla>();
            var objetosResult = (from a in dimContext.BIMTipoFalla
                                 orderby a.TipoFalla ascending
                                 select new
                                 {
                                     a.IdTipoFalla,
                                     a.TipoFalla,
                                     a.Estado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMTipoFalla());
                result[i].IdTipoFalla = objetosResult[i].IdTipoFalla;
                result[i].TipoFalla = objetosResult[i].TipoFalla;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public List<BIMPrioridades> ListaDePrioridadesAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<BIMPrioridades> result = new List<BIMPrioridades>();
            var objetosResult = (from a in dimContext.BIMPrioridades
                                 orderby a.Prioridad ascending
                                 select new
                                 {
                                     a.IdPrioridad,
                                     a.Prioridad,
                                     a.Estado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIMPrioridades());
                result[i].IdPrioridad = objetosResult[i].IdPrioridad;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public BIPBitacoraIncidentes TraeIncidentePorCasoSD(string CasoSD)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BIPBitacoraIncidentes Incidente = unitWork.BIPBitacoraIncidentes.Find(c => c.CasoSD.Equals(CasoSD)).FirstOrDefault();
            if (Incidente != null)
            {
                return Incidente;
            }
            else
            {
                return new BIPBitacoraIncidentes();
            }
        }
        public List<BIPBitacoraIncidentes> ConsultaPrincipalIncidentes(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<BIPBitacoraIncidentes> result = new List<BIPBitacoraIncidentes>();
            var objetosResult = (from a in dimContext.BIPBitacoraIncidentes
                                 where a.FechaDeRegistro >= FechaInicial && a.FechaDeRegistro<=FechaFinal
                                 orderby a.IdRegistro ascending
                                 select new
                                 {
                                     a.IdRegistro,
                                     a.UsuarioCreacion,
                                     a.NombreUsuarioCreacion,
                                     a.FechaDeRegistro,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.CasoSD,
                                     a.IM,
                                     a.FechaDeCreacionTicket,
                                     a.FechaDeCierreTicket,
                                     a.FechaDeCierreAfectacion,
                                     a.Herramienta,
                                     a.TipoDeFalla,
                                     a.ModuloAfectado,
                                     a.DescripcionAfectacion,
                                     a.Prioridad,
                                     a.EscaladoA,
                                     a.CantidadUsuariosAfectados,
                                     a.ComentariosDeCierre,
                                     a.EstadoDelCaso,
                                     a.UsuarioGestionando
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BIPBitacoraIncidentes());
                result[i].IdRegistro = objetosResult[i].IdRegistro;
                result[i].UsuarioCreacion = objetosResult[i].UsuarioCreacion;
                result[i].NombreUsuarioCreacion = objetosResult[i].NombreUsuarioCreacion;
                result[i].FechaDeRegistro = objetosResult[i].FechaDeRegistro;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].CasoSD = objetosResult[i].CasoSD;
                result[i].IM = objetosResult[i].IM;
                result[i].FechaDeCreacionTicket = objetosResult[i].FechaDeCreacionTicket;
                result[i].FechaDeCierreTicket = objetosResult[i].FechaDeCierreTicket;
                result[i].FechaDeCierreAfectacion = objetosResult[i].FechaDeCierreAfectacion;
                result[i].Herramienta = objetosResult[i].Herramienta;
                result[i].TipoDeFalla = objetosResult[i].TipoDeFalla;
                result[i].ModuloAfectado = objetosResult[i].ModuloAfectado;
                result[i].DescripcionAfectacion = objetosResult[i].DescripcionAfectacion;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].EscaladoA = objetosResult[i].EscaladoA;
                result[i].CantidadUsuariosAfectados = objetosResult[i].CantidadUsuariosAfectados;
                result[i].ComentariosDeCierre = objetosResult[i].ComentariosDeCierre;
                result[i].EstadoDelCaso = objetosResult[i].EstadoDelCaso;
                result[i].UsuarioGestionando = objetosResult[i].UsuarioGestionando;

            }
            return result;

        }
        public List<BILBitacoraIncidentes> ConsultaLogIncidentes(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<BILBitacoraIncidentes> result = new List<BILBitacoraIncidentes>();
            var objetosResult = (from a in dimContext.BILBitacoraIncidentes
                                 where a.FechaUltimaActualizacion >= FechaInicial && a.FechaDeRegistro <= FechaFinal
                                 orderby a.IdRegistro ascending
                                 select new
                                 {
                                     a.Id,
                                     a.IdRegistro,
                                     a.UsuarioCreacion,
                                     a.NombreUsuarioCreacion,
                                     a.FechaDeRegistro,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.CasoSD,
                                     a.IM,
                                     a.FechaDeCreacionTicket,
                                     a.FechaDeCierreTicket,
                                     a.FechaDeCierreAfectacion,
                                     a.Herramienta,
                                     a.TipoDeFalla,
                                     a.ModuloAfectado,
                                     a.DescripcionAfectacion,
                                     a.Prioridad,
                                     a.EscaladoA,
                                     a.CantidadUsuariosAfectados,
                                     a.ComentariosDeCierre,
                                     a.EstadoDelCaso
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BILBitacoraIncidentes());
                result[i].Id = objetosResult[i].Id;
                result[i].IdRegistro = objetosResult[i].IdRegistro;
                result[i].UsuarioCreacion = objetosResult[i].UsuarioCreacion;
                result[i].NombreUsuarioCreacion = objetosResult[i].NombreUsuarioCreacion;
                result[i].FechaDeRegistro = objetosResult[i].FechaDeRegistro;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].CasoSD = objetosResult[i].CasoSD;
                result[i].IM = objetosResult[i].IM;
                result[i].FechaDeCreacionTicket = objetosResult[i].FechaDeCreacionTicket;
                result[i].FechaDeCierreTicket = objetosResult[i].FechaDeCierreTicket;
                result[i].FechaDeCierreAfectacion = objetosResult[i].FechaDeCierreAfectacion;
                result[i].Herramienta = objetosResult[i].Herramienta;
                result[i].TipoDeFalla = objetosResult[i].TipoDeFalla;
                result[i].ModuloAfectado = objetosResult[i].ModuloAfectado;
                result[i].DescripcionAfectacion = objetosResult[i].DescripcionAfectacion;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].EscaladoA = objetosResult[i].EscaladoA;
                result[i].CantidadUsuariosAfectados = objetosResult[i].CantidadUsuariosAfectados;
                result[i].ComentariosDeCierre = objetosResult[i].ComentariosDeCierre;
                result[i].EstadoDelCaso = objetosResult[i].EstadoDelCaso;
            }
            return result;

        }
    }

}
