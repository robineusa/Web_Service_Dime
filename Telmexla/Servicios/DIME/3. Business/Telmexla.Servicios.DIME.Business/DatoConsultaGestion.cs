using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class DatoConsultaGestion
    {
        private Ingreso ingreso;
        private NotasIngreso notaIngreso;


        public DatoConsultaGestion()
        {
            ingreso = new Ingreso();
            notaIngreso = new NotasIngreso();
        }

        public Ingreso Ingreso
        {
            get
            {
                return ingreso;
            }

            set
            {
                ingreso = value;
            }
        }

        public NotasIngreso NotaIngreso
        {
            get
            {
                return notaIngreso;
            }

            set
            {
                notaIngreso = value;
            }
        }
    }
}
