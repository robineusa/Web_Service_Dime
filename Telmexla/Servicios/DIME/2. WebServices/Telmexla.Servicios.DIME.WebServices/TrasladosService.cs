using System;
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
        public void RegistrarIngresoTraslado(IngresoTraslado ingreso, NotasTraslado notaTraslado)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoTraslado(ingreso, notaTraslado);
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
        public void ActualizarSolicitudCrearDireccion(IngresoTraslado ingreso, NotasTraslado notaTraslado)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudCrearDireccion(ingreso, notaTraslado);
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
            return ingresoBusi.ListGestionCrearDireccion(FechaInicial,FechaFinal,usrTransac);
        }
        //PROCESO CAMBIO DE ESTRATO
        public void InsertIngresoCambioEstrato(IngresoTraslado ingreso, CambioEstrato cambioEstrato)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoCambioEstrato(ingreso, cambioEstrato);
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
        public void ActualizarSolicitudCambioEstrato(IngresoTraslado ingreso, CambioEstrato CambioEstrato)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudCambioEstrato(ingreso, CambioEstrato);
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

        }
    }
