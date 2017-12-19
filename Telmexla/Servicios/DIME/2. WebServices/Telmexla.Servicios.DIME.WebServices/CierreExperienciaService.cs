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
    }
}
