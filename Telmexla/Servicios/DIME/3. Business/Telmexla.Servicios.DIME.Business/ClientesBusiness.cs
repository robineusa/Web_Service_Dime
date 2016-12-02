using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class ClientesBusiness
    {



         public  bool RegistrarDatosAdicionalesCliente()
         {


            return false;
         }


        public bool VerificarCuentaExiste(string cuenta)
        {
            /*
            if (context.DatosAdicionalesClientes.Where(c => c.Cuenta == datosAdicionalesCliente.Cuenta).Any())
            {

             
            }
            */
            return false;
            
        }


        /*
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
            }
            else
            {
                context.DatosAdicionalesClientes.Add(datosAdicionalesCliente);
            }
context.SaveChanges();
            return true;

    */




        public ClientesTodo ObtenerClienteCompleto(int cuenta)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.clientesTodo.Get(cuenta);
        }


    }
}
