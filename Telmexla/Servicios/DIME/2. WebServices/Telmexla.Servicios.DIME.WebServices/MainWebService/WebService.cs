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
    public class WebService : IWebService, ILoginService, IInboundService, IMaestrosService, IBlendingService
    {

        #region Login Service
        public int AutenticarUsuarioEnSesion(Usuario usuario)
        {
            LoginService lService = new LoginService();
            return lService.AutenticarUsuarioEnSesion(usuario);
        }


        public Usuario MuestraEntidades()
        {
            return new Usuario { Nombre = "Alejandro ", Cedula=1033478952 };
        }

        public List<PreguntasDesbloqueo> ObtenerPosiblesPreguntas()
        {
            LoginService lService = new LoginService();
            return lService.ObtenerPosiblesPreguntas();
        }


        public int RecibirIdUsuario(decimal? cedula)
        {
            LoginService lService = new LoginService();
            return lService.RecibirIdUsuario(cedula);
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

        public bool BloquearUsuario(int id, int idUsuarioCambioo, string ipPrivadaCreacion, string ipPublicaCreacion)
        {
            LoginService lService = new LoginService();
            return lService.BloquearUsuario(id,idUsuarioCambioo, ipPrivadaCreacion, ipPublicaCreacion);
        }

        public List<String> ObtenerPreguntasRegistradas(int id)
        {
            LoginService lService = new LoginService();
            return lService.ObtenerPreguntasRegistradas(id);
        }


        public bool RespuestasValidas(List<string> respuestas, int idUsuario)
        {
            LoginService lService = new LoginService();
            return lService.RespuestasValidas(respuestas, idUsuario);

        }

        public bool RestablecerContraseña(String contraseña, int idUsuario)
        {

            LoginService lService = new LoginService();
            return lService.RestablecerContraseña(contraseña, idUsuario);
        }


        public bool PreguntasDesbloqueoCompletas(int id)
        {   LoginService lService = new LoginService();
            return lService.PreguntasDesbloqueoCompletas(id);
        }

        public bool DatosUsuarioCompleto(int id)
        {
            LoginService lService = new LoginService();
            return lService.DatosUsuarioCompleto(id);
        }

        public bool ContraseñaCaducada(int id)
        {
            LoginService lService = new LoginService();
            return lService.ContraseñaCaducada(id);
        }


        public bool Capacitado(int id)
        {
            LoginService lService = new LoginService();
            return lService.Capacitado(id);
        }
        public bool CapacitarUsuario(int id)
        {
            LoginService lService = new LoginService();
            return lService.CapacitarUsuario(id);

        }
        public bool RegistrarActualizarDatosUsuario(Usuario usuario)
        {
            LoginService lService = new LoginService();
            return lService.RegistrarActualizarDatosUsuario(usuario);

        }
        public  bool RegistrarSesionUsuario(RegistroSesion registroSesion)
        {
            LoginService lService = new LoginService();
            return lService.RegistrarSesionUsuario(registroSesion);
        }

        #endregion

        #region Inbound Service 
        public bool RegistrarActualizarDatosAdicionalesCliente(DatosAdicionalesCliente datosAdicionalesCliente)
        {
            InboundService inboundService = new InboundService();
            return inboundService.RegistrarActualizarDatosAdicionalesCliente(datosAdicionalesCliente);
        }

        public ClientesTodo TraerClienteCompletoPorCuenta(int cuenta)
        {
            InboundService inboundService = new InboundService();
            return inboundService.TraerClienteCompletoPorCuenta(cuenta);
        }

        public DatosAdicionalesCliente TraerDatosAdicionalesCliente(int cuenta)
        {
            InboundService inboundService = new InboundService();
            return inboundService.TraerDatosAdicionalesCliente(cuenta);
        }



        public List<ClientesTodo> ConsultarCuentasPorcedula(string cedula)
        {
            InboundService inboundService = new InboundService();
            return inboundService.ConsultarCuentasPorcedula(cedula);
        }


        public List<string> ConsultarHobbiesOptions()
        {
            InboundService inboundService = new InboundService();
            return inboundService.ConsultarHobbiesOptions();

        }


        #endregion

        #region MaestrosService 

        public MaestroOutboundTipoContactoCollection ObtenerTiposDeContactoDeGestion(decimal gestionId)
        {
            MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeContactoDeGestion(gestionId);
        }

        public MaestroOutboundCierreCollection ObtenerTiposDeCierresDeContacto(decimal contactoId)
         {
            MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeCierresDeContacto(contactoId);
         }

        public MaestroOutboundRazonCollection ObtenerTiposDeRazonDeCierres(decimal cierreId)
        {   MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeRazonDeCierres(cierreId);
        }

        public MaestroOutboundCausaCollection ObtenerTiposDeCausasDeRazon(decimal razonId)
        {
            MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeCausasDeRazon(razonId);

        }

        public MaestroOutboundMotivoCollection ObtenerTiposDeMotivoDeCausas(decimal causaId)
        {
            MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeMotivoDeCausas(causaId);

        }
        #endregion



        #region BlendingService

        public ClientesTodo TraerMisDatosClienteAutomaticos(int idAsesor, string gestionBlendingActual)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerMisDatosClienteAutomaticos(idAsesor, gestionBlendingActual);
        }

        public ConvenioElectronicoCollection TraerHistorialConvenioElectroDeAsesor(int idAsesor)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerHistorialConvenioElectroDeAsesor(idAsesor);
        }


        public bool GuardarGestionConvenioElectronico(int idAsesor, ClientesTodo datosCliente, ConvenioElectronico convElectGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.GuardarGestionConvenioElectronico(idAsesor, datosCliente, convElectGestionado);

        }

        public ConvenioElectronico TraerConvenioElectronicoGestionado(int idGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerConvenioElectronicoGestionado(idGestionado);
        }

        public DocsisOverlapCollection TraerHistorialDocsisDeAsesor(int idAsesor)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerHistorialDocsisDeAsesor(idAsesor);
        }

        public DocsisOverlap TraerDocsisGestionado(int idGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerDocsisGestionado(idGestionado);

        }

        public bool GuardarGestionDocsis(int idAsesor, ClientesTodo datosCliente, DocsisOverlap docsisGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.GuardarGestionDocsis(idAsesor, datosCliente, docsisGestionado);
        }

        public ClaroVideoCollection TraerHistorialClaroVideoDeAsesor(int idAsesor)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerHistorialClaroVideoDeAsesor(idAsesor);
        }

        public ClaroVideo TraerClaroVideoGestionado(int idGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerClaroVideoGestionado(idGestionado);

        }

        public bool GuardarGestionClaroVideo(int idAsesor, ClientesTodo datosCliente, ClaroVideo claroVideoGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.GuardarGestionClaroVideo(idAsesor, datosCliente, claroVideoGestionado);

        }

        public CierreCicloCollection TraerHistorialCierreCicloDeAsesor(int idAsesor)
        {

            BlendingService blendingService = new BlendingService();
            return blendingService.TraerHistorialCierreCicloDeAsesor(idAsesor);
        }

        public List<String> TraerNombresDeClientesCierreCiclo(CierreCicloCollection cuentasATraer)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerNombresDeClientesCierreCiclo(cuentasATraer);
        }

        public GestionOutbound TraerGestionOutboundInfoDeCuenta(int cuenta, string gestion)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerGestionOutboundInfoDeCuenta(cuenta, gestion);
        }

        public CierreCiclo TraerCierreCicloGestionado(int idGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerCierreCicloGestionado(idGestionado);
        }

        public bool GuardarCierreCiclo(int idAsesor, ClientesTodo datosCliente, CierreCiclo cierreCicloGestionado)
        {

            BlendingService blendingService = new BlendingService();
            return blendingService.GuardarCierreCiclo(idAsesor, datosCliente, cierreCicloGestionado);
        }
        #endregion

    }
}
