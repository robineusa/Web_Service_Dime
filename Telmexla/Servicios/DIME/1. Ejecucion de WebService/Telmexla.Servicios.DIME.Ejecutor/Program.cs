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
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Helpers.Encription;

namespace Telmexla.Servicios.DIME.Ejecutor
{
    class Program
    {
        static void Main()
        {
            MaestroNodo nodo = new MaestroNodo();
            MaestroNodoService servicenodo = new MaestroNodoService();

           var dato = "AAA";
            Console.WriteLine(servicenodo.ExisteNodo(dato));
            //nodo.NombreNodo = "ROBIN";
            //nodo.Div = "AAA";
            //nodo.Com = "AAA";
            //nodo.Divisional =11;
            //nodo.Area = 11;
            //nodo.Distrito = 11;
            //nodo.Ugestion = 11;
            //nodo.Usuario = "robineusa";
            //nodo.Estado = "activo";
            //nodo.Red = "dth";
            //nodo.Aliado = "BRM";

            //servicenodo.ExisteNodo(dato);

            //IngresoTraslado ingresotraslado = new IngresoTraslado();
            //TrasladosService traslados = new TrasladosService();
            //ingresotraslado.CuentaCliente = 307;
            //ingresotraslado.Direccion = "ESTE CAMPO DE DIRECCION";
            //ingresotraslado.Estrato = "NR";
            //ingresotraslado.Nodo = "AAAADSA";
            //ingresotraslado.TelefonoCelular = "3228451001";
            //ingresotraslado.TelefonoFijo="9005668";
            //ingresotraslado.FechaApertura = DateTime.Now;
            //ingresotraslado.HoraApertura = DateTime.Now;
            //ingresotraslado.UsuarioApertura = "ROBINEUSA";
            //ingresotraslado.FechaUltimaActualizacion = DateTime.Now;
            //ingresotraslado.UsuarioUltimaActualizacion = "ROBINEUSA";
            //ingresotraslado.HoraUltimaActualizacion = DateTime.Now;
            //ingresotraslado.AliadoApertura = "BRM";
            //ingresotraslado.NombreLineaIngreso = "GESTION DE LA INFORMACION";

            //var observacion = "SE GENERA LA CREACION DE UN CASO DE PRUEBA";
            //traslados.RegistrarIngresoTraslado(ingresotraslado, observacion);





            DateTime fechaInicial = Convert.ToDateTime("2016-11-01");
                DateTime fechaFinal = Convert.ToDateTime("2017-01-01");
            IngresoBusiness busi = new IngresoBusiness();

            Debug.Print(new GeneralEncriptor().GetEncriptedData("Clarop2017") )  ;
            Console.WriteLine(new GeneralEncriptor().GetEncriptedData("Clarop2017"));

            ClientesTodo DatosCliente = new ClientesTodo();

            DatosCliente.Apellido = "CUARTAS";
            DatosCliente.Cuenta = 430;
            DatosCliente.DirInstalacion = "CR 5Este 14-87 casa 74";
            DatosCliente.Estrato = "3";
            DatosCliente.Nombre = "JEANETH";
            DatosCliente.NombreComunidad = "VILLAVICENCIO";
            DatosCliente.Telefono1 = "3115244589";
            DatosCliente.Telefono2 = "0";
            DatosCliente.Telefono3 = "0";

            ClaroVideo claroVideoGestionado = new ClaroVideo();
            claroVideoGestionado.AliadoGestion = "OUTSOURCING PEREIRA";
            claroVideoGestionado.Attributo1 = 1;
            claroVideoGestionado.Attributo2 = 1;
            claroVideoGestionado.Cierre = "76";
            claroVideoGestionado.Id = 0;
            claroVideoGestionado.Observaciones = "marca pocas";
            claroVideoGestionado.Razon = "20";
            claroVideoGestionado.TipoDeContacto = "20";
            claroVideoGestionado.TipoDeGestion = "21";

         //   blendingService.GuardarGestionClaroVideo(1,DatosCliente, claroVideoGestionado );
  
     
            ConvenioElectronicoCollection HistoricoConvenioElectronico = new ConvenioElectronicoCollection();
            ConvenioElectronico ConvenioElecGestionado = new ConvenioElectronico();
            BlendingService blendingServices = new BlendingService();
            var resultado50 = blendingServices.ListaClaroVideosGestionados(fechaInicial, fechaFinal);

            ConvenioElecGestionado.AliadoGestion = "OUTSOURCING PEREIRA";
            ConvenioElecGestionado.LineaGestion = "OUTBOUND";
            ConvenioElecGestionado.Cierre = "3";
            ConvenioElecGestionado.Razon = "12";
            ConvenioElecGestionado.TipoContacto = "5";

            blendingServices.GuardarGestionConvenioElectronico(1, DatosCliente, ConvenioElecGestionado);



            var result2 =  blendingServices.TraerMisDatosClienteAutomaticos(1, "CONVENIO_ELECTRONICO");

            var result3 = blendingServices.TraerHistorialConvenioElectroDeAsesor(1);













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
