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

    }
    }
