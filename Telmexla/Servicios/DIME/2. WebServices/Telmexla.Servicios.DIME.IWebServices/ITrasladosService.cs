using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface ITrasladosService
    {
        [OperationContract]
        void RegistrarIngresoTraslado(IngresoTraslado ingreso, NotasTraslado notaTraslado);
        [OperationContract]
        bool ExisteCuentaEscalada(decimal cuenta);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion();
        [OperationContract]
        NotasTrasladoCollection ListaInteraccionesCrearDireccion(int id);
        [OperationContract]
        void ActualizarSolicitudCrearDireccion(IngresoTraslado ingreso, NotasTraslado notaTraslado);
        [OperationContract]
        bool TransaccionEnGestion(int id, String usrABackOffice);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSeguimientosDireccionesCelula(string usrABackOffice);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaDireccionesCreadasOutbound();
        [OperationContract]
        bool TransaccionEnGestionOut(int id, String usrOut);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSeguimientosDireccionesOutbound(string UsuarioOut);
        [OperationContract]
        List<DatoConsultaDirecciones> ListGestionCrearDireccion(DateTime FechaInicial, DateTime FechaFinal, string usrTransac);
        //PROCESOS CAMBIOS DE ESTRATO
        [OperationContract]
        void InsertIngresoCambioEstrato(IngresoTraslado ingreso, CambioEstrato cambioEstrato);
        [OperationContract]
        bool ExisteCuentaEscaladaCambioEstrato(decimal cuenta);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSolicitudesCambioEstrato();
        [OperationContract]
        CambioEstratoCollection ListaInteraccionesCambioEstrato(int id);
        [OperationContract]
        void ActualizarSolicitudCambioEstrato(IngresoTraslado ingreso, CambioEstrato CambioEstrato);
        [OperationContract]
        bool TransaccionEnGestionCambioEstrato(int id, String usrABackOffice);


    }
}
