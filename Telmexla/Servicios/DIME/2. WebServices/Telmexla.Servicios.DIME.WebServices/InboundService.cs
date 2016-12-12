using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
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

            if(context.DatosAdicionalesClientes.Where(c=>c.Cuenta==datosAdicionalesCliente.Cuenta).Any())
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


        public void RegistrarIngresoInbound(ClientesTodo infoCliente, Ingreso ingreso, string observacion)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            ingreso = ingresoBusi.PonerDatosBasicosEnIngreso(infoCliente, ingreso);
            ingresoBusi.InsertIngreso( ingreso, observacion);

        }

    }
}
