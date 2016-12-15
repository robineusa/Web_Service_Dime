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
