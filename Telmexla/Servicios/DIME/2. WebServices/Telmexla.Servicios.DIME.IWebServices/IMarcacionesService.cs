using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IMarcacionesService
    {
        [OperationContract]
        void RegistrarMarcacion(MaestroMarcacione marcacion);


        [OperationContract]
        MaestroMarcacioneCollection ObtenerMarcacionesPorPalabra(string palabra);


        [OperationContract]
        MaestroMarcacione TraerMarcacionPorId(int id);

        [OperationContract]
        MaestroMarcacioneCollection ListaMarcaciones();



        [OperationContract]
        int GetIdMarcacionPorNombre(string nombre);

        [OperationContract]
        List<String> ListaNombreCodDeSubmarcacion(string submarcacion);

        [OperationContract]
        void EliminarMarcacion(int id);

        [OperationContract]
        MaestroMarcacione GetMarcacionPorId(int id);

        [OperationContract]
        void ActualizarMarcacion(MaestroMarcacione marcacion);

        [OperationContract]
        PqrMaestroCodCierreCollection ListaCodigosDeCierre();

        [OperationContract]
        void EliminarCodigoCierre(int id);

        [OperationContract]
        void AgregarCodigoCierre(PqrMaestroCodCierre codigoCierre);

        [OperationContract]
        void ActualizarCodCierre(PqrMaestroCodCierre codigoCierre);

        [OperationContract]
        PqrMaestroCodCierre CodigoCierrePorId(int idCierre);
    }
}
