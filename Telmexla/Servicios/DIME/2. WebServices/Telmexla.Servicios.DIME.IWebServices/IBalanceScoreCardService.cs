using System;
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
    public interface IBalanceScoreCardService
    {
        [OperationContract]
        BalanceScoreCard IndicadoresUsuario(decimal cedula);
        [OperationContract]
        void RegistrarUmbralesBalanced(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario);
        [OperationContract]
        void ActualizarUmbralesBalanced(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario);
        [OperationContract]
        void EliminaUmbral(BSCAdministracionBalanced Umbrales, decimal Usuario, string NombreUsuario);
        [OperationContract]
        BSCAdministracionBalanced ConsultaUmbralPorSkill(decimal Skill);
    }
}
