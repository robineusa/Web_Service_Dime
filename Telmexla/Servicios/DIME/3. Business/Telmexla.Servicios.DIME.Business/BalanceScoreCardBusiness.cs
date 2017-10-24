using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class BalanceScoreCardBusiness
    {
        public BalanceScoreCard IndicadoresUsuario(decimal cedula)
        {
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            BalanceScoreCard result = new BalanceScoreCard();
            result = unitwork.balanceScoreCards.Find(c => c.Cedula == cedula).FirstOrDefault();
            return result;
        }
        public void RegistrarUmbralesBalanced(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario)
        {
            //registra indicadores tabla principal
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            unitwork.BSCAdministracionBalanced.Add(Umbrales);
            unitwork.Complete();
            unitwork.Dispose();

            //registra tabla log de indicadores
            UnitOfWork unitworkLog = new UnitOfWork(new DimeContext());
            BSCAdministracionBalancedLog Log = new BSCAdministracionBalancedLog();

            Log.Skill = Umbrales.Skill;
            Log.NombreSkill = Umbrales.NombreSkill;
            Log.Tmo = Umbrales.Tmo;
            Log.LlamadasAtendidas = Umbrales.LlamadasAtendidas;
            Log.Marcaciones = Umbrales.Marcaciones;
            Log.AjustesCorrectos = Umbrales.AjustesCorrectos;
            Log.PqrEscalados = Umbrales.PqrEscalados;
            Log.VolumenDeVentas = Umbrales.VolumenDeVentas;
            Log.Reincidencia = Umbrales.Reincidencia;
            Log.Recomendacion = Umbrales.Recomendacion;
            Log.NotaCalidad = Umbrales.NotaCalidad;
            Log.NotaBuenServicio = Umbrales.NotaBuenServicio;
            Log.ActivacionClaroVideo = Umbrales.ActivacionClaroVideo;
            Log.ActivacionConvenioElectronico = Umbrales.ActivacionConvenioElectronico;
            Log.TipoTransaccion = "CREACION";
            Log.FechaTransaccion = DateTime.Now;
            Log.UsuarioTransaccion = Usuario;
            Log.NombreUsuarioTransaccion = NombreUsuario;

            unitworkLog.BSCAdministracionBalancedLog.Add(Log);
            unitworkLog.Complete();
            unitworkLog.Dispose();

        }
        public void ActualizarUmbralesBalanced(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario)
        {
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            BSCAdministracionBalanced UmbralActualizable = unitwork.BSCAdministracionBalanced.Find(x => x.Skill == Umbrales.Skill).FirstOrDefault();
            //actualia la informacion
            UmbralActualizable.NombreSkill = Umbrales.NombreSkill;
            UmbralActualizable.Tmo = Umbrales.Tmo;
            UmbralActualizable.LlamadasAtendidas = Umbrales.LlamadasAtendidas;
            UmbralActualizable.Marcaciones = Umbrales.Marcaciones;
            UmbralActualizable.AjustesCorrectos = Umbrales.AjustesCorrectos;
            UmbralActualizable.PqrEscalados = Umbrales.PqrEscalados;
            UmbralActualizable.VolumenDeVentas = Umbrales.VolumenDeVentas;
            UmbralActualizable.Reincidencia = Umbrales.Reincidencia;
            UmbralActualizable.Recomendacion = Umbrales.Recomendacion;
            UmbralActualizable.NotaCalidad = Umbrales.NotaCalidad;
            UmbralActualizable.NotaBuenServicio = Umbrales.NotaBuenServicio;
            UmbralActualizable.ActivacionClaroVideo = Umbrales.ActivacionClaroVideo;
            UmbralActualizable.ActivacionConvenioElectronico = Umbrales.ActivacionConvenioElectronico;
            UmbralActualizable.UsoCCAA = Umbrales.UsoCCAA;

            unitwork.Complete();
            unitwork.Dispose();

            //registra tabla log de indicadores
            UnitOfWork unitworkLog = new UnitOfWork(new DimeContext());
            BSCAdministracionBalancedLog Log = new BSCAdministracionBalancedLog();

            Log.Skill = Umbrales.Skill;
            Log.NombreSkill = Umbrales.NombreSkill;
            Log.Tmo = Umbrales.Tmo;
            Log.LlamadasAtendidas = Umbrales.LlamadasAtendidas;
            Log.Marcaciones = Umbrales.Marcaciones;
            Log.AjustesCorrectos = Umbrales.AjustesCorrectos;
            Log.PqrEscalados = Umbrales.PqrEscalados;
            Log.VolumenDeVentas = Umbrales.VolumenDeVentas;
            Log.Reincidencia = Umbrales.Reincidencia;
            Log.Recomendacion = Umbrales.Recomendacion;
            Log.NotaCalidad = Umbrales.NotaCalidad;
            Log.NotaBuenServicio = Umbrales.NotaBuenServicio;
            Log.ActivacionClaroVideo = Umbrales.ActivacionClaroVideo;
            Log.ActivacionConvenioElectronico = Umbrales.ActivacionConvenioElectronico;
            Log.TipoTransaccion = "ACTUALIZACION";
            Log.FechaTransaccion = DateTime.Now;
            Log.UsuarioTransaccion = Usuario;
            Log.NombreUsuarioTransaccion = NombreUsuario;

            unitworkLog.BSCAdministracionBalancedLog.Add(Log);
            unitworkLog.Complete();
            unitworkLog.Dispose();

        }
        public void EliminaUmbral(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario)
        {
            decimal numeroSkill = Umbrales.Skill;
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BSCAdministracionBalanced RegistroEliminar = unitWork.BSCAdministracionBalanced.Find(c => c.Skill == numeroSkill).FirstOrDefault();

            if (RegistroEliminar != null)
            {
                unitWork.BSCAdministracionBalanced.Remove(RegistroEliminar);
                unitWork.Complete();
                unitWork.Dispose();
                //registra tabla log de indicadores
                UnitOfWork unitworkLog = new UnitOfWork(new DimeContext());
                BSCAdministracionBalancedLog Log = new BSCAdministracionBalancedLog();

                Log.Skill = Umbrales.Skill;
                Log.NombreSkill = Umbrales.NombreSkill;
                Log.Tmo = Umbrales.Tmo;
                Log.LlamadasAtendidas = Umbrales.LlamadasAtendidas;
                Log.Marcaciones = Umbrales.Marcaciones;
                Log.AjustesCorrectos = Umbrales.AjustesCorrectos;
                Log.PqrEscalados = Umbrales.PqrEscalados;
                Log.VolumenDeVentas = Umbrales.VolumenDeVentas;
                Log.Reincidencia = Umbrales.Reincidencia;
                Log.Recomendacion = Umbrales.Recomendacion;
                Log.NotaCalidad = Umbrales.NotaCalidad;
                Log.NotaBuenServicio = Umbrales.NotaBuenServicio;
                Log.ActivacionClaroVideo = Umbrales.ActivacionClaroVideo;
                Log.ActivacionConvenioElectronico = Umbrales.ActivacionConvenioElectronico;
                Log.TipoTransaccion = "ELIMINACION";
                Log.FechaTransaccion = DateTime.Now;
                Log.UsuarioTransaccion = Usuario;
                Log.NombreUsuarioTransaccion = NombreUsuario;

                unitworkLog.BSCAdministracionBalancedLog.Add(Log);
                unitworkLog.Complete();
                unitworkLog.Dispose();
            }
            else { }

            
        }
        public BSCAdministracionBalanced ConsultaUmbralPorSkill(decimal Skill)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            BSCAdministracionBalanced Umbral = UnitOfWork.BSCAdministracionBalanced.Find(x => x.Skill == Skill).FirstOrDefault();
            if (Umbral != null)
            {
                return Umbral;
            }
            else
            {
                return null;
            }
        }
        public List<BSCAdministracionBalanced> ListaDeUmbralesActuales()
        {
            DimeContext dimContext = new DimeContext();
            List<BSCAdministracionBalanced> result = new List<BSCAdministracionBalanced>();
            var objetosResult = (from a in dimContext.BSCAdministracionBalanced
                                 orderby a.Skill ascending
                                 select new
                                 {
                                     a.Skill,
                                     a.NombreSkill,
                                     a.Tmo,
                                     a.LlamadasAtendidas,
                                     a.Marcaciones,
                                     a.AjustesCorrectos,
                                     a.PqrEscalados,
                                     a.VolumenDeVentas,
                                     a.Reincidencia,
                                     a.Recomendacion,
                                     a.NotaCalidad,
                                     a.NotaBuenServicio,
                                     a.ActivacionClaroVideo,
                                     a.ActivacionConvenioElectronico,
                                     a.UsoCCAA
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BSCAdministracionBalanced());
                result[i].Skill = objetosResult[i].Skill;
                result[i].NombreSkill = objetosResult[i].NombreSkill;
                result[i].Tmo = objetosResult[i].Tmo;
                result[i].LlamadasAtendidas = objetosResult[i].LlamadasAtendidas;
                result[i].Marcaciones = objetosResult[i].Marcaciones; 
                result[i].AjustesCorrectos = objetosResult[i].AjustesCorrectos;
                result[i].PqrEscalados = objetosResult[i].PqrEscalados;
                result[i].VolumenDeVentas = objetosResult[i].VolumenDeVentas;
                result[i].Reincidencia = objetosResult[i].Reincidencia;
                result[i].Recomendacion = objetosResult[i].Recomendacion;
                result[i].NotaCalidad = objetosResult[i].NotaCalidad;
                result[i].NotaBuenServicio = objetosResult[i].NotaBuenServicio;
                result[i].ActivacionClaroVideo = objetosResult[i].ActivacionClaroVideo;
                result[i].ActivacionConvenioElectronico = objetosResult[i].ActivacionConvenioElectronico;
                result[i].UsoCCAA = objetosResult[i].UsoCCAA;

            }
            return result;
        }
    }
}
