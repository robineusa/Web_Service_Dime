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
        bool AutenticarUsuario(Usuario usuario);


        [OperationContract]
        Usuario RecibirUsuario();

        [OperationContract]
        bool RegistrarActualizarPreguntas(List<PreguntasDesbloqueo> preguntas, List<String> respuestas, Usuario usuario, int noPreguntas);

        [OperationContract]
        List<PreguntasDesbloqueo> ObtenerPosiblesPreguntas();


    }


}
