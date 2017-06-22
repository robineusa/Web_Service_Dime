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
        public void InsertIngreso(Ingreso ingreso, string observacion, IngresosSoporte ingresoSoporte)
        {
            
                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            ingreso.FechaApertura = DateTime.Now;
            ingreso.HoraApertura = DateTime.Now;
            ingreso.FechaUltimaActualizacion = DateTime.Now;
            ingreso.UsuarioUltimaActualizacion = ingreso.UsuarioApertura;
            ingreso.HoraUltimaActualizacion = DateTime.Now;
            ingreso.Semaforo = "gris01.png";

            if (ingreso.IdEstado == 2)
                {
                    ingreso.FechaCierre = DateTime.Now;
                    ingreso.HoraCierre = DateTime.Now;
                    ingreso.UsuarioCierre = ingreso.UsuarioApertura;
                }
             unitWork.ingresos.Add(ingreso);
             unitWork.Complete();
            unitWork.Dispose();

            UnitOfWork unitWorkNotas = new UnitOfWork(new DimeContext());
            NotasIngreso logIngreso = new NotasIngreso();
            logIngreso.IdIngreso = ingreso.IdIngreso;
            logIngreso.CuentaCliente = ingreso.Cuenta;
            logIngreso.Ticket = ingreso.Ticket;
            logIngreso.Usuario = ingreso.UsuarioApertura;
            logIngreso.NombreLineaNota = ingreso.NombreLineaIngreso;
            logIngreso.FechaNota = DateTime.Now;
            logIngreso.HoraNota = DateTime.Now;
            logIngreso.LlamadaCliente = "SI";
            logIngreso.Nota = observacion.ToUpper().Trim();
            logIngreso.IdEstado = ingreso.IdEstado;
            unitWorkNotas.notasIngresos.Add(logIngreso);

                if (ingresoSoporte != null && (ingresoSoporte.TipoSegumiento.Equals("CELULA VISITA SOPORTE") || ingresoSoporte.TipoSegumiento.Equals("CELULA SEGUIMIENTO SOPORTE")))
                {
                    CompletarDatosIngresoSoporte(ingresoSoporte, ingreso);
                    InsertIngresoSoporte(ingresoSoporte, unitWorkNotas);
                }


            unitWorkNotas.Complete();


        }

        public void ActualizarIngresoPorAdmin(Ingreso ingreso, string notas, string cambioHecho)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            Ingreso ingresoActualizable = unitWork.ingresos.Get(Convert.ToInt32(ingreso.IdIngreso));
            DateTime fechaActual = DateTime.Now;
            if (cambioHecho.Equals("ESTADO"))
            {
                if (ingreso.IdEstado==2)
                {
                    ingresoActualizable.FechaCierre = fechaActual;
                    ingresoActualizable.HoraCierre = fechaActual;
                    ingresoActualizable.UsuarioCierre = ingreso.UsuarioUltimaActualizacion;
                }

                ingresoActualizable.IdEstado = ingreso.IdEstado;


            }
            if (cambioHecho.Equals("USUARIO"))
            {
                ingresoActualizable.UsuarioBackoffice = ingreso.UsuarioBackoffice;
    
            }
            if (cambioHecho.Equals("ESCALAR"))
            {
                ingresoActualizable.NombreLineaEscalado = ingreso.NombreLineaEscalado;
            }

            ingresoActualizable.UsuarioUltimaActualizacion = ingreso.UsuarioUltimaActualizacion;
            ingresoActualizable.FechaUltimaActualizacion = fechaActual;
            ingresoActualizable.HoraUltimaActualizacion = fechaActual;

            NotasIngreso logIngreso = new NotasIngreso();
            logIngreso.IdIngreso = ingresoActualizable.IdIngreso;
            logIngreso.CuentaCliente = ingresoActualizable.Cuenta;
            logIngreso.Ticket = ingresoActualizable.Ticket;
            logIngreso.Usuario = ingreso.UsuarioUltimaActualizacion;
            logIngreso.NombreLineaNota = ingreso.NombreLineaIngreso;
            logIngreso.FechaNota = fechaActual;
            logIngreso.HoraNota = fechaActual;
            logIngreso.LlamadaCliente = "NO";
            logIngreso.Nota = notas.ToUpper().Trim();
            logIngreso.IdEstado = ingresoActualizable.IdEstado;
            unitWork.notasIngresos.Add(logIngreso);

            unitWork.Complete();
        }

        public void InsertIngresoSoporte(IngresosSoporte ingresoSoporte, UnitOfWork unitWork)
        {
            unitWork.ingresosSoporte.Add(ingresoSoporte);
        }

        public void CompletarDatosIngresoSoporte(IngresosSoporte ingresoSoporte, Ingreso ingreso)
        {
            ingresoSoporte.IdIngreso = ingreso.IdIngreso;
            ingresoSoporte.Cuenta = ingreso.Cuenta;
            ingresoSoporte.Nombre = ingreso.Nombre;
            ingresoSoporte.Apellido = ingreso.Apellido;
            ingresoSoporte.IdIngreso = ingreso.IdIngreso;
            ingresoSoporte.IdServicio = ingreso.IdServicio;

        }

        public IngresosSoporte GetIngresoSoportePorId(int idIngreso)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
         return    unitWork.ingresosSoporte.Find(c => c.IdIngreso == idIngreso).LastOrDefault();
        }

        public UsuarioCollection GetUsuariosCelulaActual()
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UsuarioCollection result = new UsuarioCollection();
            result.AddRange(unitWork.usuarios.Find(c=>c.Linea.IdModoLogin ==3).Select(x=> new Usuario { Id = x.Id, Nombre= x.Nombre})     );
            return result;
        }

        public List<DatoConsultaGestionAdmin> ListaNotasIngresosYIngresosPorAliado(DateTime inicial, DateTime final, string aliado)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaGestionAdmin> result = new List<DatoConsultaGestionAdmin>();
            List<ConsultaGestionSqlReturnModel> resultBefore = new List<ConsultaGestionSqlReturnModel>();
            resultBefore = dimContext.ConsultaGestionSql(inicial, final, aliado);
            foreach (var item in resultBefore)
            {
                DatoConsultaGestionAdmin nuevoDato = new DatoConsultaGestionAdmin();
                nuevoDato.AliadoApertura = item.ALIADO_APERTURA;
                nuevoDato.CuentaCliente = item.Cuenta_cliente;
                nuevoDato.FechaApertura = item.FECHA_APERTURA;
                nuevoDato.FechaCierre = item.FECHA_CIERRE;
                nuevoDato.FechaNota = item.Fecha_nota;
                nuevoDato.FechaUltimaActualizacion = item.FECHA_ULTIMA_ACTUALIZACION;
                nuevoDato.HoraApertura = item.HORA_APERTURA;
                nuevoDato.HoraUltimaActualizacion = item.HORA_ULTIMA_ACTUALIZACION;
                nuevoDato.IdEstado = item.ID_ESTADO;
                nuevoDato.IdIngreso = item.Id_Ingreso;
                nuevoDato.Macroproceso = item.MACROPROCESO;
                nuevoDato.Marcacion = item.MARCACION;
                nuevoDato.NombreLineaEscalado = item.NOMBRE_LINEA_ESCALADO;
                nuevoDato.NombreLineaIngreso = item.NOMBRE_LINEA_INGRESO;
                nuevoDato.Nota = item.NOTA;
                nuevoDato.Usuario = item.Usuario.ToString();
                nuevoDato.UsuarioApertura = item.Usuario_Apertura.ToString();
                nuevoDato.UsuarioCierre = item.Usuario_Cierre.ToString();
                nuevoDato.UsuarioUltimaActualizacion = item.Usuario_Ult_Actualizacion.ToString();
                nuevoDato.Ticket = item.Ticket;

                result.Add(nuevoDato);
            }

            return result;
            
        }

        public List<DatoConsultaPaloteo> GetNotasIngresosYUsuarioData(string inicial, string final)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaPaloteo> result = new List<DatoConsultaPaloteo>();
            var resultBefore =  dimContext.ConsultaPaloteoSql(inicial, final);

            foreach(var item in resultBefore)
            {
                DatoConsultaPaloteo nuevoDato = new DatoConsultaPaloteo();
                nuevoDato.AliadoApertura = item.ALIADO_APERTURA;
                nuevoDato.Area = item.AREA;
                nuevoDato.CuentaCliente = item.CUENTA_CLIENTE;
                nuevoDato.Distrito = item.DISTRITO;
                nuevoDato.Division = item.DIVISION;
                nuevoDato.Estado = item.ID_ESTADO;
                nuevoDato.FechaInteraccion = item.FECHA_NOTA;
                nuevoDato.HoraInteraccion = item.HORA_NOTA;
                nuevoDato.IdIngreso = item.ID_INGRESO;
                nuevoDato.LlamadaCliente = item.LLAMADA_CLIENTE;
                nuevoDato.Macroproceso = item.MACROPROCESO;
                nuevoDato.Marcacion = item.MARCACION;
                nuevoDato.Nodo = item.NODO;
                nuevoDato.NombreComunidad = item.NOMBRE_COMUNIDAD;
                nuevoDato.NombreLineaNota = item.NOMBRE_LINEA_NOTA;
                nuevoDato.NombreUsuarioNota = item.NOMBRE;
                nuevoDato.Nota = item.NOTA;
                nuevoDato.RolUsuarioNota = item.PERFILROL;
                nuevoDato.Ticket = item.Ticket;
                nuevoDato.UsuarioNotaCC = item.UsuarioNotaCC.ToString();
                nuevoDato.Zona = item.ZONA;
                result.Add(nuevoDato);
            }

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
            result.AddRange(unitWork.ingresos.Find(c => c.IdIngreso == idDecimal).Select(x => new Ingreso
            {
                IdIngreso = x.IdIngreso,
                Cuenta = x.Cuenta,
                Ticket = x.Ticket,
                FechaApertura = x.FechaApertura,
                HoraApertura = x.HoraApertura,
                UsuarioApertura = x.UsuarioApertura,
                Macroproceso = x.Macroproceso,
                Marcacion = x.Marcacion,
                AliadoApertura = x.AliadoApertura,
                NombreLineaIngreso = x.NombreLineaIngreso,
                NombreLineaEscalado = x.NombreLineaEscalado,
                IdEstado = x.IdEstado,
                Semaforo = x.Semaforo,
                FechaUltimaActualizacion = x.FechaUltimaActualizacion,
                UsuarioUltimaActualizacion = x.UsuarioUltimaActualizacion,
                HoraUltimaActualizacion = x.HoraUltimaActualizacion,
                IdServicio = x.IdServicio,
                TiempoRespuesta = x.TiempoRespuesta
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

            DimeContext dimContext = new DimeContext();
            IngresoCollection result = new IngresoCollection();

            var resultBefore = (from x in dimContext.Ingresoes
                                join y in dimContext.Usuarios on x.UsuarioApertura equals y.Id.ToString()
                                where x.UsuarioBackoffice.Equals(usuario) && (x.IdEstado == 1 || x.IdEstado == 3)
                                select new
                                {
                                    IdIngreso = x.IdIngreso,
                                    Cuenta = x.Cuenta,
                                    Ticket = x.Ticket,
                                    FechaApertura = x.FechaApertura,
                                    HoraApertura = x.HoraApertura,
                                    UsuarioApertura = y.Cedula.ToString(),
                                    Macroproceso = x.Macroproceso,
                                    Marcacion = x.Marcacion,
                                    IdEstado = x.IdEstado,
                                    AliadoApertura = x.AliadoApertura,
                                    NombreLineaIngreso = x.NombreLineaIngreso,
                                    NombreLineaEscalado = x.NombreLineaEscalado,
                                    Semaforo = x.Semaforo
                                }).ToList();


            foreach(var x in resultBefore)
            {
                Ingreso nuevoIngreso = new Ingreso();
                nuevoIngreso.IdIngreso = x.IdIngreso;
                nuevoIngreso.Cuenta = x.Cuenta;
                nuevoIngreso.Ticket = x.Ticket;
                nuevoIngreso.FechaApertura = x.FechaApertura;
                nuevoIngreso.HoraApertura = x.HoraApertura;
                nuevoIngreso.UsuarioApertura = x.UsuarioApertura;
                nuevoIngreso.Macroproceso = x.Macroproceso;
                nuevoIngreso.Marcacion = x.Marcacion;
                nuevoIngreso.IdEstado = x.IdEstado;
                nuevoIngreso.AliadoApertura = x.AliadoApertura;
                nuevoIngreso.NombreLineaIngreso = x.NombreLineaIngreso;
                nuevoIngreso.NombreLineaEscalado = x.NombreLineaEscalado;
                nuevoIngreso.Semaforo = x.Semaforo;


                result.Add(nuevoIngreso);

            }

            return result;
        }
 

        public IngresoCollection GetCasosAbiertosDeCelulaUser(string lineaUser, string aliadoUser)
        {
            DimeContext dimeContext = new DimeContext();
            IngresoCollection result = new IngresoCollection();
            var resultBefore = (from a in dimeContext.Ingresoes
                                join b in dimeContext.Usuarios on a.UsuarioApertura equals b.Id.ToString()
                                where a.AliadoApertura.Equals(aliadoUser) && a.NombreLineaEscalado.Equals(lineaUser) &&
                                 a.UsuarioBackoffice.Equals(null) && a.IdEstado== 1
                                select new 
                                {
                                    IdIngreso = a.IdIngreso,
                                    Cuenta = a.Cuenta,
                                    Ticket = a.Ticket,
                                    FechaApertura = a.FechaApertura,
                                    HoraApertura = a.HoraApertura,
                                    UsuarioApertura = b.Cedula.ToString(),
                                    Macroproceso = a.Macroproceso,
                                    Marcacion = a.Marcacion,
                                    IdEstado = a.IdEstado,
                                    AliadoApertura = a.AliadoApertura,
                                    NombreLineaIngreso = a.NombreLineaIngreso,
                                    NombreLineaEscalado = a.NombreLineaEscalado,
                                    Semaforo = a.Semaforo
                                }).ToList();


            foreach (var item in resultBefore)
            {
                Ingreso nuevoIngreso = new Ingreso();
                nuevoIngreso.IdIngreso = item.IdIngreso;
                nuevoIngreso.Cuenta = item.Cuenta;
                nuevoIngreso.Ticket = item.Ticket;
                nuevoIngreso.FechaApertura = item.FechaApertura;
                nuevoIngreso.HoraApertura = item.HoraApertura;
                nuevoIngreso.UsuarioApertura = item.UsuarioApertura;
                nuevoIngreso.Macroproceso = item.Macroproceso;
                nuevoIngreso.Marcacion = item.Marcacion;
                nuevoIngreso.IdEstado = item.IdEstado;
                nuevoIngreso.AliadoApertura = item.AliadoApertura;
                nuevoIngreso.NombreLineaIngreso = item.NombreLineaIngreso;
                nuevoIngreso.NombreLineaEscalado = item.NombreLineaEscalado;
                nuevoIngreso.Semaforo = item.Semaforo;
                result.Add(nuevoIngreso);
            }


            return result;  
        }

        public void ActualizarIngreso(Ingreso ingreso, string observacion, string llamadaCliente, IngresosSoporte ingresoSoporte)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            Ingreso ingresoActualizable = unitWork.ingresos.Get(Convert.ToInt32(ingreso.IdIngreso));
            DateTime fechaActual = DateTime.Now;
            if (ingreso.IdEstado == 2)
            { 
                ingresoActualizable.FechaCierre = fechaActual;
                ingresoActualizable.HoraCierre = fechaActual;
                ingresoActualizable.UsuarioCierre = ingreso.UsuarioUltimaActualizacion;
            }
            if ( ingreso.IdEstado== 1 && !ingreso.NombreLineaEscalado.Equals(ingresoActualizable.NombreLineaEscalado))
            {
                ingresoActualizable.UsuarioBackoffice = null;
            }
            ingresoActualizable.UsuarioUltimaActualizacion = ingreso.UsuarioUltimaActualizacion;
            ingresoActualizable.FechaUltimaActualizacion = fechaActual;
            ingresoActualizable.HoraUltimaActualizacion = fechaActual;
            ingresoActualizable.Macroproceso = ingreso.Macroproceso;
            ingresoActualizable.Marcacion = ingreso.Marcacion;
            ingresoActualizable.IdEstado = ingreso.IdEstado;
            ingresoActualizable.Semaforo = "gris01.png";
            ingresoActualizable.TiempoRespuesta = ingreso.TiempoRespuesta;
            if(ingreso.IdEstado==1)
            ingresoActualizable.NombreLineaEscalado = ingreso.NombreLineaEscalado;
            ingresoActualizable.IdServicio = ingreso.IdServicio;

            NotasIngreso logIngreso = new NotasIngreso();
            logIngreso.IdIngreso = ingresoActualizable.IdIngreso;
            logIngreso.CuentaCliente = ingresoActualizable.Cuenta;
            logIngreso.Ticket = ingresoActualizable.Ticket;
            logIngreso.Usuario = ingreso.UsuarioUltimaActualizacion ;
            logIngreso.NombreLineaNota = ingreso.NombreLineaIngreso;
            logIngreso.FechaNota = fechaActual;
            logIngreso.HoraNota = fechaActual;
            logIngreso.LlamadaCliente = llamadaCliente;
            logIngreso.Nota = observacion.ToUpper().Trim();
            logIngreso.IdEstado = ingreso.IdEstado;
            unitWork.notasIngresos.Add(logIngreso);

            if (ingresoSoporte != null && ingresoSoporte.TipoSegumiento!= null && (ingresoSoporte.TipoSegumiento.Equals("CELULA VISITA SOPORTE") || ingresoSoporte.TipoSegumiento.Equals("CELULA SEGUIMIENTO SOPORTE")))
            {
                CompletarDatosIngresoSoporte(ingresoSoporte, ingresoActualizable);
                InsertIngresoSoporte(ingresoSoporte, unitWork);
            }
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
                          join n in dimContext.BasePersonalHoloes on c.Cedula equals n.Cedula into Details3 from n in Details3.DefaultIfEmpty()
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
                              AliadoUsuarioRechaza = n.Aliado
                          }).ToList();
            } else
            {

                result = new List<DatoConsultaRechazo>();
               var resultBefore =  dimContext.ConsultaRechazosAdminSql(fechaInicial, fechaFinal);

                foreach(var item in resultBefore)
                {
                    DatoConsultaRechazo nuevoDato = new DatoConsultaRechazo();
                    nuevoDato.IdIngreso = item.ID_INGRESO;
                    nuevoDato.FechaCreacionCaso = item.FECHA_CREACION_CASO;
                    nuevoDato.HoraCreacionCaso = item.HORA_CREACION_CASO;
                    nuevoDato.UsuarioCreacionCaso = item.Usuario_Creacion_Caso.ToString();
                    nuevoDato.NotasRechazo = item.NOTAS_RECHAZO;
                    nuevoDato.UsuarioRechaza = item.Usuario_Rechaza.ToString();
                    nuevoDato.FechaRechazo = item.FECHA_RECHAZO;
                    nuevoDato.HoraRechazo = item.HORA_RECHAZO;
                    nuevoDato.NombreUsuarioCreacion = item.Nombre_Usuario_Creacion;
                    nuevoDato.NombreUsuarioRechaza = item.Nombre_Usuario_Rechaza;
                    nuevoDato.NombreLineaUsuarioRechaza = item.Nombre_Linea_Usuario_Rechaza;
                    nuevoDato.AliadoUsuarioRechaza = item.Aliado_Usuario_Rechaza;
                    result.Add(nuevoDato);
                }

  

            }


            return result;
        }


        public void IngresarRechazo(Ingreso ingreso, string razonRechazo)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            Rechazo nuevoRechazo = new Rechazo();
            DateTime dateNow = DateTime.Now;
            nuevoRechazo.FechaCreacionCaso = ingreso.FechaApertura;
            nuevoRechazo.FechaRechazo = dateNow;
            nuevoRechazo.HoraCreacionCaso = ingreso.HoraApertura.ToString();
            nuevoRechazo.HoraRechazo = dateNow;
            nuevoRechazo.IdIngreso = ingreso.IdIngreso;
            nuevoRechazo.NotasRechazo = razonRechazo;
            nuevoRechazo.UsuarioCreacionCaso = unitWork.ingresos.Get(Convert.ToInt32(ingreso.IdIngreso)).UsuarioApertura;
            nuevoRechazo.UsuarioRechaza = ingreso.UsuarioApertura;
            unitWork.rechazos.Add(nuevoRechazo);
            unitWork.Complete();
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
                         join q in dimContext.Usuarios on c.UsuarioUltimaActualizacion equals q.Id.ToString() into Details2
                         from q in Details2.DefaultIfEmpty()
                         where m.Usuario.Equals(idUsuario) && m.FechaNota >= fechaInicial && m.FechaNota <= fechaFinal
                         select new { idIngreso = m.IdIngreso, cuentaClient = m.CuentaCliente, ticket = m.Ticket, nombLinea = c.NombreLineaIngreso,
                             nombLinEscalado = c.NombreLineaEscalado, aliadoApertura = c.AliadoApertura, fechaInteraccion = m.FechaNota,
                             fechaApertura = c.FechaApertura, horaApertura = c.HoraApertura, fechaCierre = c.FechaCierre, usuario = n.Cedula,
                             usuarioApertura = o.Cedula, usuarioCierre = p.Cedula, fechaUltActualizacion = c.FechaUltimaActualizacion,
                             usuarioUltimaActua = q.Cedula, horaUltActua = c.HoraUltimaActualizacion, macroproceso = c.Macroproceso,
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
                datoResult.Ingreso.UsuarioUltimaActualizacion = item.usuarioUltimaActua.ToString();
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
                                                                                                                } ).OrderByDescending(c=>c.IdIngreso).Take(20).ToList() );
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
                                    join m in dimeContext.Accesoes on c.IdAcceso equals m.Id
                                    join n in dimeContext.ModosLogins on m.IdModoLogin equals n.Id
                                    orderby c.FechaCreacion descending
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

   
        public bool UsrBackOfficeIngresoSetActualizar(int idIngreso, string usrBack)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            string usuarioActual = unitWork.ingresos.ActualizarComprobarUsuarioBackOffice(idIngreso, usrBack);
            if(usuarioActual.Equals(usrBack))
            {
                return false;
            }else
            {
                return true;
            }
        }

        public void InsertarRetencionInbound(Retencion retencion)
        {
            try
            {
                retencion.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.Retencion.Add(retencion);
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
        public RetencionCollection ListaRetencionInbound(DateTime inicial, DateTime final)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            RetencionCollection result = new RetencionCollection();

            result.AddRange(unitWork.Retencion.Find(c => c.FechaGestion >= inicial && c.FechaGestion <= final)
                .Select(x => new Retencion
                {
                    Id = x.Id,
                    FechaGestion = x.FechaGestion,
                    UsuarioGestion = x.UsuarioGestion,
                    NombreUsuarioGestion = x.NombreUsuarioGestion,
                    Cuenta = x.Cuenta,
                    Razon = x.Razon,
                    SubRazon = x.SubRazon,
                    Observaciones = x.Observaciones
                }));

            
            return result;

        }

    }
}
