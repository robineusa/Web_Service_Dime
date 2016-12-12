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





    }
}
