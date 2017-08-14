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
            //registra incidente tabla principal
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DateTime Fecha = DateTime.Now;
            Bitacora.FechaDeRegistro = Fecha;
            Bitacora.FechaUltimaActualizacion = Fecha;
            Bitacora.EstadoDelCaso = "EN GESTION";
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
        public void EliminarIncidenteOperacion(decimal Id) {

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
    }
}
