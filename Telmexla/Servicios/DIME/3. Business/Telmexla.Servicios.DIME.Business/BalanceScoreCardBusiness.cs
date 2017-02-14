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

    }
}
