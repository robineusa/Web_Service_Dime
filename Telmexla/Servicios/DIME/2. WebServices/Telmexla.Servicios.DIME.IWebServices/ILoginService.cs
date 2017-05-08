using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ILoginService" en el código y en el archivo de configuración a la vez.


    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        int AutenticarUsuarioEnSesion(Usuario usuario);


        [OperationContract]
        Usuario RecibirUsuario();

        [OperationContract]
        Usuario RecibirUsuarioConId(int idUsuario);
        
        [OperationContract]
        bool RegistrarActualizarPreguntas(List<PreguntasDesbloqueo> preguntas, List<String> respuestas, Usuario usuario, int noPreguntas);


        [OperationContract]
        bool RegistrarActualizarDatosUsuario(Usuario usuario);

        
        [OperationContract]
        List<PreguntasDesbloqueo> ObtenerPosiblesPreguntas();

        [OperationContract]
        bool BloquearUsuario(int id, int idUsuarioCambioo, string ipPrivadaCreacion, string ipPublicaCreacion);

        [OperationContract]
        int RecibirIdUsuario(decimal? cedula);


        [OperationContract]
        List<String> ObtenerPreguntasRegistradas(int id);


        [OperationContract]
        bool RespuestasValidas(List<string> respuestas, int idUsuario);


        [OperationContract]
        bool RestablecerContraseña(String contraseña, int idUsuario);

        [OperationContract]
        bool PreguntasDesbloqueoCompletas(int id);

        [OperationContract]
        bool DatosUsuarioCompleto(int id);

        [OperationContract]
        bool ContraseñaCaducada(int id);


        [OperationContract]
        bool Capacitado(int id);

        [OperationContract]
        bool CapacitarUsuario(int id);

        [OperationContract]
        bool RegistrarSesionUsuario(RegistroSesion registroSesion);

        [OperationContract]
        AccesoCollection ListaAccesosDePerfil(int idPerfil);

        [OperationContract]
        LineaCollection ListaLineasDePerfil(int idPerfil);

        [OperationContract]
        BasePersonalHolo ConsultarUsuarioHolos(decimal cedula);

        [OperationContract]
        BasePersonalHoloCollection ListaUsuariosDePerfilYAliado(int idPerfil, string aliado);


        [OperationContract]
        void CrearUsuario(int idLinea, int idPerfil, BasePersonalHolo usuarioHolos, string[] permisosOtorgados, string contraseña, string usuarioCambio);


        [OperationContract]
        string LineaDeUsuario(int idUsuario);


        [OperationContract]
        int IdLineaDeUsuario(int idUsuario);

        [OperationContract]
        string PerfilDeUsuario(int idUsuario);
        [OperationContract]
        int IdPerfilDeUsuario(int idUsuario);

        [OperationContract]
        List<string> ListaAccesosDeUsuario(int cedUsuario);


        [OperationContract]
        void  ActualizarAccesosUsuario(int idUsuario,int idPerfil, int idLinea, string [] permisosOtorgados, string contraseña, string usuarioCambioo);

        [OperationContract]
        void ActualizarAccesosUsuarioMasivo(List<string> listaUsuariosCambiados, int idLinea, List<string> listaPermisos, string idUsuarioCambioo);

        [OperationContract]
        List<UsuariosMasivoData> ListaDatosUsuariosHolosPorCedulas(List<string> cedulas);

        [OperationContract]
        void GuardarUsuariosMasivosConAccesos(List<string> cedulas,List<string> accesosCrear,int perfilCrear,int lineaCrear, string contraMasiva, int idUsuario);

        [OperationContract]
        string AliadoDeUsuario(decimal? cedula);

        [OperationContract]
        string LineaDeUsuarioPorId(int idUsuario);

        [OperationContract]
        string ModoLoginPorId(int idUsuario);

        [OperationContract]
        bool ExisteUsuarioHolos(decimal cedula);

        [OperationContract]
        string OperacionPorCedula(int Cedula);

        [OperationContract]
        string CampañaPorCedula(int Cedula);



    }


}
