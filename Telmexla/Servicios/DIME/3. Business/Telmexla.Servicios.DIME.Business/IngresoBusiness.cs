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

        public List<DatoConsultaPaloteo> GetNotasIngresosYUsuarioData(DateTime inicial, DateTime final)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaPaloteo> result = new List<DatoConsultaPaloteo>();

            result = (from a in dimContext.NotasIngresoes
                      join b in dimContext.Ingresoes on a.IdIngreso equals b.IdIngreso
                      join c in dimContext.Usuarios on a.Usuario equals c.Id.ToString()
                      join d in dimContext.ClientesTodoes on a.CuentaCliente equals d.Cuenta
                      where a.FechaNota >= inicial && a.FechaNota <= final && a.LlamadaCliente.Equals("SI")
                      select new DatoConsultaPaloteo
                      {
                       IdIngreso = a.IdIngreso,
                       CuentaCliente = a.CuentaCliente,
                       Ticket = a.Ticket,
                       LlamadaCliente = a.LlamadaCliente,
                       FechaInteraccion = a.FechaNota,
                       HoraInteraccion = a.HoraNota,
                       NombreLineaNota = a.NombreLineaNota,
                       UsuarioNotaCC = c.Cedula.ToString(),
                       NombreUsuarioNota = c.Nombre,
                       RolUsuarioNota = c.UsuariosXAccesoes.FirstOrDefault().Acceso.ModosLogin.Nombre,
                       AliadoApertura = b.AliadoApertura,
                       Macroproceso = b.Macroproceso,
                       Marcacion = b.Marcacion,
                       Division = d.Division,
                       Area = d.Area,
                       Zona = d.Zona,
                       Distrito = d.Distrito,
                       NombreComunidad = d.NombreComunidad,
                       Nodo = d.Nodo,
                       Nota = a.Nota,
                       Estado = b.IdEstado

                      }).ToList();
            return result;
        }



        public IngresoCollection ListaIngresosPorUsuarioCreacion(string ccUsuario)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoCollection result = new IngresoCollection();
            decimal decimalCedula = Convert.ToDecimal(ccUsuario);
            string idUsuario = unitWork.usuarios.Find(c => c.Cedula == decimalCedula).Select(x => x.Id).FirstOrDefault().ToString();
            result.AddRange(unitWork.ingresos.Find(c => c.UsuarioApertura == idUsuario).Select( x => new Ingreso
            {
                IdIngreso = x.IdIngreso,
                Cuenta = x.Cuenta,
                Ticket = x.Ticket,
                FechaApertura = x.FechaApertura,
                UsuarioApertura = x.UsuarioApertura,
                Macroproceso = x.Macroproceso,
                Marcacion = x.Marcacion,
                AliadoApertura = x.AliadoApertura,
                NombreLineaIngreso = x.NombreLineaIngreso,
                NombreLineaEscalado = x.NombreLineaEscalado,
                IdEstado = x.IdEstado,
                Semaforo = x.Semaforo
            }).ToList());
            return result;
        }

        public IngresoCollection GetIngresosPorCuentaPorTicket(string noTicket)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoCollection result = new IngresoCollection();
            decimal ticketDecimal = Convert.ToDecimal(noTicket);
            result.AddRange(unitWork.ingresos.Find(c => c.Ticket == ticketDecimal).Select(x => new Ingreso
            {
                IdIngreso = x.IdIngreso,
                Cuenta = x.Cuenta,
                Ticket = x.Ticket,
                FechaApertura = x.FechaApertura,
                UsuarioApertura = x.UsuarioApertura,
                Macroproceso = x.Macroproceso,
                Marcacion = x.Marcacion,
                AliadoApertura = x.AliadoApertura,
                NombreLineaIngreso = x.NombreLineaIngreso,
                NombreLineaEscalado = x.NombreLineaEscalado,
                IdEstado = x.IdEstado,
                Semaforo = x.Semaforo
            }).ToList());
            return result;
        }

        public IngresoCollection GetIngresoDeId(string id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoCollection result = new IngresoCollection();
            decimal idDecimal = Convert.ToDecimal(id);
            result.AddRange(unitWork.ingresos.Find(c => c.IdIngreso== idDecimal).Select(x => new Ingreso
            {
                IdIngreso = x.IdIngreso,
                Cuenta = x.Cuenta,
                Ticket = x.Ticket,
                FechaApertura = x.FechaApertura,
                UsuarioApertura = x.UsuarioApertura,
                Macroproceso = x.Macroproceso,
                Marcacion = x.Marcacion,
                AliadoApertura = x.AliadoApertura,
                NombreLineaIngreso = x.NombreLineaIngreso,
                NombreLineaEscalado = x.NombreLineaEscalado,
                IdEstado = x.IdEstado,
                Semaforo = x.Semaforo
            }).ToList());
            return result;
        }

        public IngresoCollection GetIngresosPorCuenta(string cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoCollection result = new IngresoCollection();
            decimal cuentaDecimal = Convert.ToDecimal(cuenta);
            result.AddRange(unitWork.ingresos.Find(c => c.Cuenta == cuentaDecimal).Select(x => new Ingreso { IdIngreso = x.IdIngreso,
                Cuenta = x.Cuenta, Ticket = x.Ticket, FechaApertura = x.FechaApertura, UsuarioApertura = x.UsuarioApertura, Macroproceso = x.Macroproceso,
              Marcacion = x.Marcacion, AliadoApertura=x.AliadoApertura, NombreLineaIngreso = x.NombreLineaIngreso, NombreLineaEscalado = x.NombreLineaEscalado,
            IdEstado = x.IdEstado, Semaforo = x.Semaforo} ).ToList());
            return result;

        }

        public List<GestionDeCelulaUsr> GetGestionesDeCelula(DateTime inicial, DateTime final, string idUsr)
        {

            DimeContext dimContext = new DimeContext();
            List<GestionDeCelulaUsr> result = new List<GestionDeCelulaUsr>();
            
            result = (from a in dimContext.NotasIngresoes
                      join b in dimContext.Ingresoes on a.IdIngreso equals b.IdIngreso
                      join c in dimContext.Usuarios on a.Usuario equals c.Id.ToString()
                      join d in dimContext.Usuarios on b.UsuarioApertura equals d.Id.ToString()
                      where a.FechaNota >= inicial && a.FechaNota <= final && a.Usuario.Equals(idUsr)
                      select new GestionDeCelulaUsr { CuentaCliente = a.CuentaCliente, FechaApertura = b.FechaApertura, FechaNota = a.FechaNota,
                                   HoraNota = a.HoraNota, IdEstado = b.IdEstado, IdIngreso = a.IdIngreso, IdNota= a.IdNota, Macroproceso = b.Macroproceso,
                                    Marcacion = b.Marcacion, NombreLineaEscalado = b.NombreLineaEscalado, NombreLineaIngreso = b.NombreLineaIngreso,
                                      Nota = a.Nota, Semaforo = b.Semaforo, Usuario = c.Cedula.ToString() , UsuarioApertura = d.Cedula.ToString() }).ToList();
            return result;
          }

        public IngresoCollection GetCasosEnSeguimiento(string usuario)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoCollection result = new IngresoCollection();
            result.AddRange(unitWork.ingresos.Find(c => 
           c.UsuarioBackoffice.Equals(usuario) && (c.IdEstado == 1 || c.IdEstado ==3 ) ).Select(x => new Ingreso
           {
               IdIngreso = x.IdIngreso,
               Cuenta = x.Cuenta,
               Ticket = x.Ticket,
               FechaApertura = x.FechaApertura,
               HoraApertura = x.HoraApertura,
               UsuarioApertura = x.UsuarioApertura,
               Macroproceso = x.Macroproceso,
               Marcacion = x.Marcacion,
               IdEstado = x.IdEstado,
               AliadoApertura = x.AliadoApertura,
               NombreLineaIngreso = x.NombreLineaIngreso,
               NombreLineaEscalado = x.NombreLineaEscalado,
               Semaforo = x.Semaforo
           }).ToList());
            return result;
        }
 

        public IngresoCollection GetCasosAbiertosDeCelulaUser(string lineaUser, string aliadoUser)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoCollection result = new IngresoCollection();
            result.AddRange(unitWork.ingresos.Find(c => c.AliadoApertura.Equals(aliadoUser) && c.NombreLineaEscalado.Equals(lineaUser) && 
             c.UsuarioBackoffice.Equals(null) && c.IdEstado == 1 ).Select(x => new Ingreso
            {
                IdIngreso = x.IdIngreso,
                Cuenta = x.Cuenta,
                Ticket = x.Ticket,
                FechaApertura = x.FechaApertura,
                HoraApertura = x.HoraApertura,
                UsuarioApertura = x.UsuarioApertura,
                Macroproceso = x.Macroproceso,
                Marcacion = x.Marcacion,
                IdEstado = x.IdEstado,
                AliadoApertura = x.AliadoApertura,
                NombreLineaIngreso = x.NombreLineaIngreso,
                NombreLineaEscalado = x.NombreLineaEscalado,
                Semaforo = x.Semaforo
            }).ToList());
            return result;  
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


        public List<DatoConsultaRechazo> TableRechazosInfo(DateTime fechaInicial, DateTime fechaFinal, string idUsuario, bool esPerfilAdmin)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaRechazo> result;
            if (!esPerfilAdmin)
            {
                 result = (from a in dimContext.Rechazoes
                                                    join b in dimContext.Usuarios on a.UsuarioCreacionCaso equals b.Id.ToString()
                                                    join c in dimContext.Usuarios on a.UsuarioRechaza equals c.Id.ToString()
                                                    join m in dimContext.Lineas on c.IdLinea equals m.Id
                                                    where a.UsuarioCreacionCaso.Equals(idUsuario) && a.FechaRechazo >= fechaInicial && a.FechaRechazo <= fechaFinal
                                                    select new DatoConsultaRechazo
                                                    {
                                                        IdIngreso = a.IdIngreso,
                                                        FechaCreacionCaso = a.FechaCreacionCaso,
                                                        HoraCreacionCaso = a.HoraCreacionCaso,
                                                        UsuarioCreacionCaso = b.Cedula.ToString(),
                                                        NotasRechazo = a.NotasRechazo,
                                                        UsuarioRechaza = c.Cedula.ToString(),
                                                        FechaRechazo = a.FechaRechazo,
                                                        HoraRechazo = a.HoraRechazo,
                                                        NombreUsuarioCreacion = b.Nombre,
                                                        NombreUsuarioRechaza = c.Nombre,
                                                        NombreLineaUsuarioRechaza = m.Nombre,
                                                        AliadoUsuarioRechaza = c.Aliado
                                                    }).ToList();
            }else
            {

                result = (from a in dimContext.Rechazoes
                                                    join b in dimContext.Usuarios on a.UsuarioCreacionCaso equals b.Id.ToString() into Details   from b in Details.DefaultIfEmpty()
                                                    join c in dimContext.Usuarios on a.UsuarioRechaza equals c.Id.ToString() into Details2 from c in Details.DefaultIfEmpty()
                                                     join m in dimContext.Lineas on c.IdLinea equals m.Id into Details3 from m in Details.DefaultIfEmpty()
                                                   where  a.FechaRechazo >= fechaInicial && a.FechaRechazo <= fechaFinal
                                                    select new DatoConsultaRechazo
                                                    {
                                                        IdIngreso = a.IdIngreso,
                                                        FechaCreacionCaso = a.FechaCreacionCaso,
                                                        HoraCreacionCaso = a.HoraCreacionCaso,
                                                        UsuarioCreacionCaso = b.Cedula.ToString(),
                                                        NotasRechazo = a.NotasRechazo,
                                                        UsuarioRechaza = c.Cedula.ToString(),
                                                        FechaRechazo = a.FechaRechazo,
                                                        HoraRechazo = a.HoraRechazo,
                                                        NombreUsuarioCreacion = b.Nombre,
                                                        NombreUsuarioRechaza = c.Nombre,
                                                        NombreLineaUsuarioRechaza = m.Nombre,
                                                        AliadoUsuarioRechaza = c.Aliado
                                                    }).ToList();

            }


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
            foreach(var item in result)
            {
                item.UsuarioApertura = unitWork.usuarios.Get(Convert.ToInt32(item.UsuarioApertura)).Cedula.ToString();
                item.UsuarioUltimaActualizacion = unitWork.usuarios.Get(Convert.ToInt32(item.UsuarioUltimaActualizacion)).Cedula.ToString();
            }
               

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

            foreach(var item in resultado)
            {
                item.Usuario = unitWork.usuarios.Get(Convert.ToInt32(item.Usuario)).Cedula.ToString();
            }


            return resultado;
                      
        }

   



    }
}
