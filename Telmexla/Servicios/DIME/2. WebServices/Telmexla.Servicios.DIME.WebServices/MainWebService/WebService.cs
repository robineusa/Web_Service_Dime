using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.IWebServices.IMainWebService;
using Telmexla.Servicios.DIME.Helpers.ExtenMethods;

namespace Telmexla.Servicios.DIME.WebServices.MainWebService
{
    public class WebService : IWebService, ILoginService
    {
        public bool AutenticarUsuario(Usuario usuario)
        {
            LoginService lService = new LoginService();
            return lService.AutenticarUsuario(usuario);
        }


        public Usuario MuestraEntidades()
        {
            return new Usuario();
        }

        public List<PreguntasDesbloqueo> ObtenerPosiblesPreguntas()
        {
            LoginService lService = new LoginService();
            return lService.ObtenerPosiblesPreguntas();
        }

        public Usuario RecibirUsuario()
        {
            LoginService lService = new LoginService();
            return lService.RecibirUsuario();
        }

        public bool RegistrarActualizarPreguntas(List<PreguntasDesbloqueo> preguntas, List<string> respuestas, Usuario usuario, int noPreguntas)
        {
            LoginService lService = new LoginService();
            return lService.RegistrarActualizarPreguntas(preguntas,respuestas, usuario, noPreguntas);
        }
    }
}
