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
    public class CierreExperienciaService
    {
        //Desconexiones
        public CEPAsigDesconexiones TraeRegistroAsignacion(decimal Id)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.TraeRegistroAsignacion(Id);
        }
        public void RegistrarDesconexion(CEPDesconexiones Desconexion, decimal IdBaseAsig)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            CierreExpBusiness.RegistrarDesconexion(Desconexion,IdBaseAsig);
        }
        public void ActualizarDesconexion(CEPDesconexiones Desconexion)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            CierreExpBusiness.ActualizarDesconexion(Desconexion);
        }
        public List<CEMArbolesDeGestion> ArbolDeGestionAgente(decimal IdPadre)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ArbolDeGestionAgente(IdPadre);
        }
        public void ActualizarArbolCierreExperiencia(CEMArbolesDeGestion Arbol)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            CierreExpBusiness.ActualizarArbolCierreExperiencia(Arbol);
        }
        public void RegistrarNuevoArbolCierreExperiencia(CEMArbolesDeGestion Arbol)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            CierreExpBusiness.RegistrarNuevoArbolCierreExperiencia(Arbol);
        }
        public CEMArbolesDeGestion TraerArbolCierreExperienciaPorId(decimal IdArbol)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.TraerArbolCierreExperienciaPorId(IdArbol);
        }
        public List<CEPDesconexiones> ListaSeguimientosAgenteCierreExperiencia(decimal Usuario)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaSeguimientosAgenteCierreExperiencia(Usuario);
        }
        public List<CELDesconexiones> ListaDeGestionAgenteCierreExperiencia(decimal Usuario)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaDeGestionAgenteCierreExperiencia(Usuario);
        }
        public List<CEPDesconexiones> ConsultaGeneralAdministradorCierreExperiencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ConsultaGeneralAdministradorCierreExperiencia(FechaInicial,FechaFinal);
        }
        public List<CELDesconexiones> ConsultaLogAdministradorCierreExperiencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ConsultaLogAdministradorCierreExperiencia(FechaInicial, FechaFinal);
        }
        public CEPDesconexiones TraeDesconexionPorId(decimal IdGestion)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.TraeDesconexionPorId(IdGestion);
        }
        public CEPAsigDesconexiones ApartarCuentadeDesconexiones(decimal Cedula, int noRecursividad)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ApartarCuentadeDesconexiones(Cedula,noRecursividad);
        }
        public List<CEMArbolesDeGestion> ListasDeArbolesCierreExperienciaAdmin(decimal IdPadre)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListasDeArbolesCierreExperienciaAdmin(IdPadre);
        }
        public List<CELDesconexiones> ConsultaDeGestionDesconexionesAgente(DateTime FechaInicial, DateTime FechaFinal, decimal Usuario)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ConsultaDeGestionDesconexionesAgente(FechaInicial,FechaFinal,Usuario);
        }
        public CEPAsigDesconexiones ValidarCuentaAsignada(decimal Cedula, int noRecursividad, decimal CuentaCliente)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ValidarCuentaAsignada(Cedula, noRecursividad, CuentaCliente);
        }
        public CEPDesconexiones ConsultarCuentaDesconexionporCuenta(decimal Cuenta)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ConsultarCuentaDesconexionporCuenta(Cuenta);
        }
        //proceso tickets
        public void RegistrarTicketBase(CEPTickets Ticket)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            CierreExpBusiness.RegistrarTicketBase(Ticket);
        }
        public void ActualizarTicket(CEPTickets Ticket)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            CierreExpBusiness.ActualizarTicket(Ticket);
        }
        public CEPTickets ConsultaDeTicketPorNumero(decimal IdGestion)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ConsultaDeTicketPorNumero(IdGestion);
        }
        public List<CELTickets> ConsultaDeGestionTicketsAgente(DateTime FechaInicial, DateTime FechaFinal, decimal Usuario)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ConsultaDeGestionTicketsAgente(FechaInicial,FechaFinal,Usuario);
        }
        public List<CELTickets> ListaDeGestionAgenteTicketsCierreExperiencia(decimal Usuario)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaDeGestionAgenteTicketsCierreExperiencia(Usuario);
        }
        public List<CEPTickets> ListaSeguimientosAgenteTicketCierreExperiencia(decimal Usuario)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaSeguimientosAgenteTicketCierreExperiencia(Usuario);
        }
        public List<MaestroMarcacione> ListaSrcaus()
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaSrcaus();
        }
        public List<MaestroMarcacione> ListaSrreas(string Razon)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaSrreas(Razon);
        }
        public List<MaestroMarcacione> ListaMarcacionesTickets()
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaMarcacionesTickets();
        }
        public CEPTickets ConsultaDeTicketPorTicket(decimal Ticket)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ConsultaDeTicketPorTicket(Ticket);
        }
        //proceso suspensiones temporales
        public void RegistrarSuspencion(CEPSuspensiones Suspencion, decimal IdAsignacion)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            CierreExpBusiness.RegistrarSuspencion(Suspencion,IdAsignacion);
        }
        public void ActualizarSuspencion(CEPSuspensiones Suspencion)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            CierreExpBusiness.ActualizarSuspencion(Suspencion);
        }
        public List<CELSuspensiones> ListaDeGestionAgenteSuspensiones(decimal Usuario)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaDeGestionAgenteSuspensiones(Usuario);
        }
        public List<CEPSuspensiones> ListaSeguimientosAgenteSuspensiones(decimal Usuario)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ListaSeguimientosAgenteSuspensiones(Usuario);
        }
        public CEPAsigSuspenciones ValidarCuentaAsigSuspension(decimal Cedula, decimal CuentaCliente)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ValidarCuentaAsigSuspension(Cedula,CuentaCliente);
        }
        public CEPAsigSuspenciones ApartarCuentadeSuspensiones(decimal Cedula, int noRecursividad)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.ApartarCuentadeSuspensiones(Cedula, noRecursividad);
        }
        public CEPAsigSuspenciones TraeRegistroAsignacionSuspensiones(decimal IdAsignacion)
        {
            CierreExperienciaBusiness CierreExpBusiness = new CierreExperienciaBusiness();
            return CierreExpBusiness.TraeRegistroAsignacionSuspensiones(IdAsignacion);
        }
    }
}
