using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.WebServices;
using Telmexla.Servicios.DIME.WebServices.MainWebService;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.Entity;
using System.Diagnostics;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;

namespace Telmexla.Servicios.DIME.Ejecutor
{
    class Program
    {
            static void Main()
          {

           ClientesTodo DatosCliente = new ClientesTodo();
            ConvenioElectronicoCollection HistoricoConvenioElectronico = new ConvenioElectronicoCollection();
            ConvenioElectronico ConvenioElecGestionado = new ConvenioElectronico();
            BlendingService blendingServices = new BlendingService();
            DatosCliente = blendingServices.TraerMisDatosClienteAutomaticos(1, "CONVENIO_ELECTRONICO");

            ConvenioElecGestionado.AliadoGestion = "OUTSOURCING PEREIRA";
            ConvenioElecGestionado.LineaGestion = "OUTBOUND";
            ConvenioElecGestionado.Cierre = "3";
            ConvenioElecGestionado.Razon = "12";
            ConvenioElecGestionado.TipoContacto = "5";

            blendingServices.GuardarGestionConvenioElectronico(1, DatosCliente, ConvenioElecGestionado);



            var result2 =  blendingServices.TraerMisDatosClienteAutomaticos(1, "CONVENIO_ELECTRONICO");

            var result3 = blendingServices.TraerHistorialConvenioElectroDeAsesor(1);












            UnitOfWork unitWork = new UnitOfWork(new DimeContext());

            GestionOutbound gestion = unitWork.gestionesOutbound.Get(1);
            gestion.UsuarioGestionando = 5;
            unitWork.Complete();


            LoginService login = new LoginService();


            IInboundService inbound = new InboundService();

            IMaestrosService maestros = new MaestrosService();

            var tiposContactos = maestros.ObtenerTiposDeMotivoDeCausas(115);

            Usuario usuario = new Usuario();
            usuario.Cedula = 1032000456;
            usuario.Contrasena = "Claro2016";
            usuario.Id = (int)login.RecibirIdUsuario(usuario.Cedula);
            var result = login.AutenticarUsuarioEnSesion(usuario);
      





            int i = 0;
            


            #region inbound tests
            /*
            DatosAdicionalesCliente datosAdicionales = new DatosAdicionalesCliente();
            datosAdicionales.Cuenta = 23682065;
            datosAdicionales.CorreoElectronico = null;
            datosAdicionales.Hobbie = null;
            datosAdicionales.NivelEstudios = "TÉCNICO";

            Debug.Print(inbound.RegistrarActualizarDatosAdicionalesCliente(datosAdicionales) + "actualizar datos adicionales", inbound.RegistrarActualizarDatosAdicionalesCliente(datosAdicionales) + " actualizar datos adicionales");
            */
            #endregion
            /*
               //    try { 
               Usuario usuario = new Usuario();
                      usuario.Cedula = 1032000123;
                      usuario.Contrasena = "Claro2016";
                       usuario.Id = (int)login.RecibirIdUsuario(usuario.Cedula);
               usuario.Correo = "alejanda@asdasd.com";
               string fecha = "2016-10-04";
               usuario.FechaNacimiento = Convert.ToDateTime(fecha);
               usuario.Telefono = 123123;
              Debug.Print(login.AutenticarUsuarioEnSesion(usuario)+" autenticar", login.AutenticarUsuarioEnSesion(usuario)+ " autenticar");
               int cuenta = 2500064;
               ClientesTodo cliente = inbound.TraerClienteCompletoPorCuenta(cuenta);
               List<ClientesTodo> clientes = inbound.ConsultarCuentasPorcedula("21228586");
               Debug.Print(inbound.ConsultarCuentasPorcedula("51865550") + " autenticar", inbound.ConsultarCuentasPorcedula("72270961") + " autenticar");
               List<PreguntasDesbloqueo> preguntasDesb = new List<PreguntasDesbloqueo>();
                   List<String> respuestas = new List<String>();
                   for (int i = 0; i< 5;i++)
                   {   PreguntasDesbloqueo pdesb = new PreguntasDesbloqueo();
                       pdesb.Id = i + 1;
                       preguntasDesb.Add(pdesb);
                       String respuesta = "resputa tercera" + i;
                       respuestas.Add(respuesta);
                   }
               usuario.Genero = "M";
               usuario.Id = 3;
               Debug.Print(login.RestablecerContraseña("456",1) + " reg preguntas desb", login.RestablecerContraseña("456", 1) + " reg preguntas desb");
               usuario.Id = 1;
               Console.ReadLine();
               */
            using (ServiceHost host = new ServiceHost(typeof(WebService)))
            {
                //  Debug.Print(login.RegistrarActualizarPreguntas(preguntasDesb,respuestas, usuario, 5) + " reg preguntas desb", login.RegistrarActualizarPreguntas(preguntasDesb, respuestas, usuario, 5) + " reg preguntas desb");


                host.Open();
                Console.WriteLine("Host started at " + DateTime.Now.ToString());
                Console.ReadLine();
            }

                //     Debug.Print(login.BloquearUsuario(1, 2, "172.16.248.81") + "  desb", login.BloquearUsuario(1,2,"172.16.248.81") + " desb");
                //    Console.WriteLine("Host started at " + DateTime.Now.ToString());
                //  Console.ReadLine();
                // }
                /*  catch(Exception e)
                  {   Debug.Print("Comienzo error "+e+"error sacado", "Comienzo error " + e +" error sacado");
                      Console.ReadLine();
                  }  */
                //}
            }
    }
}
