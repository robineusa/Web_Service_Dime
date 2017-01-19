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
        public void InsertIngresoTraslado(IngresoTraslado ingreso, string observacion)
        {
            try
            {
                ingreso.FechaApertura = DateTime.Now;
                ingreso.HoraApertura = DateTime.Now;
                ingreso.FechaUltimaActualizacion = DateTime.Now;
                ingreso.HoraUltimaActualizacion = DateTime.Now;
                ingreso.Razon = "SOLICITUD INBOUND";
                ingreso.Subrazon = "CREACION DE DIRECCION";
                ingreso.EstadoCaso = "PENDIENTE POR CREAR";
                ingreso.NombreLineaEscalado = "CELULA CREACION DIRECCION";

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.ingresoTraslados.Add(ingreso);
                unitWork.Complete();


                NotasTraslado logIngreso = new NotasTraslado();
                logIngreso.IdTraslado = ingreso.IdTraslado;
                logIngreso.CuentaCliente = ingreso.CuentaCliente;
                logIngreso.Usuario = ingreso.UsuarioApertura;
                logIngreso.NombreLineaNota = ingreso.NombreLineaIngreso;
                logIngreso.FechaNota = DateTime.Now;
                logIngreso.HoraNota = DateTime.Now;
                logIngreso.Nota = observacion;
                logIngreso.Razon = ingreso.Razon;
                logIngreso.Subrazon = ingreso.Subrazon;
                logIngreso.Estado = ingreso.EstadoCaso;
                unitWork.notasTraslados.Add(logIngreso);
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
    }
}
