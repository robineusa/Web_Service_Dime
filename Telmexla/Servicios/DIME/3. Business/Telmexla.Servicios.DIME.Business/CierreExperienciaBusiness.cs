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
    public class CierreExperienciaBusiness
    {
        /// <summary>
        /// Trae el registro asignado en la base de desconexiones por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CEPAsigDesconexiones TraeRegistroAsignacion(decimal Id)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            CEPAsigDesconexiones Registro = UnitOfWork.CEPAsigDesconexiones.Find(x => x.Id == Id).FirstOrDefault();
            return Registro;
        }
        /// <summary>
        /// Inserta una desconexion en la base de datos
        /// </summary>
        /// <param name="Desconexion"></param>
        /// <param name="IdBaseAsig"></param>
        public void RegistrarDesconexion(CEPDesconexiones Desconexion, decimal IdBaseAsig)
        {
            //trae la informacion del arbol
            UnitOfWork UnitOfWorkArbol = new UnitOfWork(new DimeContext());
            //Desconexion.Gestion = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.Gestion)).Descripcion;
            //Desconexion.Subrazon = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.Subrazon)).Descripcion;
            //Desconexion.CanalDeIngreso = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.CanalDeIngreso)).Descripcion;
            //Desconexion.TipoDeError = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.TipoDeError)).Descripcion;
            UnitOfWorkArbol.Complete();
            UnitOfWorkArbol.Dispose();

            //completa informacion de la desconexion
            Desconexion.FechaDeGestion = DateTime.Now;

            //registra desconexion
            UnitOfWork UnitOfWorkRegistro = new UnitOfWork(new DimeContext());
            UnitOfWorkRegistro.CEPDesconexiones.Add(Desconexion);
            UnitOfWorkRegistro.Complete();
            UnitOfWorkRegistro.Dispose();

            //registra log de desconexiones
            CELDesconexiones LogDex = new CELDesconexiones();
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());

            LogDex.IdGestion = Desconexion.IdGestion;
            LogDex.FechaDeTransaccion = Desconexion.FechaDeGestion;
            LogDex.UsuarioDeTransaccion = Desconexion.UsuarioDeGestion;
            LogDex.NombreUsuarioTransaccion = Desconexion.NombreUsuarioGestion;
            LogDex.CanalDeIngreso = Desconexion.CanalDeIngreso;
            LogDex.CuentaCliente = Desconexion.CuentaCliente;
            LogDex.Nota1 = Desconexion.Nota1;
            LogDex.Nota2 = Desconexion.Nota2;
            LogDex.FechaDeSolicitud = Desconexion.FechaDeSolicitud;
            LogDex.FechaDeCorte = Desconexion.FechaDeCorte;
            LogDex.FechaDePreaviso = Desconexion.FechaDePreaviso;
            LogDex.FechaDeAsignacion = Desconexion.FechaDeAsignacion;
            LogDex.Gestion = Desconexion.Gestion;
            LogDex.Subrazon = Desconexion.Subrazon;
            LogDex.Estado = Desconexion.Estado;
            LogDex.FechaDeSeguimiento = Desconexion.FechaDeSeguimiento;
            LogDex.MovieLetter = Desconexion.MovieLetter;
            LogDex.Ajuste = Desconexion.Ajuste;
            LogDex.CantidadServicio = Desconexion.CantidadServicio;
            LogDex.ErrorSolicitud = Desconexion.ErrorSolicitud;
            LogDex.UsuarioSolicitud = Desconexion.UsuarioSolicitud;
            LogDex.TipoDeError = Desconexion.TipoDeError;
            LogDex.Observaciones = Desconexion.Observaciones;

            UnitOfWorkLog.CELDesconexiones.Add(LogDex);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();

            //elimina el registro de la base de datos de asignacion
            if (IdBaseAsig > 0)
            {
                CEPAsigDesconexiones RegistroCargado = new CEPAsigDesconexiones();
                UnitOfWork UnitOfWorkElimina = new UnitOfWork(new DimeContext());
                RegistroCargado = UnitOfWorkElimina.CEPAsigDesconexiones.Find(x => x.Id == IdBaseAsig).FirstOrDefault();
                if (RegistroCargado.Id > 0)
                {
                    UnitOfWorkElimina.CEPAsigDesconexiones.Remove(RegistroCargado);
                    UnitOfWorkElimina.Complete();
                    UnitOfWorkElimina.Dispose();
                }
            }
        }
        /// <summary>
        /// Actualiza informacion de Desconexiones
        /// </summary>
        /// <param name="Desconexion"></param>
        public void ActualizarDesconexion(CEPDesconexiones Desconexion)
        {
            //trae la informacion del arbol
            UnitOfWork UnitOfWorkArbol = new UnitOfWork(new DimeContext());
            //Desconexion.Gestion = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.Gestion)).Descripcion;
            //Desconexion.Subrazon = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.Subrazon)).Descripcion;
            //Desconexion.CanalDeIngreso = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.CanalDeIngreso)).Descripcion;
            //Desconexion.TipoDeError = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.TipoDeError)).Descripcion;
            UnitOfWorkArbol.Complete();
            UnitOfWorkArbol.Dispose();

            //completa informacion de la desconexion
            Desconexion.FechaDeGestion = DateTime.Now;

            //actualiza desconexion
            UnitOfWork UnitOfWorkActualizable = new UnitOfWork(new DimeContext());
            CEPDesconexiones RegistroActualizable = UnitOfWorkActualizable.CEPDesconexiones.Get(Convert.ToInt32(Desconexion.IdGestion));

            RegistroActualizable.FechaDeGestion = Desconexion.FechaDeGestion;
            RegistroActualizable.UsuarioDeGestion = Desconexion.UsuarioDeGestion;
            RegistroActualizable.NombreUsuarioGestion = Desconexion.NombreUsuarioGestion;
            RegistroActualizable.CanalDeIngreso = Desconexion.CanalDeIngreso;
            RegistroActualizable.CuentaCliente = Desconexion.CuentaCliente;
            RegistroActualizable.Nota1 = Desconexion.Nota1;
            RegistroActualizable.Nota2 = Desconexion.Nota2;
            RegistroActualizable.FechaDeSolicitud = Desconexion.FechaDeSolicitud;
            RegistroActualizable.FechaDeCorte = Desconexion.FechaDeCorte;
            RegistroActualizable.FechaDePreaviso = Desconexion.FechaDePreaviso;
            RegistroActualizable.FechaDeAsignacion = Desconexion.FechaDeAsignacion;
            RegistroActualizable.Gestion = Desconexion.Gestion;
            RegistroActualizable.Subrazon = Desconexion.Subrazon;
            RegistroActualizable.Estado = Desconexion.Estado;
            RegistroActualizable.FechaDeSeguimiento = Desconexion.FechaDeSeguimiento;
            RegistroActualizable.MovieLetter = Desconexion.MovieLetter;
            RegistroActualizable.Ajuste = Desconexion.Ajuste;
            RegistroActualizable.CantidadServicio = Desconexion.CantidadServicio;
            RegistroActualizable.ErrorSolicitud = Desconexion.ErrorSolicitud;
            RegistroActualizable.UsuarioSolicitud = Desconexion.UsuarioSolicitud;
            RegistroActualizable.TipoDeError = Desconexion.TipoDeError;
            RegistroActualizable.Observaciones = Desconexion.Observaciones;

            UnitOfWorkActualizable.Complete();
            UnitOfWorkActualizable.Dispose();

            //registra log de desconexiones
            CELDesconexiones LogDex = new CELDesconexiones();
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());

            LogDex.IdGestion = Desconexion.IdGestion;
            LogDex.FechaDeTransaccion = Desconexion.FechaDeGestion;
            LogDex.UsuarioDeTransaccion = Desconexion.UsuarioDeGestion;
            LogDex.NombreUsuarioTransaccion = Desconexion.NombreUsuarioGestion;
            LogDex.CanalDeIngreso = Desconexion.CanalDeIngreso;
            LogDex.CuentaCliente = Desconexion.CuentaCliente;
            LogDex.Nota1 = Desconexion.Nota1;
            LogDex.Nota2 = Desconexion.Nota2;
            LogDex.FechaDeSolicitud = Desconexion.FechaDeSolicitud;
            LogDex.FechaDeCorte = Desconexion.FechaDeCorte;
            LogDex.FechaDePreaviso = Desconexion.FechaDePreaviso;
            LogDex.FechaDeAsignacion = Desconexion.FechaDeAsignacion;
            LogDex.Gestion = Desconexion.Gestion;
            LogDex.Subrazon = Desconexion.Subrazon;
            LogDex.Estado = Desconexion.Estado;
            LogDex.FechaDeSeguimiento = Desconexion.FechaDeSeguimiento;
            LogDex.MovieLetter = Desconexion.MovieLetter;
            LogDex.Ajuste = Desconexion.Ajuste;
            LogDex.CantidadServicio = Desconexion.CantidadServicio;
            LogDex.ErrorSolicitud = Desconexion.ErrorSolicitud;
            LogDex.UsuarioSolicitud = Desconexion.UsuarioSolicitud;
            LogDex.TipoDeError = Desconexion.TipoDeError;
            LogDex.Observaciones = Desconexion.Observaciones;

            UnitOfWorkLog.CELDesconexiones.Add(LogDex);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();
            
        }
        /// <summary>
        /// Trae lista de arboles para los desplegables
        /// </summary>
        /// <param name="IdPadre"></param>
        /// <returns></returns>
        public List<CEMArbolesDeGestion> ArbolDeGestionAgente(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<CEMArbolesDeGestion> Lista = new List<CEMArbolesDeGestion>();
            Lista = unitOfWork.CEMArbolesDeGestion.Find(x => x.IdPadre == IdPadre ).ToList();
            Lista = Lista.OrderBy(x => x.Descripcion).ToList();
            return Lista;
        }
        /// <summary>
        /// Actualiza la informacion del Arbol
        /// </summary>
        /// <param name="Arbol"></param>
        public void ActualizarArbolCierreExperiencia(CEMArbolesDeGestion Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            CEMArbolesDeGestion ArbolActualizable = new CEMArbolesDeGestion();
               ArbolActualizable= unitOfWork.CEMArbolesDeGestion.Find(x => x.IdArbol == Arbol.IdArbol).FirstOrDefault();
            if (ArbolActualizable.IdArbol > 0)
            {
                ArbolActualizable.IdPadre = Arbol.IdPadre;
                ArbolActualizable.Descripcion = Arbol.Descripcion;
                ArbolActualizable.EstadoDeGestion = Arbol.EstadoDeGestion;
                ArbolActualizable.EstadoArbol = Arbol.EstadoArbol;
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        /// <summary>
        /// Inserta un nuevo arbol en la base de datos
        /// </summary>
        /// <param name="Arbol"></param>
        public void RegistrarNuevoArbolCierreExperiencia(CEMArbolesDeGestion Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            unitOfWork.CEMArbolesDeGestion.Add(Arbol);
            unitOfWork.Complete();
            unitOfWork.Dispose();
        }
        /// <summary>
        /// Trae la informacion del Arbol por Id
        /// </summary>
        /// <param name="IdArbol"></param>
        /// <returns></returns>
        public CEMArbolesDeGestion TraerArbolCierreExperienciaPorId(decimal IdArbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            CEMArbolesDeGestion Arbol = new CEMArbolesDeGestion();
             Arbol=   unitOfWork.CEMArbolesDeGestion.Find(x => x.IdArbol == IdArbol).FirstOrDefault();
            if (Arbol.IdArbol > 0)
            {
                return Arbol;
            }
            else
            {
                return new CEMArbolesDeGestion();
            }
        }
        /// <summary>
        /// Trae lista de Seguimientos del Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<CEPDesconexiones> ListaSeguimientosAgenteCierreExperiencia(decimal Usuario)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CEPDesconexiones> Lista = new List<CEPDesconexiones>();
               Lista = UnitOfWorkBusqueda.CEPDesconexiones.Find(x => x.UsuarioDeGestion == Usuario && x.Estado.Equals("SEGUIMIENTO")).ToList();
            Lista = Lista.OrderBy(x => x.IdGestion).ToList();
            return Lista;
        }
        /// <summary>
        /// Trae Lista de Gestion realizaada por el usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<CELDesconexiones> ListaDeGestionAgenteCierreExperiencia(decimal Usuario)
        {

            DateTime FechaInicial;
            DateTime FechaFinal;
            FechaInicial = DateTime.Today;
            FechaFinal = FechaInicial.AddDays(1);
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELDesconexiones> Lista = new List<CELDesconexiones>();
               Lista = UnitOfWorkBusqueda.CELDesconexiones.Find(x => x.UsuarioDeTransaccion == Usuario && x.FechaDeTransaccion>= FechaInicial && x.FechaDeTransaccion<= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        /// <summary>
        /// Lista de Gestion Principal - Consulta Administrador
        /// </summary>
        /// <param name="FechaInicial"></param>
        /// <param name="FechaFinal"></param>
        /// <returns></returns>
        public List<CEPDesconexiones> ConsultaGeneralAdministradorCierreExperiencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CEPDesconexiones> Lista = new List<CEPDesconexiones>();
               Lista= UnitOfWorkBusqueda.CEPDesconexiones.Find(x => x.FechaDeGestion>= FechaInicial && x.FechaDeGestion<= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdGestion).ToList();
            return Lista;
        }
        /// <summary>
        /// Lista de Gestion Log - Consulta Administrador
        /// </summary>
        /// <param name="FechaInicial"></param>
        /// <param name="FechaFinal"></param>
        /// <returns></returns>
        public List<CELDesconexiones> ConsultaLogAdministradorCierreExperiencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELDesconexiones> Lista = new List<CELDesconexiones>();
              Lista=  UnitOfWorkBusqueda.CELDesconexiones.Find(x => x.FechaDeTransaccion >= FechaInicial && x.FechaDeTransaccion <= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        /// <summary>
        /// Trae desconexion por id de gestion
        /// </summary>
        /// <param name="IdGestion"></param>
        /// <returns></returns>
        public CEPDesconexiones TraeDesconexionPorId(decimal IdGestion)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPDesconexiones Registro = new CEPDesconexiones();
               Registro= UnitOfWorkBusqueda.CEPDesconexiones.Find(x => x.IdGestion == IdGestion).FirstOrDefault();
            return Registro;
        }
        public CEPAsigDesconexiones ApartarCuentadeDesconexiones(decimal Cedula, int noRecursividad)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<decimal> solicitud = unitWork.CEPAsigDesconexiones.Find(c => c.UsuarioGestionando == Cedula).Select(x => x.Id).ToList();
            if (solicitud.Count > 0)
            {
                CEPAsigDesconexiones solicitudencontrada = new CEPAsigDesconexiones();
                return TraeRegistroAsignacion(solicitud[0]);
            }
            else
            {
                unitWork.CEPDesconexiones.ApartarCuentaGestionDesconexiones(Cedula);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return ApartarCuentadeDesconexiones(Cedula, noRecursividad);
            }
        }
        public List<CEMArbolesDeGestion> ListasDeArbolesCierreExperienciaAdmin(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<CEMArbolesDeGestion> Lista = new List<CEMArbolesDeGestion>();
            Lista = unitOfWork.CEMArbolesDeGestion.Find(x => x.IdPadre == IdPadre).ToList();
            Lista = Lista.OrderBy(x => x.Descripcion).ToList();
            return Lista;
        }
        public List<CELDesconexiones> ConsultaDeGestionDesconexionesAgente(DateTime FechaInicial,DateTime FechaFinal,decimal Usuario)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELDesconexiones> Lista = new List<CELDesconexiones>();
             Lista=   UnitOfWorkBusqueda.CELDesconexiones.Find(x => x.UsuarioDeTransaccion == Usuario && x.FechaDeTransaccion >= FechaInicial && x.FechaDeTransaccion <= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        public CEPAsigDesconexiones ValidarCuentaAsignada(decimal Cedula, int noRecursividad, decimal CuentaCliente)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPAsigDesconexiones cuenta = new CEPAsigDesconexiones();
               cuenta= UnitOfWorkBusqueda.CEPAsigDesconexiones.Find(x => x.CuentaCliente == CuentaCliente).FirstOrDefault();
            if(cuenta!= null)
            {
                cuenta.UsuarioGestionando = Cedula;
                UnitOfWorkBusqueda.Complete();
                UnitOfWorkBusqueda.Dispose();
               return ApartarCuentadeDesconexiones(Cedula,noRecursividad);
            }
            else { return cuenta; }
        }
        public CEPDesconexiones ConsultarCuentaDesconexionporCuenta(decimal Cuenta)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPDesconexiones Desconexion = new CEPDesconexiones();
            Desconexion= UnitOfWorkBusqueda.CEPDesconexiones.Find(x => x.CuentaCliente == Cuenta && x.FechaDeGestion>= fecha1 && x.FechaDeGestion<= fecha2).FirstOrDefault();
            if(Desconexion!= null)
            {
                return TraeDesconexionPorId(Desconexion.IdGestion);
            }else
            {
                return Desconexion;
            }
        }
        //proceso tickets
        public void RegistrarTicketBase(CEPTickets Ticket)
        {
            
            //completa informacion de la fecha de gestion
            Ticket.FechaDeGestion = DateTime.Now;

            //registra ticket
            UnitOfWork UnitOfWorkRegistro = new UnitOfWork(new DimeContext());
            UnitOfWorkRegistro.CEPTickets.Add(Ticket);
            UnitOfWorkRegistro.Complete();
            UnitOfWorkRegistro.Dispose();

            //registra log de tickets
            CELTickets Log = new CELTickets();
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());

            Log.IdGestion = Ticket.IdGestion;
            Log.FechaDeTransaccion = Ticket.FechaDeGestion;
            Log.UsuarioDeTransaccion = Ticket.UsuarioDeGestion;
            Log.NombreUsuarioTransaccion = Ticket.NombreUsuarioGestion;
            Log.CanaldeIngreso = Ticket.CanaldeIngreso;
            Log.CuentaCliente = Ticket.CuentaCliente;
            Log.NumeroDeTicket = Ticket.NumeroDeTicket;
            Log.UsuarioDeCreacion = Ticket.UsuarioDeCreacion;
            Log.FechaDeCreacion = Ticket.FechaDeCreacion;
            Log.Srcaus = Ticket.Srcaus;
            Log.Srreas = Ticket.Srreas;
            Log.Nota1 = Ticket.Nota1;
            Log.Nota2 = Ticket.Nota2;
            Log.Gestion = Ticket.Gestion;
            Log.Razon = Ticket.Razon;
            Log.Subrazon = Ticket.Subrazon;
            Log.Estado = Ticket.Estado;
            Log.Ajuste = Ticket.Ajuste;
            Log.FechaDeSeguimiento = Ticket.FechaDeSeguimiento;
            Log.FechaDeCancelacion = Ticket.FechaDeCancelacion;
            Log.MarcacionCancelacion = Ticket.MarcacionCancelacion;
            Log.UsuarioDeCancelacion = Ticket.UsuarioDeCancelacion;
            Log.UsuarioDeRetencion = Ticket.UsuarioDeRetencion;
            Log.ServiciosDesconectados = Ticket.ServiciosDesconectados;
            Log.Observaciones = Ticket.Observaciones;

            UnitOfWorkLog.CELTickets.Add(Log);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();
            
        }
        public void ActualizarTicket(CEPTickets Ticket)
        {

            //completa informacion de la fecha de gestion
            Ticket.FechaDeGestion = DateTime.Now;

            //busca la informacion del ticket actual
            UnitOfWork UnitOftWorkBuequeda = new UnitOfWork(new DimeContext());
            CEPTickets ticketencontrado = new CEPTickets();
            ticketencontrado = UnitOftWorkBuequeda.CEPTickets.Find(x => x.NumeroDeTicket == Ticket.NumeroDeTicket).FirstOrDefault();

            ticketencontrado.FechaDeGestion = Ticket.FechaDeGestion;
            ticketencontrado.UsuarioDeGestion = Ticket.UsuarioDeGestion;
            ticketencontrado.NombreUsuarioGestion = Ticket.NombreUsuarioGestion;
            ticketencontrado.CanaldeIngreso = Ticket.CanaldeIngreso;
            ticketencontrado.CuentaCliente = Ticket.CuentaCliente;
            ticketencontrado.NumeroDeTicket = Ticket.NumeroDeTicket;
            ticketencontrado.UsuarioDeCreacion = Ticket.UsuarioDeCreacion;
            ticketencontrado.FechaDeCreacion = Ticket.FechaDeCreacion;
            ticketencontrado.Srcaus = Ticket.Srcaus;
            ticketencontrado.Srreas = Ticket.Srreas;
            ticketencontrado.Nota1 = Ticket.Nota1;
            ticketencontrado.Nota2 = Ticket.Nota2;
            ticketencontrado.Gestion = Ticket.Gestion;
            ticketencontrado.Razon = Ticket.Razon;
            ticketencontrado.Subrazon = Ticket.Subrazon;
            ticketencontrado.Estado = Ticket.Estado;
            ticketencontrado.Ajuste = Ticket.Ajuste;
            ticketencontrado.FechaDeSeguimiento = Ticket.FechaDeSeguimiento;
            ticketencontrado.FechaDeCancelacion = Ticket.FechaDeCancelacion;
            ticketencontrado.MarcacionCancelacion = Ticket.MarcacionCancelacion;
            ticketencontrado.UsuarioDeCancelacion = Ticket.UsuarioDeCancelacion;
            ticketencontrado.UsuarioDeRetencion = Ticket.UsuarioDeRetencion;
            ticketencontrado.ServiciosDesconectados = Ticket.ServiciosDesconectados;
            ticketencontrado.Observaciones = Ticket.Observaciones;

            UnitOftWorkBuequeda.Complete();
            UnitOftWorkBuequeda.Dispose();
            
            //registra log de tickets
            CELTickets Log = new CELTickets();
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());

            Log.IdGestion = Ticket.IdGestion;
            Log.FechaDeTransaccion = Ticket.FechaDeGestion;
            Log.UsuarioDeTransaccion = Ticket.UsuarioDeGestion;
            Log.NombreUsuarioTransaccion = Ticket.NombreUsuarioGestion;
            Log.CanaldeIngreso = Ticket.CanaldeIngreso;
            Log.CuentaCliente = Ticket.CuentaCliente;
            Log.NumeroDeTicket = Ticket.NumeroDeTicket;
            Log.UsuarioDeCreacion = Ticket.UsuarioDeCreacion;
            Log.FechaDeCreacion = Ticket.FechaDeCreacion;
            Log.Srcaus = Ticket.Srcaus;
            Log.Srreas = Ticket.Srreas;
            Log.Nota1 = Ticket.Nota1;
            Log.Nota2 = Ticket.Nota2;
            Log.Gestion = Ticket.Gestion;
            Log.Razon = Ticket.Razon;
            Log.Subrazon = Ticket.Subrazon;
            Log.Estado = Ticket.Estado;
            Log.Ajuste = Ticket.Ajuste;
            Log.FechaDeSeguimiento = Ticket.FechaDeSeguimiento;
            Log.FechaDeCancelacion = Ticket.FechaDeCancelacion;
            Log.MarcacionCancelacion = Ticket.MarcacionCancelacion;
            Log.UsuarioDeCancelacion = Ticket.UsuarioDeCancelacion;
            Log.UsuarioDeRetencion = Ticket.UsuarioDeRetencion;
            Log.ServiciosDesconectados = Ticket.ServiciosDesconectados;
            Log.Observaciones = Ticket.Observaciones;

            UnitOfWorkLog.CELTickets.Add(Log);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();

        }
        public CEPTickets ConsultaDeTicketPorNumero(decimal IdGestion)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPTickets Ticket = new CEPTickets();
            Ticket = UnitOfWorkBusqueda.CEPTickets.Find(x => x.IdGestion == IdGestion).FirstOrDefault();
            return Ticket;
        }
        public List<CELTickets> ConsultaDeGestionTicketsAgente(DateTime FechaInicial, DateTime FechaFinal, decimal Usuario)
        {
            FechaInicial = DateTime.Today;
            FechaFinal = FechaInicial.AddDays(1);
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELTickets> Lista = new List<CELTickets>();
            Lista = UnitOfWorkBusqueda.CELTickets.Find(x => x.UsuarioDeTransaccion == Usuario && x.FechaDeTransaccion >= FechaInicial && x.FechaDeTransaccion <= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        public List<CELTickets> ListaDeGestionAgenteTicketsCierreExperiencia(decimal Usuario)
        {

            DateTime FechaInicial;
            DateTime FechaFinal;
            FechaInicial = DateTime.Today;
            FechaFinal = FechaInicial.AddDays(1);
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELTickets> Lista = new List<CELTickets>();
            Lista = UnitOfWorkBusqueda.CELTickets.Find(x => x.UsuarioDeTransaccion == Usuario && x.FechaDeTransaccion >= FechaInicial && x.FechaDeTransaccion <= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        public List<CEPTickets> ListaSeguimientosAgenteTicketCierreExperiencia(decimal Usuario)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CEPTickets> Lista = new List<CEPTickets>();
            Lista = UnitOfWorkBusqueda.CEPTickets.Find(x => x.UsuarioDeGestion == Usuario && x.Estado.Equals("SEGUIMIENTO")).ToList();
            Lista = Lista.OrderBy(x => x.IdGestion).ToList();
            return Lista;
        }
        public List<MaestroMarcacione> ListaSrcaus()
        {
            DimeContext dimContext = new DimeContext();
            List<MaestroMarcacione> result = new List<MaestroMarcacione>();
            var objetosResult = (from a in dimContext.MaestroMarcaciones
                                 orderby a.Razon ascending
                                 select new
                                 {
                                     a.Razon,
                                 }
                                 ).Distinct().ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MaestroMarcacione());
                result[i].Razon = objetosResult[i].Razon;

            }
            return result;
        }
        public List<MaestroMarcacione> ListaSrreas(string Razon)
        {
            DimeContext dimContext = new DimeContext();
            List<MaestroMarcacione> result = new List<MaestroMarcacione>();
            var objetosResult = (from a in dimContext.MaestroMarcaciones
                                 where a.Razon.Equals(Razon)
                                 orderby a.Subrazon ascending
                                 select new
                                 {
                                     a.Subrazon,
                                 }
                                 ).Distinct().ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MaestroMarcacione());
                
                if (objetosResult[i].Subrazon == "" || objetosResult[i].Subrazon == null)
                {
                    var Subrazon = "NO APLICA";
                    result[i].Subrazon = Subrazon;
                }
                else
                {
                    result[i].Subrazon = objetosResult[i].Subrazon;
                }
            }
            return result;
        }
        public List<MaestroMarcacione> ListaMarcacionesTickets()
        {
            DimeContext dimContext = new DimeContext();
            List<MaestroMarcacione> result = new List<MaestroMarcacione>();
            var objetosResult = (from a in dimContext.MaestroMarcaciones
                                 orderby a.Submarcacion ascending
                                 select new
                                 {
                                     a.Submarcacion,
                                 }
                                 ).Distinct().ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MaestroMarcacione());
                result[i].Submarcacion = objetosResult[i].Submarcacion;

            }
            return result;
        }
        public CEPTickets ConsultaDeTicketPorTicket(decimal Ticket)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPTickets TicketEncontrado = new CEPTickets();
            TicketEncontrado = UnitOfWorkBusqueda.CEPTickets.Find(x => x.NumeroDeTicket == Ticket).FirstOrDefault();
            return TicketEncontrado;
        }
        //procesos suspenciones temporales
        public void RegistrarSuspencion (CEPSuspensiones Suspencion, decimal IdAsignacion)
        {
            //genera informacion adicional
            Suspencion.FechaGestion = DateTime.Now;

            //registra informacion en tabla principal
            UnitOfWork UnitOfWorkGuardado = new UnitOfWork(new DimeContext());
            UnitOfWorkGuardado.CEPSuspensiones.Add(Suspencion);
            UnitOfWorkGuardado.Complete();
            UnitOfWorkGuardado.Dispose();

            //Registra informacion en el log
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());
            CELSuspensiones Log = new CELSuspensiones();

            Log.IdGestion = Suspencion.IdGestion;
            Log.FechaDeTransaccion = Suspencion.FechaGestion;
            Log.UsuarioDeTransaccion = Suspencion.UsuarioDeGestion;
            Log.NombreUsuarioTransaccion = Suspencion.NombreUsuarioGestion;
            Log.CuentaCliente = Suspencion.CuentaCliente;
            Log.CanalDeIngreso = Suspencion.CanalDeIngreso;
            Log.FechaCreacion = Suspencion.FechaCreacion;
            Log.UsuarioCreacion = Suspencion.UsuarioCreacion;
            Log.ServiciosSuspender = Suspencion.ServiciosSuspender;
            Log.MotivosSuspension = Suspencion.MotivosSuspension;
            Log.MesesSuspender = Suspencion.MesesSuspender;
            Log.Gestion = Suspencion.Gestion;
            Log.Subrazon = Suspencion.Subrazon;
            Log.Estado = Suspencion.Estado;
            Log.FechaSeguimiento = Suspencion.FechaSeguimiento;
            Log.Observaciones = Suspencion.Observaciones;

            UnitOfWorkLog.CELSuspensiones.Add(Log);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();

            //elimina el registro de la base de datos de asignacion
            if (IdAsignacion > 0)
            {
                CEPAsigSuspenciones RegistroCargado = new CEPAsigSuspenciones();
                UnitOfWork UnitOfWorkElimina = new UnitOfWork(new DimeContext());
                RegistroCargado = UnitOfWorkElimina.CEPAsigSuspenciones.Find(x => x.IdAsignacion == IdAsignacion).FirstOrDefault();
                if (RegistroCargado.IdAsignacion > 0)
                {
                    UnitOfWorkElimina.CEPAsigSuspenciones.Remove(RegistroCargado);
                    UnitOfWorkElimina.Complete();
                    UnitOfWorkElimina.Dispose();
                }
            }
        }
        public void ActualizarSuspencion(CEPSuspensiones Suspencion)
        {
            //genera informacion adicional
            Suspencion.FechaGestion = DateTime.Now;

            //registra informacion en tabla principal
            UnitOfWork UnitOfWorkActualizado = new UnitOfWork(new DimeContext());
            CEPSuspensiones RegistroParaActualizar = new CEPSuspensiones();
            RegistroParaActualizar = UnitOfWorkActualizado.CEPSuspensiones.Find(x=> x.IdGestion == Suspencion.IdGestion).FirstOrDefault();
            if (RegistroParaActualizar!= null)
            {
                RegistroParaActualizar.FechaGestion = Suspencion.FechaGestion;
                RegistroParaActualizar.UsuarioDeGestion = Suspencion.UsuarioDeGestion;
                RegistroParaActualizar.NombreUsuarioGestion = Suspencion.NombreUsuarioGestion;
                RegistroParaActualizar.CuentaCliente = Suspencion.CuentaCliente;
                RegistroParaActualizar.CanalDeIngreso = Suspencion.CanalDeIngreso;
                RegistroParaActualizar.FechaCreacion = Suspencion.FechaCreacion;
                RegistroParaActualizar.UsuarioCreacion = Suspencion.UsuarioCreacion;
                RegistroParaActualizar.ServiciosSuspender = Suspencion.ServiciosSuspender;
                RegistroParaActualizar.MotivosSuspension = Suspencion.MotivosSuspension;
                RegistroParaActualizar.MesesSuspender = Suspencion.MesesSuspender;
                RegistroParaActualizar.Gestion = Suspencion.Gestion;
                RegistroParaActualizar.Subrazon = Suspencion.Subrazon;
                RegistroParaActualizar.Estado = Suspencion.Estado;
                RegistroParaActualizar.FechaSeguimiento = Suspencion.FechaSeguimiento;
                RegistroParaActualizar.Observaciones = Suspencion.Observaciones;

                UnitOfWorkActualizado.Complete();
                UnitOfWorkActualizado.Dispose();   
            }

            //Registra informacion en el log
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());
            CELSuspensiones Log = new CELSuspensiones();

            Log.IdGestion = Suspencion.IdGestion;
            Log.FechaDeTransaccion = Suspencion.FechaGestion;
            Log.UsuarioDeTransaccion = Suspencion.UsuarioDeGestion;
            Log.NombreUsuarioTransaccion = Suspencion.NombreUsuarioGestion;
            Log.CuentaCliente = Suspencion.CuentaCliente;
            Log.CanalDeIngreso = Suspencion.CanalDeIngreso;
            Log.FechaCreacion = Suspencion.FechaCreacion;
            Log.UsuarioCreacion = Suspencion.UsuarioCreacion;
            Log.ServiciosSuspender = Suspencion.ServiciosSuspender;
            Log.MotivosSuspension = Suspencion.MotivosSuspension;
            Log.MesesSuspender = Suspencion.MesesSuspender;
            Log.Gestion = Suspencion.Gestion;
            Log.Subrazon = Suspencion.Subrazon;
            Log.Estado = Suspencion.Estado;
            Log.FechaSeguimiento = Suspencion.FechaSeguimiento;
            Log.Observaciones = Suspencion.Observaciones;

            UnitOfWorkLog.CELSuspensiones.Add(Log);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();
            
        }
        public List<CELSuspensiones> ListaDeGestionAgenteSuspensiones(decimal Usuario)
        {

            DateTime FechaInicial;
            DateTime FechaFinal;
            FechaInicial = DateTime.Today;
            FechaFinal = FechaInicial.AddDays(1);
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELSuspensiones> Lista = new List<CELSuspensiones>();
            Lista = UnitOfWorkBusqueda.CELSuspensiones.Find(x => x.UsuarioDeTransaccion == Usuario && x.FechaDeTransaccion >= FechaInicial && x.FechaDeTransaccion <= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        public List<CEPSuspensiones> ListaSeguimientosAgenteSuspensiones(decimal Usuario)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CEPSuspensiones> Lista = new List<CEPSuspensiones>();
            Lista = UnitOfWorkBusqueda.CEPSuspensiones.Find(x => x.UsuarioDeGestion == Usuario && x.Estado.Equals("SEGUIMIENTO")).ToList();
            Lista = Lista.OrderBy(x => x.IdGestion).ToList();
            return Lista;
        }
        public CEPAsigSuspenciones ValidarCuentaAsigSuspension(decimal Cedula, decimal CuentaCliente)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPAsigSuspenciones cuenta = new CEPAsigSuspenciones();
            cuenta = UnitOfWorkBusqueda.CEPAsigSuspenciones.Find(x => x.CuentaCliente == CuentaCliente).FirstOrDefault();
            if (cuenta != null)
            {
                cuenta.UsuarioGestionando = Cedula;
                UnitOfWorkBusqueda.Complete();
                UnitOfWorkBusqueda.Dispose();
                return ApartarCuentadeSuspensiones(Cedula, 0);
            }
            else { return cuenta; }
        }
        public CEPAsigSuspenciones ApartarCuentadeSuspensiones(decimal Cedula, int noRecursividad)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<decimal> solicitud = unitWork.CEPAsigSuspenciones.Find(c => c.UsuarioGestionando == Cedula).Select(x => x.IdAsignacion).ToList();
            if (solicitud.Count > 0)
            {
                CEPAsigSuspenciones solicitudencontrada = new CEPAsigSuspenciones();
                return TraeRegistroAsignacionSuspensiones(solicitud[0]);
            }
            else
            {
                unitWork.CEPSuspensiones.ApartarCuentaGestionSuspensiones(Cedula);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return ApartarCuentadeSuspensiones(Cedula, noRecursividad);
            }
        }
        public CEPAsigSuspenciones TraeRegistroAsignacionSuspensiones(decimal IdAsignacion)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPAsigSuspenciones cuenta = new CEPAsigSuspenciones();
            cuenta = UnitOfWorkBusqueda.CEPAsigSuspenciones.Find(x => x.IdAsignacion == IdAsignacion).FirstOrDefault();
            return cuenta;
        }
        public CEPSuspensiones TraeSuspensionPorId(decimal IdGestion)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPSuspensiones Registro = new CEPSuspensiones();
            Registro = UnitOfWorkBusqueda.CEPSuspensiones.Find(x => x.IdGestion == IdGestion).FirstOrDefault();
            return Registro;
        }
        public CEPSuspensiones ConsultarGestionCuentaSuspensiones(decimal Cuenta)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPSuspensiones Suspension = new CEPSuspensiones();
            Suspension = UnitOfWorkBusqueda.CEPSuspensiones.Find(x => x.CuentaCliente == Cuenta && x.FechaGestion >= fecha1 && x.FechaGestion <= fecha2).FirstOrDefault();
            if (Suspension != null)
            {
                return TraeSuspensionPorId(Suspension.IdGestion);
            }
            else
            {
                return Suspension;
            }
        }
        public List<CELTickets> ConsultaLogDeGestionTicketsAgente(DateTime FechaInicial, DateTime FechaFinal, decimal Usuario)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELTickets> Lista = new List<CELTickets>();
            Lista = UnitOfWorkBusqueda.CELTickets.Find(x => x.UsuarioDeTransaccion == Usuario && x.FechaDeTransaccion >= FechaInicial && x.FechaDeTransaccion <= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        public List<CELSuspensiones> ConsultaLogDeGestionSuspensionesAgente(DateTime FechaInicial, DateTime FechaFinal, decimal Usuario)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELSuspensiones> Lista = new List<CELSuspensiones>();
            Lista = UnitOfWorkBusqueda.CELSuspensiones.Find(x => x.UsuarioDeTransaccion == Usuario && x.FechaDeTransaccion >= FechaInicial && x.FechaDeTransaccion <= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
    }
}
