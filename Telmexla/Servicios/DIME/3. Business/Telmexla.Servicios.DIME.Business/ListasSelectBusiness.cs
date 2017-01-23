using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;

namespace Telmexla.Servicios.DIME.Business
{
    public class ListasSelectBusiness
    {
        
        public List<string> ListaDeAliadosHolos()
        {
           DimeContext dimContext = new DimeContext();
           return  dimContext.BasePersonalHoloes.Select(x => x.Aliado).Distinct().ToList();

        }
    }
}
