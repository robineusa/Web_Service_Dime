using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class ConsultaReporteBlending
    {
        private DistribucionBlending distribucionBlending;
        private int Cantidad;
        
        public ConsultaReporteBlending()
        {
            distribucionBlending = new DistribucionBlending();
        }
        public DistribucionBlending DistribucionBlending
        {
            get
            {
                return distribucionBlending;
            }

            set
            {
                distribucionBlending = value;
            }
        }
    }
}
