﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class DatoConsultaDirecciones
    {
        private IngresoTraslado ingresoTraslado;
        private NotasTraslado notaTraslado;
        private MaestroNodo maestroNodo;
        private CambioEstrato cambioEstrato;

        public DatoConsultaDirecciones()
        {
            ingresoTraslado = new IngresoTraslado();
            notaTraslado = new NotasTraslado();
            maestroNodo = new MaestroNodo();
            CambioEstrato = new CambioEstrato();
        }

        public IngresoTraslado IngresoTrasladoGetSet
        {
            get
            {
                return ingresoTraslado;
            }

            set
            {
                ingresoTraslado = value;
            }
        }

        public NotasTraslado NotaTrasladoGetSet
        {
            get
            {
                return notaTraslado;
            }

            set
            {
                notaTraslado = value;
            }
        }

        public MaestroNodo MaestroNodo
        {
            get
            {
                return maestroNodo;
            }

            set
            {
                maestroNodo = value;
            }
        }

        public CambioEstrato CambioEstrato
        {
            get
            {
                return cambioEstrato;
            }

            set
            {
                cambioEstrato = value;
            }
        }
    }
}
