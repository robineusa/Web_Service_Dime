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
    public class MaestroOutboundMotivoRepository : Repository<MaestroOutboundMotivo>, IMaestroOutboundMotivoRepository
    {
        public MaestroOutboundMotivoRepository(MaestrosContext context) : base(context)
        {


        }

        public MaestrosContext maestrosContext
        {
            get { return Context as MaestrosContext; }
        }



    }
}
