﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class DistribucionBlendingRepository: Repository<DistribucionBlending>, IDistribucionBlendingRepository
    {
        public DistribucionBlendingRepository(DimeContext context) : base(context)
        {

        }

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }

        public bool ApartarCuentaAGestionarBlendingAsesor(int idAsesor, string formulario, string aliado, string operacion, string campana)
        {

            dimeContext.ApartarCuentaGestionOutbound(idAsesor, formulario, aliado, operacion, campana);
            return true;
        }
    }
}