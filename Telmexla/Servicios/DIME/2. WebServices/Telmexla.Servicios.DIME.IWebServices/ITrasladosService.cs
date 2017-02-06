﻿using System;
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
        void RegistrarIngresoTraslado(IngresoTraslado ingreso, NotasTraslado notaTraslado,TraficoTraslado transaccion);
        [OperationContract]
        bool ExisteCuentaEscalada(decimal cuenta);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion();
        [OperationContract]
        NotasTrasladoCollection ListaInteraccionesCrearDireccion(int id);
        [OperationContract]
        void ActualizarSolicitudCrearDireccion(IngresoTraslado ingreso, NotasTraslado notaTraslado,TraficoTraslado transaccion);
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
        void InsertIngresoCambioEstrato(IngresoTraslado ingreso, CambioEstrato cambioEstrato, TraficoTraslado transaccion);
        [OperationContract]
        bool ExisteCuentaEscaladaCambioEstrato(decimal cuenta);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSolicitudesCambioEstrato();
        [OperationContract]
        CambioEstratoCollection ListaInteraccionesCambioEstrato(int id);
        [OperationContract]
        void ActualizarSolicitudCambioEstrato(IngresoTraslado ingreso, CambioEstrato CambioEstrato, TraficoTraslado transaccion);
        [OperationContract]
        bool TransaccionEnGestionCambioEstrato(int id, String usrABackOffice);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSeguimientosCambiodeEstratoCelula(string usrABackOffice);
        [OperationContract]
        List<DatoConsultaDirecciones> ListGestionCambioDeEstrato(DateTime FechaInicial, DateTime FechaFinal, string usrTransac);

        //PROCESOS LIBERACION DE HOME PASS
        [OperationContract]
        void InsertIngresoLiberacionHomePass(IngresoTraslado ingreso, LiberacionHomePass liberacion, TraficoTraslado transaccion);
        [OperationContract]
        bool ExisteCuentaEscaladaLiberacionHomePass(decimal cuenta);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSolicitudesLiberacionesHomePass();
        [OperationContract]
        LiberacionHomePassCollection ListaInteraccionesLiberacionHomePass(int id);
        [OperationContract]
        void ActualizarSolicitudLiberacionesHomePass(IngresoTraslado ingreso, LiberacionHomePass liberacion, TraficoTraslado transaccion);
        [OperationContract]
        bool TransaccionEnGestionLiberacionHomePass(int id, String usrABackOffice);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSeguimientosLiberacionHomePassCelula(string usrABackOffice);
        [OperationContract]
        List<DatoConsultaDirecciones> ListGestionLiberacionHomePass(DateTime FechaInicial, DateTime FechaFinal, string usrTransac);
    }
}
