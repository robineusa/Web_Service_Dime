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
    public class IngresoBusiness
    {
        public void InsertIngreso(Ingreso ingreso, string observacion)
        {
            try { 
            ingreso.FechaApertura = DateTime.Now;
            ingreso.HoraApertura = DateTime.Now;
            ingreso.FechaUltimaActualizacion = DateTime.Now;
            ingreso.UsuarioUltimaActualizacion = ingreso.UsuarioApertura;
            ingreso.HoraUltimaActualizacion = DateTime.Now;
            ingreso.Semaforo = "gris01.png";

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.ingresos.Add(ingreso);
            unitWork.Complete();
        

            NotasIngreso logIngreso = new NotasIngreso();
            logIngreso.IdIngreso = ingreso.IdIngreso;
            logIngreso.CuentaCliente = ingreso.Cuenta;
            logIngreso.Ticket = ingreso.Ticket;
            logIngreso.Usuario = ingreso.UsuarioApertura;
            logIngreso.NombreLineaNota = ingreso.NombreLineaIngreso;
            logIngreso.FechaNota = DateTime.Now;
            logIngreso.HoraNota = DateTime.Now;
            logIngreso.LlamadaCliente = "SI";
            logIngreso.Nota = observacion;
            logIngreso.IdEstado = ingreso.IdEstado;
            unitWork.notasIngresos.Add(logIngreso);
            unitWork.Complete();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }

        }

        public void ActualizarIngreso(Ingreso ingreso, string observacion, string llamadaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            Ingreso ingresoActualizable = unitWork.ingresos.Get(Convert.ToInt32(ingreso.IdIngreso));
            DateTime fechaActual = DateTime.Now;
            if (ingreso.IdEstado == 2)
            { 
                ingresoActualizable.FechaCierre = fechaActual;
                ingresoActualizable.HoraCierre = fechaActual;
                ingresoActualizable.UsuarioCierre = ingreso.UsuarioApertura;
            }
            ingresoActualizable.FechaUltimaActualizacion = fechaActual;
            ingresoActualizable.UsuarioUltimaActualizacion = ingreso.UsuarioApertura;
            ingresoActualizable.HoraUltimaActualizacion = ingreso.HoraUltimaActualizacion;
            ingresoActualizable.Macroproceso = ingreso.Macroproceso;
            ingresoActualizable.Marcacion = ingreso.Marcacion;
            ingresoActualizable.IdEstado = ingreso.IdEstado;
            ingresoActualizable.Semaforo = "gris01.png";
            ingresoActualizable.TiempoRespuesta = ingreso.TiempoRespuesta;
            ingresoActualizable.NombreLineaIngreso = ingreso.NombreLineaIngreso;
            ingresoActualizable.NombreLineaEscalado = ingreso.NombreLineaEscalado;
            ingresoActualizable.IdServicio = ingreso.IdServicio;

            NotasIngreso logIngreso = new NotasIngreso();
            logIngreso.IdIngreso = ingresoActualizable.IdIngreso;
            logIngreso.CuentaCliente = ingresoActualizable.Cuenta;
            logIngreso.Ticket = ingresoActualizable.Ticket;
            logIngreso.Usuario = ingreso.UsuarioApertura ;
            logIngreso.NombreLineaNota = ingreso.NombreLineaIngreso;
            logIngreso.FechaNota = fechaActual;
            logIngreso.HoraNota = fechaActual;
            logIngreso.LlamadaCliente = llamadaCliente;
            logIngreso.Nota = observacion;
            logIngreso.IdEstado = ingreso.IdEstado;
            unitWork.notasIngresos.Add(logIngreso);
            unitWork.Complete();
        }


        public List<DatoConsultaRechazo> TableRechazosInfo(DateTime fechaInicial, DateTime fechaFinal, string idUsuario)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaRechazo> result = (from a in dimContext.Rechazoes
                                                join b in dimContext.Usuarios on a.UsuarioCreacionCaso equals b.Id.ToString()
                                                join c in dimContext.Usuarios on a.UsuarioRechaza equals c.Id.ToString()
                                                join m in dimContext.Lineas on c.IdLinea equals m.Id
                                                 where a.UsuarioCreacionCaso.Equals(idUsuario) && a.FechaRechazo >= fechaInicial && a.FechaRechazo <= fechaFinal
                                                select new DatoConsultaRechazo { IdIngreso = a.IdIngreso, FechaCreacionCaso = a.FechaCreacionCaso, HoraCreacionCaso = a.HoraCreacionCaso,
                                                    UsuarioCreacionCaso = b.Cedula.ToString(), NotasRechazo = a.NotasRechazo, UsuarioRechaza = c.Cedula.ToString(),
                                                    FechaRechazo = a.FechaRechazo, HoraRechazo = a.HoraRechazo, NombreUsuarioCreacion = b.Nombre, NombreUsuarioRechaza = c.Nombre,
                                                    NombreLineaUsuarioRechaza = m.Nombre, AliadoUsuarioRechaza = c.Aliado }).ToList();

            return result;
        }

        public IngresoCollection SeguimientosInfo(string idUsuario)
        {
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            IngresoCollection result = new IngresoCollection();
            result.AddRange(unitwork.ingresos.Find(c => c.UsuarioApertura.Equals(idUsuario) && c.UsuarioBackoffice== null && 
                                                    c.IdEstado == 3 ).Select(x => new Ingreso
            {
                IdIngreso = x.IdIngreso,
                Cuenta = x.Cuenta,
                Ticket = x.Ticket,
                FechaApertura = x.FechaApertura,
                HoraApertura = x.HoraApertura,
                FechaCierre = x.FechaCierre,
                UsuarioApertura = x.UsuarioApertura,
                UsuarioCierre = x.UsuarioCierre,
                FechaUltimaActualizacion = x.FechaUltimaActualizacion,
                UsuarioUltimaActualizacion = x.UsuarioUltimaActualizacion,
                HoraUltimaActualizacion = x.HoraUltimaActualizacion,
                Macroproceso = x.Macroproceso,
                Marcacion = x.Marcacion,
                IdEstado = x.IdEstado,
                Semaforo = x.Semaforo
            }).ToList());

            return result;
        }

        public List<DatoConsultaGestion> TableGestionAsesor(DateTime fechaInicial, DateTime fechaFinal, string idUsuario)
        {
            DimeContext dimContext = new DimeContext();
            var datos = (from c in dimContext.Ingresoes
                         join m in dimContext.NotasIngresoes on c.IdIngreso equals m.IdIngreso
                         join n in dimContext.Usuarios on m.Usuario equals n.Id.ToString()
                         join o in dimContext.Usuarios on c.UsuarioApertura equals o.Id.ToString()
                         join p in dimContext.Usuarios on c.UsuarioCierre equals p.Id.ToString() into Details
                         from p in Details.DefaultIfEmpty()
                         where m.Usuario.Equals(idUsuario) && m.FechaNota >= fechaInicial && m.FechaNota <= fechaFinal
                         select new { idIngreso = m.IdIngreso, cuentaClient = m.CuentaCliente, ticket = m.Ticket, nombLinea = c.NombreLineaIngreso,
                             nombLinEscalado = c.NombreLineaEscalado, aliadoApertura = c.AliadoApertura, fechaInteraccion = m.FechaNota,
                             fechaApertura = c.FechaApertura, horaApertura = c.HoraApertura, fechaCierre = c.FechaCierre, usuario = n.Cedula,
                             usuarioApertura = o.Cedula, usuarioCierre = p.Cedula, fechaUltActualizacion = c.FechaUltimaActualizacion,
                             usuarioUltimaActua = c.UsuarioUltimaActualizacion, horaUltActua = c.HoraUltimaActualizacion, macroproceso = c.Macroproceso,
                             marcacion = c.Marcacion, nota = m.Nota, idEstado = c.IdEstado }).ToList();

            List<DatoConsultaGestion> result = new List<DatoConsultaGestion>();
            DatoConsultaGestion datoResult;
            foreach (var item in datos)
            {
                datoResult = new DatoConsultaGestion();
                datoResult.Ingreso.IdIngreso = item.idIngreso??0;
                datoResult.Ingreso.Cuenta = item.cuentaClient;
                datoResult.Ingreso.Ticket = item.ticket ?? 0;
                datoResult.Ingreso.NombreLineaIngreso = item.nombLinea;
                datoResult.Ingreso.NombreLineaEscalado = item.nombLinEscalado;
                datoResult.Ingreso.AliadoApertura = item.aliadoApertura;
                datoResult.Ingreso.FechaApertura = item.fechaApertura;
                datoResult.Ingreso.HoraApertura = item.horaApertura;
                datoResult.Ingreso.FechaCierre = item.fechaCierre;
                datoResult.Ingreso.UsuarioApertura = item.usuarioApertura.ToString();
                datoResult.Ingreso.UsuarioCierre = item.usuarioCierre.ToString();
                datoResult.Ingreso.FechaUltimaActualizacion = item.fechaUltActualizacion;
                datoResult.Ingreso.UsuarioUltimaActualizacion = item.usuarioUltimaActua;
                datoResult.Ingreso.HoraUltimaActualizacion = item.horaUltActua;
                datoResult.Ingreso.Macroproceso = item.macroproceso;
                datoResult.Ingreso.Marcacion = item.marcacion;
                datoResult.Ingreso.IdEstado = item.idEstado;
                datoResult.NotaIngreso.FechaNota = item.fechaInteraccion;
                datoResult.NotaIngreso.Nota = item.nota;
                datoResult.NotaIngreso.Usuario = item.usuario.ToString();
                result.Add(datoResult);
            }

            return result;
         }

  

        public Ingreso PonerDatosBasicosEnIngreso(ClientesTodo infoCliente, Ingreso ingreso)
        {

            ingreso.Cuenta = infoCliente.Cuenta;
            ingreso.HomePass = infoCliente.HomePass;
            ingreso.Nombre = infoCliente.Nombre;
            ingreso.Apellido = infoCliente.Apellido;
            ingreso.Cedula = infoCliente.Cedula;
            ingreso.Nodo = infoCliente.Nodo;
            ingreso.Red = infoCliente.Red;
            ingreso.Division = infoCliente.Division;
            ingreso.Area = infoCliente.Area;
            ingreso.Zona = infoCliente.Zona;
            ingreso.Distrito = infoCliente.Distrito;
            ingreso.NombreComunidad = infoCliente.NombreComunidad;
            ingreso.Departamento = infoCliente.Departamento;
            ingreso.Estrato = infoCliente.Estrato;
            ingreso.TipoCliente = infoCliente.TipoCliente;
            ingreso.Descripcion = infoCliente.Descripcion;
            ingreso.GrupoSeg = infoCliente.GrupoSeg;
            ingreso.Productos = infoCliente.Productos;
            return ingreso;
        }

        public IngresoCollection GetListaIngresos(string cuenta)
        {
            int cuentaEnt = Int32.Parse(cuenta);
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoCollection result = new IngresoCollection();
            result.AddRange(unitWork.ingresos.Find(c => c.Cuenta== cuentaEnt).Select(x=> new Ingreso {
                                                                                                            IdIngreso= x.IdIngreso,
                                                                                                            Ticket = x.Ticket,
                                                                                                            FechaApertura = x.FechaApertura,
                                                                                                            HoraApertura = x.HoraApertura,
                                                                                                            UsuarioApertura = x.UsuarioApertura,
                                                                                                            FechaUltimaActualizacion = x.FechaUltimaActualizacion,
                                                                                                            HoraUltimaActualizacion = x.HoraUltimaActualizacion,
                                                                                                            UsuarioUltimaActualizacion = x.UsuarioUltimaActualizacion,
                                                                                                            Macroproceso = x.Macroproceso,
                                                                                                            Marcacion = x.Marcacion,
                                                                                                            IdEstado = x.IdEstado,
                                                                                                            Semaforo = x.Semaforo
                                                                                                                } ).ToList() );
            return result;
        }



        public List<TablaActualizarInbound>  GetTablaActualizarInbound(int idIngreso)
        {
            List<TablaActualizarInbound> resultado = new List<TablaActualizarInbound>();

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<NotasIngreso> notasIngreso = unitWork.notasIngresos.Find(c=>c.IdIngreso == idIngreso).ToList();
            foreach(var item in notasIngreso)
            {
                TablaActualizarInbound row = new TablaActualizarInbound();
                row.CuentaCliente = item.CuentaCliente;
                row.FechaNota = item.FechaNota;
                row.HoraNota = item.HoraNota;
                row.IdEstado = item.IdEstado;
                row.IdIngreso = item.IdIngreso;
                row.LlamadaCliente = item.LlamadaCliente;
                row.NombreLineaNota = item.NombreLineaNota;
                row.Nota = item.Nota;
                int usuario = Convert.ToInt32(item.Usuario);
                DimeContext dimeContext = new DimeContext();
                var resultPerfil = (from c in dimeContext.UsuariosXAccesoes
                                    join m in dimeContext.Accesoes on c.IdUsuario equals m.Id
                                    join n in dimeContext.ModosLogins on m.IdModoLogin equals n.Id
                                    where c.IdUsuario == usuario
                                    select new { perfil = n.Nombre }).FirstOrDefault();

                if (resultPerfil != null) row.PerfilUsuario = resultPerfil.perfil; else row.PerfilUsuario = "No Registrado";

                row.Ticket = item.Ticket;
                row.Usuario = item.Usuario;

                resultado.Add(row);
            }


            return resultado;
                      
        }

   



    }
}
