﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class NotificacionesBuenServicioBusiness
    {
        public void Registrarnotificado(NotificacionesBuenServicio notificacion) {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            unitOfWork.notificacionesBuenServicio.Add(notificacion);
            unitOfWork.Complete();
        }

    }
}