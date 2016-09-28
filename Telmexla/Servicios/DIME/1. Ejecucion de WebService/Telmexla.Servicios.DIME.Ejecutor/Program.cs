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

namespace Telmexla.Servicios.DIME.Ejecutor
{
    class Program
    {
            static void Main()
          {
            LoginService login = new LoginService();

            //  using (ServiceHost host = new ServiceHost(typeof(WebService)))
            //{
            try { 
                    Usuario usuario = new Usuario();
                   usuario.Cedula = 1032000123;
                   usuario.Contrasena = "Claro2016";
                   Debug.Print(login.AutenticarUsuario(usuario)+" autenticar", login.AutenticarUsuario(usuario)+ " autenticar");

                List<PreguntasDesbloqueo> preguntasDesb = new List<PreguntasDesbloqueo>();
                List<String> respuestas = new List<String>();
                for (int i = 0; i< 5;i++)
                {   PreguntasDesbloqueo pdesb = new PreguntasDesbloqueo();
                    pdesb.Id = i + 1;
                    preguntasDesb.Add(pdesb);
                    String respuesta = "resputa tercera" + i;
                    respuestas.Add(respuesta);
                }

                usuario.Id = 1;
                Debug.Print(login.RegistrarActualizarPreguntas(preguntasDesb,respuestas, usuario, 5) + " reg preguntas desb", login.RegistrarActualizarPreguntas(preguntasDesb, respuestas, usuario, 5) + " reg preguntas desb");


                //  host.Open();
                Console.WriteLine("Host started at " + DateTime.Now.ToString());
                   Console.ReadLine();
            }
            catch(Exception e)
            {   Debug.Print("Comienzo error "+e+"error sacado", "Comienzo error " + e +" error sacado");
                Console.ReadLine();
            }  
                //}
            }
    }
}
