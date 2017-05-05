﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IData
{
    public interface IDistribucionBlendingRepository: IRepository<DistribucionBlending>
    {
        bool ApartarCuentaAGestionarBlendingAsesor(int idAsesor, string formulario, string aliado, string operacion, string campana);
    }
}
