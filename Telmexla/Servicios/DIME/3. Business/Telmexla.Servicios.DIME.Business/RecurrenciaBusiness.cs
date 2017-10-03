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
    public class RecurrenciaBusiness
    {
        public ClientesTodo TraerInformacionCuentaRecurrencia(int idAsesor, int noRecursividad)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<decimal> cuentasGestionandoAsesor = unitOfWork.RecurrenciaCargaBase.Find(c => c.Usuario_gestionando == idAsesor).Select(x => x.Cuenta).ToList();
            if (cuentasGestionandoAsesor.Count > 0)
            {
                ClientesBusiness clientesBusiness = new ClientesBusiness();
                return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(cuentasGestionandoAsesor[0]));
            }
            else
            {
                unitOfWork.RecurrenciaCargaBase.ApartarCuentaaGestionarRecurrencia(idAsesor);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return TraerInformacionCuentaRecurrencia(idAsesor, noRecursividad);
            }
        }

        public RecurrenciaCargaBase TraerDatosRecurrencia(int idAsesor, int CuentaCliente)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.RecurrenciaCargaBase.Find(c => c.Usuario_gestionando == idAsesor && c.Cuenta == CuentaCliente).FirstOrDefault();
        }
        public void EliminaCuentaRecurrencia(decimal Cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            RecurrenciaCargaBase CuentaEliminar = unitWork.RecurrenciaCargaBase.Find(c => c.Cuenta == Cuenta).FirstOrDefault();

            if (CuentaEliminar != null)
            {
                unitWork.RecurrenciaCargaBase.Remove(CuentaEliminar);
                unitWork.Complete();
                unitWork.Dispose();
            }
            else { }
        }
        public void InsertarGRecurrencia(GPrincipalRecurrencia recurrencia)
        {
            try
            {
                recurrencia.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.GPrincipalRecurrencia.Add(recurrencia);
                unitWork.Complete();
                unitWork.Dispose();


                UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
                GLogRecurrencia LogRecurrencia = new GLogRecurrencia();

                LogRecurrencia.FechaGestion = recurrencia.FechaGestion;
                LogRecurrencia.UsuarioGestion = recurrencia.UsuarioGestion;
                LogRecurrencia.NombreUsuarioGestion = recurrencia.NombreUsuarioGestion;
                LogRecurrencia.AliadoGestion = recurrencia.AliadoGestion;
                LogRecurrencia.CuentaCliente = recurrencia.CuentaCliente;
                LogRecurrencia.NombreCliente = recurrencia.NombreCliente;
                LogRecurrencia.ApellidoCliente = recurrencia.ApellidoCliente;
                LogRecurrencia.Division = recurrencia.Division;
                LogRecurrencia.Area = recurrencia.Area;
                LogRecurrencia.Zona = recurrencia.Zona;
                LogRecurrencia.Marcaciones = recurrencia.Marcaciones;
                LogRecurrencia.FechaUltimaMarcacion = recurrencia.FechaUltimaMarcacion;
                LogRecurrencia.FechaUltimaGestion = recurrencia.FechaUltimaGestion;
                LogRecurrencia.Telefono1 = recurrencia.Telefono1;
                LogRecurrencia.Telefono2 = recurrencia.Telefono2;
                LogRecurrencia.Telefono3 = recurrencia.Telefono3;
                LogRecurrencia.TelefonoTelmex = recurrencia.TelefonoTelmex;
                LogRecurrencia.IncluyeClaroVideo = recurrencia.IncluyeClaroVideo;
                LogRecurrencia.UsoClaroVideo = recurrencia.UsoClaroVideo;
                LogRecurrencia.ClienteNagra = recurrencia.ClienteNagra;
                LogRecurrencia.Ofrecimiento1 = recurrencia.Ofrecimiento1;
                LogRecurrencia.AceptacionPrimerOfrecimiento = recurrencia.AceptacionPrimerOfrecimiento;
                LogRecurrencia.Ofrecimiento2 = recurrencia.Ofrecimiento2;
                LogRecurrencia.AceptacionSegundoOfrecimiento = recurrencia.AceptacionSegundoOfrecimiento;
                LogRecurrencia.Ofrecimiento3 = recurrencia.Ofrecimiento3;
                LogRecurrencia.AceptacionTercerOfrecimiento = recurrencia.AceptacionTercerOfrecimiento;
                LogRecurrencia.Diferenciador = recurrencia.Diferenciador;
                LogRecurrencia.Prioridad = recurrencia.Prioridad;
                LogRecurrencia.VecesGestionado = recurrencia.VecesGestionado;
                LogRecurrencia.MarcacionInicialAfectacion = recurrencia.MarcacionInicialAfectacion;
                LogRecurrencia.MarcacionReincidenteRecurrencia = recurrencia.MarcacionReincidenteRecurrencia;
                LogRecurrencia.ClieComunicaRealizadaGestRecu = recurrencia.ClieComunicaRealizadaGestRecu;
                LogRecurrencia.PorQue = recurrencia.PorQue;
                LogRecurrencia.Contacto = recurrencia.Contacto;
                LogRecurrencia.VozClienteCausaRaiz = recurrencia.VozClienteCausaRaiz;
                LogRecurrencia.Solucionado = recurrencia.Solucionado;
                LogRecurrencia.AreaParticipaSolucion = recurrencia.AreaParticipaSolucion;
                LogRecurrencia.ClientePresentaNovedades = recurrencia.ClientePresentaNovedades;
                LogRecurrencia.Proceso = recurrencia.Proceso;
                LogRecurrencia.Macroproceso = recurrencia.Macroproceso;
                LogRecurrencia.ServicioAfectado = recurrencia.ServicioAfectado;
                LogRecurrencia.FallaEspecificaArbolCCAA = recurrencia.FallaEspecificaArbolCCAA;
                LogRecurrencia.FallaCausaRaiz = recurrencia.FallaCausaRaiz;
                LogRecurrencia.SolucionEspecifica = recurrencia.SolucionEspecifica;
                LogRecurrencia.Estado = recurrencia.Estado;
                LogRecurrencia.MarcaEquiposFalla = recurrencia.MarcaEquiposFalla;
                LogRecurrencia.UbicacionModem = recurrencia.UbicacionModem;
                LogRecurrencia.DispositivosInalambricosAlrededorModem = recurrencia.DispositivosInalambricosAlrededorModem;
                LogRecurrencia.CantEquiposConecInternet = recurrencia.CantEquiposConecInternet;
                LogRecurrencia.TipoDispConectaInternet = recurrencia.TipoDispConectaInternet;
                LogRecurrencia.UsoBrindaInternet = recurrencia.UsoBrindaInternet;
                LogRecurrencia.ActivacionClaroVideoNagra = recurrencia.ActivacionClaroVideoNagra;
                LogRecurrencia.ServicioOfrecido = recurrencia.ServicioOfrecido;
                LogRecurrencia.AceptacionServicioOfrecido = recurrencia.AceptacionServicioOfrecido;
                LogRecurrencia.Observaciones = recurrencia.Observaciones;
                unitWorkLog.GLogRecurrencia.Add(LogRecurrencia);
                unitWorkLog.Complete();
                unitWorkLog.Dispose();

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
        public void ActualizarGRecurrencia(GPrincipalRecurrencia recurrencia)
        {
            try
            {
                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                recurrencia.FechaGestion = DateTime.Now;
                GPrincipalRecurrencia GPRecurActualizable = unitWork.GPrincipalRecurrencia.Find(c => c.CuentaCliente == recurrencia.CuentaCliente).FirstOrDefault();

                GPRecurActualizable.FechaGestion = recurrencia.FechaGestion;
                GPRecurActualizable.UsuarioGestion = recurrencia.UsuarioGestion;
                GPRecurActualizable.NombreUsuarioGestion = recurrencia.NombreUsuarioGestion;
                GPRecurActualizable.AliadoGestion = recurrencia.AliadoGestion;
                GPRecurActualizable.CuentaCliente = recurrencia.CuentaCliente;
                GPRecurActualizable.NombreCliente = recurrencia.NombreCliente;
                GPRecurActualizable.ApellidoCliente = recurrencia.ApellidoCliente;
                GPRecurActualizable.Division = recurrencia.Division;
                GPRecurActualizable.Area = recurrencia.Area;
                GPRecurActualizable.Zona = recurrencia.Zona;
                GPRecurActualizable.Marcaciones = recurrencia.Marcaciones;
                GPRecurActualizable.FechaUltimaMarcacion = recurrencia.FechaUltimaMarcacion;
                GPRecurActualizable.FechaUltimaGestion = recurrencia.FechaUltimaGestion;
                GPRecurActualizable.Telefono1 = recurrencia.Telefono1;
                GPRecurActualizable.Telefono2 = recurrencia.Telefono2;
                GPRecurActualizable.Telefono3 = recurrencia.Telefono3;
                GPRecurActualizable.TelefonoTelmex = recurrencia.TelefonoTelmex;
                GPRecurActualizable.IncluyeClaroVideo = recurrencia.IncluyeClaroVideo;
                GPRecurActualizable.UsoClaroVideo = recurrencia.UsoClaroVideo;
                GPRecurActualizable.ClienteNagra = recurrencia.ClienteNagra;
                GPRecurActualizable.Ofrecimiento1 = recurrencia.Ofrecimiento1;
                GPRecurActualizable.AceptacionPrimerOfrecimiento = recurrencia.AceptacionPrimerOfrecimiento;
                GPRecurActualizable.Ofrecimiento2 = recurrencia.Ofrecimiento2;
                GPRecurActualizable.AceptacionSegundoOfrecimiento = recurrencia.AceptacionSegundoOfrecimiento;
                GPRecurActualizable.Ofrecimiento3 = recurrencia.Ofrecimiento3;
                GPRecurActualizable.AceptacionTercerOfrecimiento = recurrencia.AceptacionTercerOfrecimiento;
                GPRecurActualizable.Diferenciador = recurrencia.Diferenciador;
                GPRecurActualizable.Prioridad = recurrencia.Prioridad;
                GPRecurActualizable.VecesGestionado = recurrencia.VecesGestionado;
                GPRecurActualizable.MarcacionInicialAfectacion = recurrencia.MarcacionInicialAfectacion;
                GPRecurActualizable.MarcacionReincidenteRecurrencia = recurrencia.MarcacionReincidenteRecurrencia;
                GPRecurActualizable.ClieComunicaRealizadaGestRecu = recurrencia.ClieComunicaRealizadaGestRecu;
                GPRecurActualizable.PorQue = recurrencia.PorQue;
                GPRecurActualizable.Contacto = recurrencia.Contacto;
                GPRecurActualizable.VozClienteCausaRaiz = recurrencia.VozClienteCausaRaiz;
                GPRecurActualizable.Solucionado = recurrencia.Solucionado;
                GPRecurActualizable.AreaParticipaSolucion = recurrencia.AreaParticipaSolucion;
                GPRecurActualizable.ClientePresentaNovedades = recurrencia.ClientePresentaNovedades;
                GPRecurActualizable.Proceso = recurrencia.Proceso;
                GPRecurActualizable.Macroproceso = recurrencia.Macroproceso;
                GPRecurActualizable.ServicioAfectado = recurrencia.ServicioAfectado;
                GPRecurActualizable.FallaEspecificaArbolCCAA = recurrencia.FallaEspecificaArbolCCAA;
                GPRecurActualizable.FallaCausaRaiz = recurrencia.FallaCausaRaiz;
                GPRecurActualizable.SolucionEspecifica = recurrencia.SolucionEspecifica;
                GPRecurActualizable.Estado = recurrencia.Estado;
                GPRecurActualizable.MarcaEquiposFalla = recurrencia.MarcaEquiposFalla;
                GPRecurActualizable.UbicacionModem = recurrencia.UbicacionModem;
                GPRecurActualizable.DispositivosInalambricosAlrededorModem = recurrencia.DispositivosInalambricosAlrededorModem;
                GPRecurActualizable.CantEquiposConecInternet = recurrencia.CantEquiposConecInternet;
                GPRecurActualizable.TipoDispConectaInternet = recurrencia.TipoDispConectaInternet;
                GPRecurActualizable.UsoBrindaInternet = recurrencia.UsoBrindaInternet;
                GPRecurActualizable.ActivacionClaroVideoNagra = recurrencia.ActivacionClaroVideoNagra;
                GPRecurActualizable.ServicioOfrecido = recurrencia.ServicioOfrecido;
                GPRecurActualizable.AceptacionServicioOfrecido = recurrencia.AceptacionServicioOfrecido;
                GPRecurActualizable.Observaciones = recurrencia.Observaciones;
                GPRecurActualizable.UsuarioGestionando = recurrencia.UsuarioGestionando;
                unitWork.Complete();
                unitWork.Dispose();

                UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
                GLogRecurrencia LogRecurrencia = new GLogRecurrencia();

                LogRecurrencia.FechaGestion = recurrencia.FechaGestion;
                LogRecurrencia.UsuarioGestion = recurrencia.UsuarioGestion;
                LogRecurrencia.NombreUsuarioGestion = recurrencia.NombreUsuarioGestion;
                LogRecurrencia.AliadoGestion = recurrencia.AliadoGestion;
                LogRecurrencia.CuentaCliente = recurrencia.CuentaCliente;
                LogRecurrencia.NombreCliente = recurrencia.NombreCliente;
                LogRecurrencia.ApellidoCliente = recurrencia.ApellidoCliente;
                LogRecurrencia.Division = recurrencia.Division;
                LogRecurrencia.Area = recurrencia.Area;
                LogRecurrencia.Zona = recurrencia.Zona;
                LogRecurrencia.Marcaciones = recurrencia.Marcaciones;
                LogRecurrencia.FechaUltimaMarcacion = recurrencia.FechaUltimaMarcacion;
                LogRecurrencia.FechaUltimaGestion = recurrencia.FechaUltimaGestion;
                LogRecurrencia.Telefono1 = recurrencia.Telefono1;
                LogRecurrencia.Telefono2 = recurrencia.Telefono2;
                LogRecurrencia.Telefono3 = recurrencia.Telefono3;
                LogRecurrencia.TelefonoTelmex = recurrencia.TelefonoTelmex;
                LogRecurrencia.IncluyeClaroVideo = recurrencia.IncluyeClaroVideo;
                LogRecurrencia.UsoClaroVideo = recurrencia.UsoClaroVideo;
                LogRecurrencia.ClienteNagra = recurrencia.ClienteNagra;
                LogRecurrencia.Ofrecimiento1 = recurrencia.Ofrecimiento1;
                LogRecurrencia.AceptacionPrimerOfrecimiento = recurrencia.AceptacionPrimerOfrecimiento;
                LogRecurrencia.Ofrecimiento2 = recurrencia.Ofrecimiento2;
                LogRecurrencia.AceptacionSegundoOfrecimiento = recurrencia.AceptacionSegundoOfrecimiento;
                LogRecurrencia.Ofrecimiento3 = recurrencia.Ofrecimiento3;
                LogRecurrencia.AceptacionTercerOfrecimiento = recurrencia.AceptacionTercerOfrecimiento;
                LogRecurrencia.Diferenciador = recurrencia.Diferenciador;
                LogRecurrencia.Prioridad = recurrencia.Prioridad;
                LogRecurrencia.VecesGestionado = recurrencia.VecesGestionado;
                LogRecurrencia.MarcacionInicialAfectacion = recurrencia.MarcacionInicialAfectacion;
                LogRecurrencia.MarcacionReincidenteRecurrencia = recurrencia.MarcacionReincidenteRecurrencia;
                LogRecurrencia.ClieComunicaRealizadaGestRecu = recurrencia.ClieComunicaRealizadaGestRecu;
                LogRecurrencia.PorQue = recurrencia.PorQue;
                LogRecurrencia.Contacto = recurrencia.Contacto;
                LogRecurrencia.VozClienteCausaRaiz = recurrencia.VozClienteCausaRaiz;
                LogRecurrencia.Solucionado = recurrencia.Solucionado;
                LogRecurrencia.AreaParticipaSolucion = recurrencia.AreaParticipaSolucion;
                LogRecurrencia.ClientePresentaNovedades = recurrencia.ClientePresentaNovedades;
                LogRecurrencia.Proceso = recurrencia.Proceso;
                LogRecurrencia.Macroproceso = recurrencia.Macroproceso;
                LogRecurrencia.ServicioAfectado = recurrencia.ServicioAfectado;
                LogRecurrencia.FallaEspecificaArbolCCAA = recurrencia.FallaEspecificaArbolCCAA;
                LogRecurrencia.FallaCausaRaiz = recurrencia.FallaCausaRaiz;
                LogRecurrencia.SolucionEspecifica = recurrencia.SolucionEspecifica;
                LogRecurrencia.Estado = recurrencia.Estado;
                LogRecurrencia.MarcaEquiposFalla = recurrencia.MarcaEquiposFalla;
                LogRecurrencia.UbicacionModem = recurrencia.UbicacionModem;
                LogRecurrencia.DispositivosInalambricosAlrededorModem = recurrencia.DispositivosInalambricosAlrededorModem;
                LogRecurrencia.CantEquiposConecInternet = recurrencia.CantEquiposConecInternet;
                LogRecurrencia.TipoDispConectaInternet = recurrencia.TipoDispConectaInternet;
                LogRecurrencia.UsoBrindaInternet = recurrencia.UsoBrindaInternet;
                LogRecurrencia.ActivacionClaroVideoNagra = recurrencia.ActivacionClaroVideoNagra;
                LogRecurrencia.ServicioOfrecido = recurrencia.ServicioOfrecido;
                LogRecurrencia.AceptacionServicioOfrecido = recurrencia.AceptacionServicioOfrecido;
                LogRecurrencia.Observaciones = recurrencia.Observaciones;
                unitWorkLog.GLogRecurrencia.Add(LogRecurrencia);
                unitWorkLog.Complete();
                unitWorkLog.Dispose();

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
        public GPrincipalRecurrencia TraerGPrinRecurrencia(int CuentaCliente)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.GPrincipalRecurrencia.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
        public List<GPrincipalRecurrencia> ListaSeguimientosRecurrencia()
        {
            DimeContext dimContext = new DimeContext();
            List<GPrincipalRecurrencia> result = new List<GPrincipalRecurrencia>();
            var objetosResult = (from a in dimContext.GPrincipalRecurrencia
                                 where a.Estado == "SEGUIMIENTO"
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Marcaciones,
                                     a.FechaUltimaMarcacion,
                                     a.FechaUltimaGestion,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.TelefonoTelmex,
                                     a.IncluyeClaroVideo,
                                     a.UsoClaroVideo,
                                     a.ClienteNagra,
                                     a.Ofrecimiento1,
                                     a.AceptacionPrimerOfrecimiento,
                                     a.Ofrecimiento2,
                                     a.AceptacionSegundoOfrecimiento,
                                     a.Ofrecimiento3,
                                     a.AceptacionTercerOfrecimiento,
                                     a.Diferenciador,
                                     a.Prioridad,
                                     a.VecesGestionado,
                                     a.MarcacionInicialAfectacion,
                                     a.MarcacionReincidenteRecurrencia,
                                     a.ClieComunicaRealizadaGestRecu,
                                     a.PorQue,
                                     a.Contacto,
                                     a.VozClienteCausaRaiz,
                                     a.Solucionado,
                                     a.AreaParticipaSolucion,
                                     a.ClientePresentaNovedades,
                                     a.Proceso,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.FallaEspecificaArbolCCAA,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,
                                     a.Estado,
                                     a.MarcaEquiposFalla,
                                     a.UbicacionModem,
                                     a.DispositivosInalambricosAlrededorModem,
                                     a.CantEquiposConecInternet,
                                     a.TipoDispConectaInternet,
                                     a.UsoBrindaInternet,
                                     a.ActivacionClaroVideoNagra,
                                     a.ServicioOfrecido,
                                     a.AceptacionServicioOfrecido,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GPrincipalRecurrencia());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Marcaciones = objetosResult[i].Marcaciones;
                result[i].FechaUltimaMarcacion = objetosResult[i].FechaUltimaMarcacion;
                result[i].FechaUltimaGestion = objetosResult[i].FechaUltimaGestion;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].TelefonoTelmex = objetosResult[i].TelefonoTelmex;
                result[i].IncluyeClaroVideo = objetosResult[i].IncluyeClaroVideo;
                result[i].UsoClaroVideo = objetosResult[i].UsoClaroVideo;
                result[i].ClienteNagra = objetosResult[i].ClienteNagra;
                result[i].Ofrecimiento1 = objetosResult[i].Ofrecimiento1;
                result[i].AceptacionPrimerOfrecimiento = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].Ofrecimiento2 = objetosResult[i].Ofrecimiento2;
                result[i].AceptacionSegundoOfrecimiento = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].Ofrecimiento3 = objetosResult[i].Ofrecimiento3;
                result[i].AceptacionTercerOfrecimiento = objetosResult[i].AceptacionTercerOfrecimiento;
                result[i].Diferenciador = objetosResult[i].Diferenciador;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].VecesGestionado = objetosResult[i].VecesGestionado;
                result[i].MarcacionInicialAfectacion = objetosResult[i].MarcacionInicialAfectacion;
                result[i].MarcacionReincidenteRecurrencia = objetosResult[i].MarcacionReincidenteRecurrencia;
                result[i].ClieComunicaRealizadaGestRecu = objetosResult[i].ClieComunicaRealizadaGestRecu;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].Contacto = objetosResult[i].Contacto;
                result[i].VozClienteCausaRaiz = objetosResult[i].VozClienteCausaRaiz;
                result[i].ClientePresentaNovedades = objetosResult[i].ClientePresentaNovedades;
                result[i].Proceso = objetosResult[i].Proceso;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].FallaEspecificaArbolCCAA = objetosResult[i].FallaEspecificaArbolCCAA;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Solucionado = objetosResult[i].Solucionado;
                result[i].Estado = objetosResult[i].Estado;
                result[i].MarcaEquiposFalla = objetosResult[i].MarcaEquiposFalla;
                result[i].UbicacionModem = objetosResult[i].UbicacionModem;
                result[i].DispositivosInalambricosAlrededorModem = objetosResult[i].DispositivosInalambricosAlrededorModem;
                result[i].CantEquiposConecInternet = objetosResult[i].CantEquiposConecInternet;
                result[i].TipoDispConectaInternet = objetosResult[i].TipoDispConectaInternet;
                result[i].UsoBrindaInternet = objetosResult[i].UsoBrindaInternet;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].ServicioOfrecido = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].AceptacionServicioOfrecido = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public void UsuarioGestionandoGRecurrencia(int idUsuario, int idCaso)
        {

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GPrincipalRecurrencia GPRecurActualizable = unitWork.GPrincipalRecurrencia.Find(c => c.Id == idCaso).FirstOrDefault();

            GPRecurActualizable.UsuarioGestionando = idUsuario;
            unitWork.Complete();
            unitWork.Dispose();
        }
        public List<GPrincipalRecurrencia> ConsultaAdminGPrincipalRecurrencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GPrincipalRecurrencia> result = new List<GPrincipalRecurrencia>();
            var objetosResult = (from a in dimContext.GPrincipalRecurrencia
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Marcaciones,
                                     a.FechaUltimaMarcacion,
                                     a.FechaUltimaGestion,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.TelefonoTelmex,
                                     a.IncluyeClaroVideo,
                                     a.UsoClaroVideo,
                                     a.ClienteNagra,
                                     a.Ofrecimiento1,
                                     a.AceptacionPrimerOfrecimiento,
                                     a.Ofrecimiento2,
                                     a.AceptacionSegundoOfrecimiento,
                                     a.Ofrecimiento3,
                                     a.AceptacionTercerOfrecimiento,
                                     a.Diferenciador,
                                     a.Prioridad,
                                     a.VecesGestionado,
                                     a.MarcacionInicialAfectacion,
                                     a.MarcacionReincidenteRecurrencia,
                                     a.ClieComunicaRealizadaGestRecu,
                                     a.PorQue,
                                     a.Contacto,
                                     a.VozClienteCausaRaiz,
                                     a.Solucionado,
                                     a.AreaParticipaSolucion,
                                     a.ClientePresentaNovedades,
                                     a.Proceso,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.FallaEspecificaArbolCCAA,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,
                                     a.Estado,
                                     a.MarcaEquiposFalla,
                                     a.UbicacionModem,
                                     a.DispositivosInalambricosAlrededorModem,
                                     a.CantEquiposConecInternet,
                                     a.TipoDispConectaInternet,
                                     a.UsoBrindaInternet,
                                     a.ActivacionClaroVideoNagra,
                                     a.ServicioOfrecido,
                                     a.AceptacionServicioOfrecido,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GPrincipalRecurrencia());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Marcaciones = objetosResult[i].Marcaciones;
                result[i].FechaUltimaMarcacion = objetosResult[i].FechaUltimaMarcacion;
                result[i].FechaUltimaGestion = objetosResult[i].FechaUltimaGestion;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].TelefonoTelmex = objetosResult[i].TelefonoTelmex;
                result[i].IncluyeClaroVideo = objetosResult[i].IncluyeClaroVideo;
                result[i].UsoClaroVideo = objetosResult[i].UsoClaroVideo;
                result[i].ClienteNagra = objetosResult[i].ClienteNagra;
                result[i].Ofrecimiento1 = objetosResult[i].Ofrecimiento1;
                result[i].AceptacionPrimerOfrecimiento = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].Ofrecimiento2 = objetosResult[i].Ofrecimiento2;
                result[i].AceptacionSegundoOfrecimiento = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].Ofrecimiento3 = objetosResult[i].Ofrecimiento3;
                result[i].AceptacionTercerOfrecimiento = objetosResult[i].AceptacionTercerOfrecimiento;
                result[i].Diferenciador = objetosResult[i].Diferenciador;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].VecesGestionado = objetosResult[i].VecesGestionado;
                result[i].MarcacionInicialAfectacion = objetosResult[i].MarcacionInicialAfectacion;
                result[i].MarcacionReincidenteRecurrencia = objetosResult[i].MarcacionReincidenteRecurrencia;
                result[i].ClieComunicaRealizadaGestRecu = objetosResult[i].ClieComunicaRealizadaGestRecu;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].Contacto = objetosResult[i].Contacto;
                result[i].VozClienteCausaRaiz = objetosResult[i].VozClienteCausaRaiz;
                result[i].ClientePresentaNovedades = objetosResult[i].ClientePresentaNovedades;
                result[i].Proceso = objetosResult[i].Proceso;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].FallaEspecificaArbolCCAA = objetosResult[i].FallaEspecificaArbolCCAA;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Solucionado = objetosResult[i].Solucionado;
                result[i].Estado = objetosResult[i].Estado;
                result[i].MarcaEquiposFalla = objetosResult[i].MarcaEquiposFalla;
                result[i].UbicacionModem = objetosResult[i].UbicacionModem;
                result[i].DispositivosInalambricosAlrededorModem = objetosResult[i].DispositivosInalambricosAlrededorModem;
                result[i].CantEquiposConecInternet = objetosResult[i].CantEquiposConecInternet;
                result[i].TipoDispConectaInternet = objetosResult[i].TipoDispConectaInternet;
                result[i].UsoBrindaInternet = objetosResult[i].UsoBrindaInternet;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].ServicioOfrecido = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].AceptacionServicioOfrecido = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public List<GLogRecurrencia> ConsultaAdminGLogRecurrencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GLogRecurrencia> result = new List<GLogRecurrencia>();
            var objetosResult = (from a in dimContext.GLogRecurrencia
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Marcaciones,
                                     a.FechaUltimaMarcacion,
                                     a.FechaUltimaGestion,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.TelefonoTelmex,
                                     a.IncluyeClaroVideo,
                                     a.UsoClaroVideo,
                                     a.ClienteNagra,
                                     a.Ofrecimiento1,
                                     a.AceptacionPrimerOfrecimiento,
                                     a.Ofrecimiento2,
                                     a.AceptacionSegundoOfrecimiento,
                                     a.Ofrecimiento3,
                                     a.AceptacionTercerOfrecimiento,
                                     a.Diferenciador,
                                     a.Prioridad,
                                     a.VecesGestionado,
                                     a.MarcacionInicialAfectacion,
                                     a.MarcacionReincidenteRecurrencia,
                                     a.ClieComunicaRealizadaGestRecu,
                                     a.PorQue,
                                     a.Contacto,
                                     a.VozClienteCausaRaiz,
                                     a.Solucionado,
                                     a.AreaParticipaSolucion,
                                     a.ClientePresentaNovedades,
                                     a.Proceso,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.FallaEspecificaArbolCCAA,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,
                                     a.Estado,
                                     a.MarcaEquiposFalla,
                                     a.UbicacionModem,
                                     a.DispositivosInalambricosAlrededorModem,
                                     a.CantEquiposConecInternet,
                                     a.TipoDispConectaInternet,
                                     a.UsoBrindaInternet,
                                     a.ActivacionClaroVideoNagra,
                                     a.ServicioOfrecido,
                                     a.AceptacionServicioOfrecido,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GLogRecurrencia());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Marcaciones = objetosResult[i].Marcaciones;
                result[i].FechaUltimaMarcacion = objetosResult[i].FechaUltimaMarcacion;
                result[i].FechaUltimaGestion = objetosResult[i].FechaUltimaGestion;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].TelefonoTelmex = objetosResult[i].TelefonoTelmex;
                result[i].IncluyeClaroVideo = objetosResult[i].IncluyeClaroVideo;
                result[i].UsoClaroVideo = objetosResult[i].UsoClaroVideo;
                result[i].ClienteNagra = objetosResult[i].ClienteNagra;
                result[i].Ofrecimiento1 = objetosResult[i].Ofrecimiento1;
                result[i].AceptacionPrimerOfrecimiento = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].Ofrecimiento2 = objetosResult[i].Ofrecimiento2;
                result[i].AceptacionSegundoOfrecimiento = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].Ofrecimiento3 = objetosResult[i].Ofrecimiento3;
                result[i].AceptacionTercerOfrecimiento = objetosResult[i].AceptacionTercerOfrecimiento;
                result[i].Diferenciador = objetosResult[i].Diferenciador;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].VecesGestionado = objetosResult[i].VecesGestionado;
                result[i].MarcacionInicialAfectacion = objetosResult[i].MarcacionInicialAfectacion;
                result[i].MarcacionReincidenteRecurrencia = objetosResult[i].MarcacionReincidenteRecurrencia;
                result[i].ClieComunicaRealizadaGestRecu = objetosResult[i].ClieComunicaRealizadaGestRecu;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].Contacto = objetosResult[i].Contacto;
                result[i].VozClienteCausaRaiz = objetosResult[i].VozClienteCausaRaiz;
                result[i].ClientePresentaNovedades = objetosResult[i].ClientePresentaNovedades;
                result[i].Proceso = objetosResult[i].Proceso;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].FallaEspecificaArbolCCAA = objetosResult[i].FallaEspecificaArbolCCAA;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Solucionado = objetosResult[i].Solucionado;
                result[i].Estado = objetosResult[i].Estado;
                result[i].MarcaEquiposFalla = objetosResult[i].MarcaEquiposFalla;
                result[i].UbicacionModem = objetosResult[i].UbicacionModem;
                result[i].DispositivosInalambricosAlrededorModem = objetosResult[i].DispositivosInalambricosAlrededorModem;
                result[i].CantEquiposConecInternet = objetosResult[i].CantEquiposConecInternet;
                result[i].TipoDispConectaInternet = objetosResult[i].TipoDispConectaInternet;
                result[i].UsoBrindaInternet = objetosResult[i].UsoBrindaInternet;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].ServicioOfrecido = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].AceptacionServicioOfrecido = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public List<GLogRecurrencia> ListaHistorialSeguimientosRecurrencia( decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<GLogRecurrencia> result = new List<GLogRecurrencia>();
            var objetosResult = (from a in dimContext.GLogRecurrencia
                                 where a.CuentaCliente == CuentaCliente
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Marcaciones,
                                     a.FechaUltimaMarcacion,
                                     a.FechaUltimaGestion,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.TelefonoTelmex,
                                     a.IncluyeClaroVideo,
                                     a.UsoClaroVideo,
                                     a.ClienteNagra,
                                     a.Ofrecimiento1,
                                     a.AceptacionPrimerOfrecimiento,
                                     a.Ofrecimiento2,
                                     a.AceptacionSegundoOfrecimiento,
                                     a.Ofrecimiento3,
                                     a.AceptacionTercerOfrecimiento,
                                     a.Diferenciador,
                                     a.Prioridad,
                                     a.VecesGestionado,
                                     a.MarcacionInicialAfectacion,
                                     a.MarcacionReincidenteRecurrencia,
                                     a.ClieComunicaRealizadaGestRecu,
                                     a.PorQue,
                                     a.Contacto,
                                     a.VozClienteCausaRaiz,
                                     a.Solucionado,
                                     a.AreaParticipaSolucion,
                                     a.ClientePresentaNovedades,
                                     a.Proceso,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.FallaEspecificaArbolCCAA,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,
                                     a.Estado,
                                     a.MarcaEquiposFalla,
                                     a.UbicacionModem,
                                     a.DispositivosInalambricosAlrededorModem,
                                     a.CantEquiposConecInternet,
                                     a.TipoDispConectaInternet,
                                     a.UsoBrindaInternet,
                                     a.ActivacionClaroVideoNagra,
                                     a.ServicioOfrecido,
                                     a.AceptacionServicioOfrecido,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GLogRecurrencia());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Marcaciones = objetosResult[i].Marcaciones;
                result[i].FechaUltimaMarcacion = objetosResult[i].FechaUltimaMarcacion;
                result[i].FechaUltimaGestion = objetosResult[i].FechaUltimaGestion;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].TelefonoTelmex = objetosResult[i].TelefonoTelmex;
                result[i].IncluyeClaroVideo = objetosResult[i].IncluyeClaroVideo;
                result[i].UsoClaroVideo = objetosResult[i].UsoClaroVideo;
                result[i].ClienteNagra = objetosResult[i].ClienteNagra;
                result[i].Ofrecimiento1 = objetosResult[i].Ofrecimiento1;
                result[i].AceptacionPrimerOfrecimiento = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].Ofrecimiento2 = objetosResult[i].Ofrecimiento2;
                result[i].AceptacionSegundoOfrecimiento = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].Ofrecimiento3 = objetosResult[i].Ofrecimiento3;
                result[i].AceptacionTercerOfrecimiento = objetosResult[i].AceptacionTercerOfrecimiento;
                result[i].Diferenciador = objetosResult[i].Diferenciador;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].VecesGestionado = objetosResult[i].VecesGestionado;
                result[i].MarcacionInicialAfectacion = objetosResult[i].MarcacionInicialAfectacion;
                result[i].MarcacionReincidenteRecurrencia = objetosResult[i].MarcacionReincidenteRecurrencia;
                result[i].ClieComunicaRealizadaGestRecu = objetosResult[i].ClieComunicaRealizadaGestRecu;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].Contacto = objetosResult[i].Contacto;
                result[i].VozClienteCausaRaiz = objetosResult[i].VozClienteCausaRaiz;
                result[i].ClientePresentaNovedades = objetosResult[i].ClientePresentaNovedades;
                result[i].Proceso = objetosResult[i].Proceso;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].FallaEspecificaArbolCCAA = objetosResult[i].FallaEspecificaArbolCCAA;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Solucionado = objetosResult[i].Solucionado;
                result[i].Estado = objetosResult[i].Estado;
                result[i].MarcaEquiposFalla = objetosResult[i].MarcaEquiposFalla;
                result[i].UbicacionModem = objetosResult[i].UbicacionModem;
                result[i].DispositivosInalambricosAlrededorModem = objetosResult[i].DispositivosInalambricosAlrededorModem;
                result[i].CantEquiposConecInternet = objetosResult[i].CantEquiposConecInternet;
                result[i].TipoDispConectaInternet = objetosResult[i].TipoDispConectaInternet;
                result[i].UsoBrindaInternet = objetosResult[i].UsoBrindaInternet;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].ServicioOfrecido = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].AceptacionServicioOfrecido = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public void InsertarGRecurrenciaInbound(GPrincipalRecurrenciaInbound recurrenciainbound)
        {
            try
            {
                recurrenciainbound.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.GPrincipalRecurrenciaInbound.Add(recurrenciainbound);
                unitWork.Complete();
                unitWork.Dispose();


                UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
                GLogRecurrenciaInbound LogRecurrenciaInbound = new GLogRecurrenciaInbound();

                LogRecurrenciaInbound.FechaGestion = recurrenciainbound.FechaGestion;
                LogRecurrenciaInbound.UsuarioGestion = recurrenciainbound.UsuarioGestion;
                LogRecurrenciaInbound.NombreUsuarioGestion = recurrenciainbound.NombreUsuarioGestion;
                LogRecurrenciaInbound.AliadoGestion = recurrenciainbound.AliadoGestion;
                LogRecurrenciaInbound.CuentaCliente = recurrenciainbound.CuentaCliente;
                LogRecurrenciaInbound.Macroproceso = recurrenciainbound.Macroproceso;
                LogRecurrenciaInbound.ServicioAfectado = recurrenciainbound.ServicioAfectado;
                LogRecurrenciaInbound.ArbolSoporte = recurrenciainbound.ArbolSoporte;
                LogRecurrenciaInbound.FallaCausaRaiz = recurrenciainbound.FallaCausaRaiz;
                LogRecurrenciaInbound.SolucionEspecifica = recurrenciainbound.SolucionEspecifica;
                LogRecurrenciaInbound.Estado = recurrenciainbound.Estado;
                LogRecurrenciaInbound.FallaAtribuibleA = recurrenciainbound.FallaAtribuibleA;
                LogRecurrenciaInbound.PorQue = recurrenciainbound.PorQue;
                LogRecurrenciaInbound.ActivacionClaroVideoNagra = recurrenciainbound.ActivacionClaroVideoNagra;
                LogRecurrenciaInbound.ServicioOfrecido = recurrenciainbound.ServicioOfrecido;
                LogRecurrenciaInbound.AceptacionServicioOfrecido = recurrenciainbound.AceptacionServicioOfrecido;
                LogRecurrenciaInbound.Observaciones = recurrenciainbound.Observaciones;
                unitWorkLog.GLogRecurrenciaInbound.Add(LogRecurrenciaInbound);
                unitWorkLog.Complete();
                unitWorkLog.Dispose();

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
        public void ActualizarGRecurrenciaInbound(GPrincipalRecurrenciaInbound recurrenciainbound)
        {
            try
            {
                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                recurrenciainbound.FechaGestion = DateTime.Now;
                GPrincipalRecurrenciaInbound GPRecurInboundActualizable = unitWork.GPrincipalRecurrenciaInbound.Find(c => c.CuentaCliente == recurrenciainbound.CuentaCliente).FirstOrDefault();

                GPRecurInboundActualizable.FechaGestion = recurrenciainbound.FechaGestion;
                GPRecurInboundActualizable.UsuarioGestion = recurrenciainbound.UsuarioGestion;
                GPRecurInboundActualizable.NombreUsuarioGestion = recurrenciainbound.NombreUsuarioGestion;
                GPRecurInboundActualizable.AliadoGestion = recurrenciainbound.AliadoGestion;
                GPRecurInboundActualizable.CuentaCliente = recurrenciainbound.CuentaCliente;
                GPRecurInboundActualizable.Macroproceso = recurrenciainbound.Macroproceso;
                GPRecurInboundActualizable.ServicioAfectado = recurrenciainbound.ServicioAfectado;
                GPRecurInboundActualizable.ArbolSoporte = recurrenciainbound.ArbolSoporte;
                GPRecurInboundActualizable.FallaCausaRaiz = recurrenciainbound.FallaCausaRaiz;
                GPRecurInboundActualizable.SolucionEspecifica = recurrenciainbound.SolucionEspecifica;
                GPRecurInboundActualizable.Estado = recurrenciainbound.Estado;
                GPRecurInboundActualizable.FallaAtribuibleA = recurrenciainbound.FallaAtribuibleA;
                GPRecurInboundActualizable.PorQue = recurrenciainbound.PorQue;
                GPRecurInboundActualizable.ActivacionClaroVideoNagra = recurrenciainbound.ActivacionClaroVideoNagra;
                GPRecurInboundActualizable.ServicioOfrecido = recurrenciainbound.ServicioOfrecido;
                GPRecurInboundActualizable.AceptacionServicioOfrecido = recurrenciainbound.AceptacionServicioOfrecido;
                GPRecurInboundActualizable.Observaciones = recurrenciainbound.Observaciones;
                unitWork.Complete();
                unitWork.Dispose();

                UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
                GLogRecurrenciaInbound LogRecurrenciaInbound = new GLogRecurrenciaInbound();

                LogRecurrenciaInbound.FechaGestion = recurrenciainbound.FechaGestion;
                LogRecurrenciaInbound.UsuarioGestion = recurrenciainbound.UsuarioGestion;
                LogRecurrenciaInbound.NombreUsuarioGestion = recurrenciainbound.NombreUsuarioGestion;
                LogRecurrenciaInbound.AliadoGestion = recurrenciainbound.AliadoGestion;
                LogRecurrenciaInbound.CuentaCliente = recurrenciainbound.CuentaCliente;
                LogRecurrenciaInbound.Macroproceso = recurrenciainbound.Macroproceso;
                LogRecurrenciaInbound.ServicioAfectado = recurrenciainbound.ServicioAfectado;
                LogRecurrenciaInbound.ArbolSoporte = recurrenciainbound.ArbolSoporte;
                LogRecurrenciaInbound.FallaCausaRaiz = recurrenciainbound.FallaCausaRaiz;
                LogRecurrenciaInbound.SolucionEspecifica = recurrenciainbound.SolucionEspecifica;
                LogRecurrenciaInbound.Estado = recurrenciainbound.Estado;
                LogRecurrenciaInbound.FallaAtribuibleA = recurrenciainbound.FallaAtribuibleA;
                LogRecurrenciaInbound.PorQue = recurrenciainbound.PorQue;
                LogRecurrenciaInbound.ActivacionClaroVideoNagra = recurrenciainbound.ActivacionClaroVideoNagra;
                LogRecurrenciaInbound.ServicioOfrecido = recurrenciainbound.ServicioOfrecido;
                LogRecurrenciaInbound.AceptacionServicioOfrecido = recurrenciainbound.AceptacionServicioOfrecido;
                LogRecurrenciaInbound.Observaciones = recurrenciainbound.Observaciones;
                unitWorkLog.GLogRecurrenciaInbound.Add(LogRecurrenciaInbound);
                unitWorkLog.Complete();
                unitWorkLog.Dispose();

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

        public GPrincipalRecurrenciaInbound TraerGPrinRecurrenciaInbound(int CuentaCliente)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.GPrincipalRecurrenciaInbound.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
        public List<GPrincipalRecurrenciaInbound> ListaSeguimientosRecurrenciaInbound()
        {
            DimeContext dimContext = new DimeContext();
            List<GPrincipalRecurrenciaInbound> result = new List<GPrincipalRecurrenciaInbound>();
            var objetosResult = (from a in dimContext.GPrincipalRecurrenciaInbound
                                 where a.Estado == "SEGUIMIENTO"
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.ArbolSoporte,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,                                     
                                     a.Estado,
                                     a.FallaAtribuibleA,
                                     a.PorQue,
                                     a.ActivacionClaroVideoNagra,
                                     a.ServicioOfrecido,
                                     a.AceptacionServicioOfrecido,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GPrincipalRecurrenciaInbound());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].ArbolSoporte = objetosResult[i].ArbolSoporte;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Estado = objetosResult[i].Estado;
                result[i].FallaAtribuibleA = objetosResult[i].FallaAtribuibleA;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].ServicioOfrecido = objetosResult[i].ServicioAfectado;
                result[i].AceptacionServicioOfrecido = objetosResult[i].AceptacionServicioOfrecido;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public List<GLogRecurrenciaInbound> ListaHistSeguiRecurrenciaInbound(decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<GLogRecurrenciaInbound> result = new List<GLogRecurrenciaInbound>();
            var objetosResult = (from a in dimContext.GLogRecurrenciaInbound
                                 where a.CuentaCliente == CuentaCliente
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.ArbolSoporte,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,
                                     a.Estado,
                                     a.FallaAtribuibleA,
                                     a.PorQue,
                                     a.ActivacionClaroVideoNagra,
                                     a.ServicioOfrecido,
                                     a.AceptacionServicioOfrecido,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GLogRecurrenciaInbound());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].ArbolSoporte = objetosResult[i].ArbolSoporte;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Estado = objetosResult[i].Estado;
                result[i].FallaAtribuibleA = objetosResult[i].FallaAtribuibleA;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].ServicioOfrecido = objetosResult[i].ServicioAfectado;
                result[i].AceptacionServicioOfrecido = objetosResult[i].AceptacionServicioOfrecido;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
    }
}
    