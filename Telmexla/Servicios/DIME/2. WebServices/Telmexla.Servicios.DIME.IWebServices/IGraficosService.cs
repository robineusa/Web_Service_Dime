﻿using System;
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
    public interface IGraficosService
    {
        [OperationContract]
        List<Graficos> GraficoTrasladosGeneralAsesor(string UsuarioOut);
        [OperationContract]
        List<Graficos> GraficoAsesorIngresosSac(string UsuarioOut);
        [OperationContract]
        List<Graficos> GraficoAsesorNotasIngresosSac(string UsuarioOut);
    }
}