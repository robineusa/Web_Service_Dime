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
    public interface ICierreCicloService
    {
        [OperationContract]
        List<DatoConsultaCCResidencialPredictivo> ListaResidencialPredictivoDeCuenta(float cuenta);

        [OperationContract]
        CcResidencialPredictivoInfo GetResidencialPredictivoInfoPorId(int id);


        [OperationContract]
        CcBaseMejoramiento RecibirBaseMejoramientoDeResdPredInfo(double cuenta, string problemaEdAMotivo);

        [OperationContract]
        long IngresarGestionResidencialPredictivo(CcGestionResidencialPredictivo gestionResdPred);

        [OperationContract]
        void IngresarSegundaTipificacion(CcSegundaTipificacion segundaTipifi);

    }
}
