using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{


    public class CasosCelulaService : ICasosCelulaService
    {
        public IngresoCollection ListaCasosAbiertosDeCelulaUser(string lineaUser, string aliadoUser)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetCasosAbiertosDeCelulaUser(lineaUser, aliadoUser);
        }

        public IngresoCollection ListaCasosEnSeguimiento(string usuario)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetCasosEnSeguimiento(usuario);
        }

        public List<GestionDeCelulaUsr> ListaGestionCasos(DateTime inicial, DateTime final, string idUsr)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetGestionesDeCelula(inicial, final, idUsr);
        }

        public IngresoCollection ListaIngresosPorCuenta(string cuenta)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetIngresosPorCuenta(cuenta);
        }

        public IngresoCollection ListaIngresosPorId(string id)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetIngresoDeId(id);
        }

        public bool CasoTomadoPorUsrBackActualizar(int idIngreso, string usrBack)
        {
            IngresoBusiness ingreBusi = new IngresoBusiness();
            return ingreBusi.UsrBackOfficeIngresoSetActualizar(idIngreso, usrBack);

        }

        //void ActualizarIngresoPorCelula(string estadoCaso, string areaAEscalar, string aplicaRechazo, string razonRechazo, string notas, int idIngreso)
        //{
        //    IngresoBusiness ingreBusi = new IngresoBusiness();
        //    string llamadaCliente = "NO";
        //    Ingreso ingreso = new Ingreso();
        //    ingreso.IdEstado = Convert.ToInt32(estadoCaso);
        //    ingreso.NombreLineaEscalado = areaAEscalar;
        //    ingreso.IdIngreso = idIngreso;
        //   // ingreBusi.ActualizarIngreso()
        //    if(aplicaRechazo.Equals("SI"))
        //    {

        //    }else
        //    {
                
        //    }

        //}
    }
}
