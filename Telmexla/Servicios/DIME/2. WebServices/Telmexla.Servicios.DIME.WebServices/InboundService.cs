using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.WebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class InboundService : IInboundService
    {
        public bool RegistrarActualizarDatosAdicionalesCliente(DatosAdicionalesCliente datosAdicionalesCliente)
        { 
            
            DimeContext context = new DimeContext();

            if (context.DatosAdicionalesClientes.Where(c => c.Cuenta == datosAdicionalesCliente.Cuenta).Any())
            {
                context.DatosAdicionalesClientes.Attach(datosAdicionalesCliente);
                var entry = context.Entry(datosAdicionalesCliente);
                entry.Property(e => e.TelefonoPersonal).IsModified = true;
                entry.Property(e => e.CorreoElectronico).IsModified = true;
                entry.Property(e => e.FechaCumpleanos).IsModified = true;
                entry.Property(e => e.RangoDeEdad).IsModified = true;
                entry.Property(e => e.Hobbie).IsModified = true;
                entry.Property(e => e.Twitter).IsModified = true;
                entry.Property(e => e.Facebook).IsModified = true;
                entry.Property(e => e.Instagram).IsModified = true;
                entry.Property(e => e.Otro).IsModified = true;
                entry.Property(e => e.NumeroHijos).IsModified = true;
                entry.Property(e => e.EdadHijos).IsModified = true;
                entry.Property(e => e.NivelEstudios).IsModified = true;

                ClientesTodo clientesTodo =    context.ClientesTodoes.Where(c => c.Cuenta == datosAdicionalesCliente.Cuenta).FirstOrDefault();
                clientesTodo.TelefonoConv = datosAdicionalesCliente.TelefonoPersonal.ToString();
                context.ClientesTodoes.Attach(clientesTodo);
                var entry2 = context.Entry(clientesTodo);
                entry2.Property(e => e.TelefonoConv).IsModified = true;

            }
            else
            {
                context.DatosAdicionalesClientes.Add(datosAdicionalesCliente);
            }
            context.SaveChanges();
            return true;
        }

        public ClientesTodo TraerClienteCompletoPorCuenta(int cuenta)
        {
            DimeContext context = new DimeContext();
            return context.ClientesTodoes.Where(c => c.Cuenta == cuenta).FirstOrDefault();
        }

        public DatosAdicionalesCliente TraerDatosAdicionalesCliente(int cuenta)
        {
            DimeContext context = new DimeContext();
            return context.DatosAdicionalesClientes.Where(c => c.Cuenta == cuenta).FirstOrDefault();

        }


        public List<ClientesTodo> ConsultarCuentasPorcedula(string cedula)
        {
            DimeContext context = new DimeContext();
            List < ClientesTodo > resultado = context.ClientesTodoes.Where(c => c.Cedula == cedula).ToList();
            return resultado;
        }

        public List<string> ConsultarHobbiesOptions()
        {
            DimeContext context = new DimeContext();
            return context.TmpMaestroHobbiesClientes.Select(x => x.Hobby).ToList();
        }


        public void RegistrarIngresoInbound(ClientesTodo infoCliente, Ingreso ingreso, string observacion, IngresosSoporte ingresoSoporte)
        {
            if (ingresoSoporte.TipoSegumiento.Equals("CELULA OUTBOUND SOPORTE") || ingresoSoporte.TipoSegumiento.Equals("CELULA SEGUIMIENTO VISITAS"))
                ingreso.NombreLineaEscalado = ingresoSoporte.TipoSegumiento;

                IngresoBusiness ingresoBusi = new IngresoBusiness();
            ingreso = ingresoBusi.PonerDatosBasicosEnIngreso(infoCliente, ingreso);
            ingresoBusi.InsertIngreso( ingreso, observacion, ingresoSoporte);
        }

        public IngresoCollection ListaIngresosDeCuenta(string cuenta)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
           return  ingresoBusi.GetListaIngresos(cuenta);
        }

        public List<TablaActualizarInbound> ListaHistorialCaso(int idIngreso)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetTablaActualizarInbound(idIngreso);
        }

        public void ActualizarIngresoInbound(Ingreso ingreso, string observacion, string llamadaCliente)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            ingresoBusi.ActualizarIngreso(ingreso, observacion, llamadaCliente);
        }

        public List<DatoConsultaGestion> ConsultaGestion(DateTime fechaInicial, DateTime fechaFinal, string idUsuario)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.TableGestionAsesor(fechaInicial, fechaFinal, idUsuario);
        }

        public List<DatoConsultaRechazo> ConsultaRechazos(DateTime fechaInicial, DateTime fechaFinal, string idUsuario, bool esPerfilAdmin)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.TableRechazosInfo(fechaInicial, fechaFinal, idUsuario, esPerfilAdmin);
        }


        public  IngresoCollection ConsultaSegumiento(string idUsuario)
        {   IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.SeguimientosInfo(idUsuario);
        }





    }
}
