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
    public class IngresoTrasladoBusiness
    {
        public void InsertIngresoTraslado(IngresoTraslado ingreso,NotasTraslado notaTraslado)
        {
            try
            {
                ingreso.TipoGestion = "CREACION DE DIRECCION";
                ingreso.FechaApertura = DateTime.Now;
                ingreso.HoraApertura = DateTime.Now;
                ingreso.FechaUltimaActualizacion = DateTime.Now;
                ingreso.HoraUltimaActualizacion = DateTime.Now;
                ingreso.EstadoTransaccion= "PENDIENTE POR CREAR";
                ingreso.NombreLineaEscalado= "CELULA CREACION DIRECCION";

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.ingresoTraslados.Add(ingreso);
                unitWork.Complete();

                notaTraslado.IdTransaccion = ingreso.IdTransaccion;
                notaTraslado.UsuarioTransaccion = ingreso.UsuarioApertura;
                notaTraslado.CanalTransaccion = "INBOUND TRASLADOS";
                notaTraslado.FechaTransaccion = DateTime.Now;
                notaTraslado.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
                notaTraslado.CuentaCliente = ingreso.CuentaCliente;
                notaTraslado.Razon = "SOLICITUD INBOUND";
                notaTraslado.Subrazon = "CREACION DE DIRECCION";
                notaTraslado.EstadoTransaccion = "PENDIENTE POR CREAR";
                unitWork.notasTraslados.Add(notaTraslado);
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
        public bool ExisteCuentaEscalada(decimal cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.ingresoTraslados.Find(c => c.CuentaCliente.Equals(cuenta) && c.EstadoTransaccion != "FINALIZADO" && c.TipoGestion == "CREACION DE DIRECCION").Count() >= 1;

        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion() {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in dimContext.NotasTraslados on a.IdTransaccion equals b.IdTransaccion
                                 join c in dimContext.MaestroNodos on b.Nodo.Trim() equals c.Nodo.Trim()
                                 where a.EstadoTransaccion.Equals("PENDIENTE POR CREAR")
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     b.Estrato,
                                     a.FechaApertura,
                                     a.UsuarioApertura,
                                     b.DireccionACrear,
                                     b.Nodo,
                                     c.NombreNodo,
                                     c.Div,
                                     c.Com,
                                     c.Area,
                                     c.Distrito,
                                     c.Divisional,
                                     c.Ugestion,
                                     c.Estado,
                                     c.Red,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for(int i = 0; i< objetosResult.Count; i++)
                {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NotaTrasladoGetSet.Estrato = objetosResult[i].Estrato;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].NotaTrasladoGetSet.DireccionACrear = objetosResult[i].DireccionACrear;
                result[i].NotaTrasladoGetSet.Nodo = objetosResult[i].Nodo;
                result[i].MaestroNodo.NombreNodo = objetosResult[i].NombreNodo;
                result[i].MaestroNodo.Div = objetosResult[i].Div;
                result[i].MaestroNodo.Com = objetosResult[i].Com;
                result[i].MaestroNodo.Area = objetosResult[i].Area;
                result[i].MaestroNodo.Distrito = objetosResult[i].Distrito;
                result[i].MaestroNodo.Divisional = objetosResult[i].Divisional;
                result[i].MaestroNodo.Ugestion = objetosResult[i].Ugestion;
                result[i].MaestroNodo.Estado = objetosResult[i].Estado;
                result[i].MaestroNodo.Red = objetosResult[i].Red;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }
            

            return result;
        }
    }
}
