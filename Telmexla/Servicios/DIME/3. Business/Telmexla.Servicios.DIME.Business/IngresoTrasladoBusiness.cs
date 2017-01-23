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

                NotasTraslado CrearDireccion = new NotasTraslado();

                CrearDireccion.IdTransaccion = ingreso.IdTransaccion;
                CrearDireccion.UsuarioTransaccion = ingreso.UsuarioApertura;
                CrearDireccion.CanalTransaccion = "INBOUND TRASLADOS";
                CrearDireccion.FechaTransaccion = DateTime.Now;
                CrearDireccion.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
                CrearDireccion.CuentaCliente = ingreso.CuentaCliente;
                CrearDireccion.Razon = "SOLICITUD INBOUND";
                CrearDireccion.Subrazon = "CREACION DE DIRECCION";
                CrearDireccion.EstadoTransaccion = "PENDIENTE POR CREAR";
                unitWork.notasTraslados.Add(CrearDireccion);
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
    }
}
