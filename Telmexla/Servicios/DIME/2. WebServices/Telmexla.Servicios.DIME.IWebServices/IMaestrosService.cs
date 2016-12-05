﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{

    [ServiceContract]
    public interface IMaestrosService
    {


        [OperationContract]
        MaestroOutboundTipoContactoCollection ObtenerTiposDeContactoDeGestion(decimal gestionId);

        [OperationContract]
        MaestroOutboundCierreCollection ObtenerTiposDeCierresDeContacto(decimal contactoId);

        [OperationContract]
        MaestroOutboundRazonCollection ObtenerTiposDeRazonDeCierres(decimal cierreId);


        [OperationContract]
        MaestroOutboundCausaCollection ObtenerTiposDeCausasDeRazon(decimal razonId);

        [OperationContract]
        MaestroOutboundMotivoCollection ObtenerTiposDeMotivoDeCausas(decimal causaId);


    

    }
}