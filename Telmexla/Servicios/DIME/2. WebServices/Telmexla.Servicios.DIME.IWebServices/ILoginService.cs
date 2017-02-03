using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
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

    }


}
