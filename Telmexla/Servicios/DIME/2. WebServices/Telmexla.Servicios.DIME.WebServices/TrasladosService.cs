﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.WebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class TrasladosService : ITrasladosService
    {
        public void RegistrarIngresoTraslado(IngresoTraslado ingreso, NotasTraslado notaTraslado, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoTraslado(ingreso, notaTraslado, transaccion);
        }
        public bool ExisteCuentaEscalada(decimal cuenta)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ExisteCuentaEscalada(cuenta);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesCrearDireccion();
        }
        public NotasTrasladoCollection ListaInteraccionesCrearDireccion(int id) {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaInteraccionesCrearDireccion(id);
        }
        public void ActualizarSolicitudCrearDireccion(IngresoTraslado ingreso, NotasTraslado notaTraslado, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudCrearDireccion(ingreso, notaTraslado, transaccion);
        }
        public bool TransaccionEnGestion(int id, String usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionEnGestion(id, usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosDireccionesCelula(string usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosDireccionesCelula(usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaDireccionesCreadasOutbound()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaDireccionesCreadasOutbound();
        }
        public bool TransaccionEnGestionOut(int id, String usrOut)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionEnGestionOut(id, usrOut);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosDireccionesOutbound(string UsuarioOut)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosDireccionesOutbound(UsuarioOut);
        }
        public List<DatoConsultaDirecciones> ListGestionCrearDireccion(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListGestionCrearDireccion(FechaInicial, FechaFinal, usrTransac);
        }
        //PROCESO CAMBIO DE ESTRATO
        public void InsertIngresoCambioEstrato(IngresoTraslado ingreso, CambioEstrato cambioEstrato, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoCambioEstrato(ingreso, cambioEstrato, transaccion);
        }
        public bool ExisteCuentaEscaladaCambioEstrato(decimal cuenta)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ExisteCuentaEscaladaCambioEstrato(cuenta);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCambioEstrato()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesCambioEstrato();
        }
        public CambioEstratoCollection ListaInteraccionesCambioEstrato(int id)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaInteraccionesCambioEstrato(id);
        }
        public void ActualizarSolicitudCambioEstrato(IngresoTraslado ingreso, CambioEstrato CambioEstrato, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudCambioEstrato(ingreso, CambioEstrato, transaccion);
        }
        public bool TransaccionEnGestionCambioEstrato(int id, String usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionEnGestionCambioEstrato(id, usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosCambiodeEstratoCelula(string usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosCambiodeEstratoCelula(usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListGestionCambioDeEstrato(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListGestionCambioDeEstrato(FechaInicial, FechaFinal, usrTransac);
        }

        //PROCESO LIBERACIONES DE HOME PASS
        public void InsertIngresoLiberacionHomePass(IngresoTraslado ingreso, LiberacionHomePass liberacion, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoLiberacionHomePass(ingreso, liberacion, transaccion);
        }
        public bool ExisteCuentaEscaladaLiberacionHomePass(decimal cuenta)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ExisteCuentaEscaladaLiberacionHomePass(cuenta);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesLiberacionesHomePass()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesLiberacionesHomePass();
        }
        public LiberacionHomePassCollection ListaInteraccionesLiberacionHomePass(int id)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaInteraccionesLiberacionHomePass(id);
        }
        public void ActualizarSolicitudLiberacionesHomePass(IngresoTraslado ingreso, LiberacionHomePass liberacion, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudLiberacionesHomePass(ingreso, liberacion, transaccion);
        }
        public bool TransaccionEnGestionLiberacionHomePass(int id, String usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionEnGestionLiberacionHomePass(id, usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosLiberacionHomePassCelula(string usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosLiberacionHomePassCelula(usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListGestionLiberacionHomePass(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListGestionLiberacionHomePass(FechaInicial, FechaFinal, usrTransac);
        }
        //PROCESO GESTION DE MATRICES
        public void InsertIngresoGestionMatriz(IngresoTraslado ingreso, GestionMatriz matriz, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoGestionMatriz(ingreso, matriz, transaccion);
        }
        public bool ExisteCuentaEscaladaMatriz(decimal cuenta)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ExisteCuentaEscaladaMatriz(cuenta);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCreaciondeMatriz()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesCreaciondeMatriz();
        }
        public GestionMatrizColleciton ListaInteraccionesMatrices(int id)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaInteraccionesMatrices(id);
        }
        public void ActualizarSolicitudMatrices(IngresoTraslado ingreso, GestionMatriz matriz, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudMatrices(ingreso, matriz, transaccion);
        }
        public bool TransaccionCrearMatrizEnGestion(int id, String usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionCrearMatrizEnGestion(id, usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosCrearMatrizCelula(string usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosCrearMatrizCelula(usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesGestionMatriz()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesGestionMatriz();
        }
        public bool TransaccionGestionMatrizEnGestion(int id, String usrOut)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionGestionMatrizEnGestion(id, usrOut);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosGestionMatricesCelula(string UsuarioOut)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosGestionMatricesCelula(UsuarioOut);
        }
        public List<DatoConsultaDirecciones> ListGestionMatrices(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListGestionMatrices(FechaInicial, FechaFinal, usrTransac);
        }

    }
    }
