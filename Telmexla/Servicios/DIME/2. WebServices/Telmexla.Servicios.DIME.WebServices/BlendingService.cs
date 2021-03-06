﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class BlendingService : IBlendingService
    {


       public ClientesTodo TraerMisDatosClienteAutomaticos(int idAsesor, string gestionBlendingActual, string aliado, string linea)
        {
            OutboundBusiness outboundBusiness = new OutboundBusiness();
            return outboundBusiness.DatosClienteAutomaticos(idAsesor, gestionBlendingActual,0, aliado, linea);
        }


        public ConvenioElectronicoCollection TraerHistorialConvenioElectroDeAsesor(int idAsesor)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.getHistorialConvenioElectroDeAsesor(idAsesor);

        }

        public bool GuardarGestionConvenioElectronico(int idAsesor, ClientesTodo datosCliente, ConvenioElectronico convElectGestionado)
        {

         BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.ProcesoGuardarGestionConvenioElectro(idAsesor,datosCliente,convElectGestionado);

        }

        public ConvenioElectronico TraerConvenioElectronicoGestionado(int idGestionado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetConvenioElectronicoPorId(idGestionado);
        }

        public ConvenioElectronicoCollection ListaConveniosElectronicosGestionados(DateTime fInicial, DateTime fFinal)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.ConveniosElectronicosGestionados(fInicial, fFinal);

        }

        public DocsisOverlapCollection TraerHistorialDocsisDeAsesor(int idAsesor)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.getHistorialDocsisDeAsesor(idAsesor);
        }


        public DocsisOverlap TraerDocsisGestionado(int idGestionado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.getDocsisLineGestionado(idGestionado);
        }


        public bool GuardarGestionDocsis(int idAsesor, ClientesTodo datosCliente, DocsisOverlap docsisGestionado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.ProcesoGuardarGestionDocsis(idAsesor, datosCliente, docsisGestionado);

        }

        public LogDocsisOverlapCollection ListaDocsisOverlapGestionados(DateTime fInicial, DateTime fFinal)
        {
            BlendingBusiness blendingBusine = new BlendingBusiness();
            return blendingBusine.IteracionesDocsisOverlapsGestionados(fInicial, fFinal);
         }


        public ClaroVideoCollection TraerHistorialClaroVideoDeAsesor(int idAsesor)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetHistorialClaroVideoAsesor(idAsesor);
        }

        public ClaroVideo TraerClaroVideoGestionado(int idGestionado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetClaroVideoGestionado(idGestionado);
        }

        public bool GuardarGestionClaroVideo(int idAsesor, ClientesTodo datosCliente, ClaroVideo claroVideoGestionado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.ProcesoGuardarClaroVideo(idAsesor,datosCliente,claroVideoGestionado);
        }
        public  LogClaroVideoCollection ListaClaroVideosGestionados(DateTime fInicial, DateTime fFinal)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.IteracionesGestionesClaroVideo(fInicial, fFinal);
        }

        public CierreCicloCollection TraerHistorialCierreCicloDeAsesor(int idAsesor)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetHistorialCierreCicloAsesor(idAsesor);
        }

        public List<String> TraerNombresDeClientesCierreCiclo(CierreCicloCollection cuentasATraer)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetNombresClientesCierreCiclo(cuentasATraer);
        }

       public   LogCierreCicloCollection ListaCierresCicloGestionados(DateTime fInicial, DateTime fFinal)
        {
            BlendingBusiness blendingBusiness = new BlendingBusiness();
            return blendingBusiness.IteracionesGestionesCierreCiclo(fInicial, fFinal);
        }


        public GestionOutbound TraerGestionOutboundInfoDeCuenta(int idAsesor, string gestion, string aliado, string linea)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetGestionOutboundPorAsesor(idAsesor, gestion, aliado, linea);
        }
        public CierreCiclo TraerCierreCicloGestionado(int idGestionado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetCierreCicloGestionado(idGestionado);
        }

        public bool GuardarCierreCiclo(int idAsesor, ClientesTodo datosCliente, CierreCiclo cierreCicloGestionado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.ProcesoGuardarCierreCiclo(idAsesor, datosCliente, cierreCicloGestionado);
        }
        public SkillsUsuariosBlendingCollection ListaUsuariosAdminBlending(string Operacion)
        {
            BlendingBusiness blendingBusiness = new BlendingBusiness();
            return blendingBusiness.ListaUsuariosAdminBlending(Operacion);
        }
        public SkillsUsuariosBlending ConsultaUsuarioenAdminBlending(string cedula)
        {
            BlendingBusiness blendingBusiness = new BlendingBusiness();
            return blendingBusiness.ConsultaUsuarioenAdminBlending(cedula);
        }
        public List<DistribucionBlending> ObtenerCampaña(string Aliado, string Formulario, string Operacion)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.ObtenerCampaña(Aliado, Formulario, Operacion);
        }
        public void InsertarSkillsUsuarioBlending(SkillsUsuariosBlending skills)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            blendingBusin.InsertarSkillsUsuarioBlending(skills);
        }
        public List<DistribucionBlending> CountCuentasOperacionGestion(string aliado, string formulario, string operacion)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.CountCuentasOperacionGestion(aliado, formulario, operacion);
        }
        public List<DistribucionBlending> CountCuentasOperacionCampaña(string aliado, string formulario, string operacion, string campaña)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.CountCuentasOperacionCampaña(aliado, formulario, operacion, campaña);
        }
        public void ActualizarUsuariosBasesBlending(List<string> listaUsuariosCambiados, string Campaña, int Id_Usuario_Actualizacion)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            blendingBusin.ActualizarUsuariosBasesBlending(listaUsuariosCambiados, Campaña, Id_Usuario_Actualizacion);
        }
        public List<DistribucionBlending> GetOperacionBlending(string Aliado, string Formulario)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetOperacionBlending(Aliado, Formulario);
        }
        public List<DistribucionBlending> GetFormulariosBlending(string Aliado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetFormulariosBlending(Aliado);
        }
        public void ActualizarUsuarioBlending(SkillsUsuariosBlending m)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            blendingBusin.ActualizarUsuarioBlending(m);
        }
        public void EliminaUsuarioSkilles(int Cedula)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            blendingBusin.EliminaUsuarioSkilles(Cedula);
        }
    }
}
