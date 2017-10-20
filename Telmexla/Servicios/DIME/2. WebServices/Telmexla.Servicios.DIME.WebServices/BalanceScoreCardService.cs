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
    public class BalanceScoreCardService : IBalanceScoreCardService
    {
        public BalanceScoreCard IndicadoresUsuario(decimal cedula)
        {
            BalanceScoreCardBusiness balancebusi = new BalanceScoreCardBusiness();
            return balancebusi.IndicadoresUsuario(cedula);
        }
        public void RegistrarUmbralesBalanced(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario)
        {
            BalanceScoreCardBusiness balancebusi = new BalanceScoreCardBusiness();
            balancebusi.RegistrarUmbralesBalanced(Umbrales,Usuario,NombreUsuario);
        }
        public void ActualizarUmbralesBalanced(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario)
        {
            BalanceScoreCardBusiness balancebusi = new BalanceScoreCardBusiness();
            balancebusi.ActualizarUmbralesBalanced(Umbrales, Usuario, NombreUsuario);
        }
        public void EliminaUmbral(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario)
        {
            BalanceScoreCardBusiness balancebusi = new BalanceScoreCardBusiness();
            balancebusi.EliminaUmbral(Umbrales, Usuario, NombreUsuario);
        }
        public BSCAdministracionBalanced ConsultaUmbralPorSkill(decimal Skill)
        {
            BalanceScoreCardBusiness balancebusi = new BalanceScoreCardBusiness();
           return  balancebusi.ConsultaUmbralPorSkill(Skill);
        }
        public List<BSCAdministracionBalanced> ListaDeUmbralesActuales()
        {
            BalanceScoreCardBusiness balancebusi = new BalanceScoreCardBusiness();
            return balancebusi.ListaDeUmbralesActuales();
        }
    }
}
