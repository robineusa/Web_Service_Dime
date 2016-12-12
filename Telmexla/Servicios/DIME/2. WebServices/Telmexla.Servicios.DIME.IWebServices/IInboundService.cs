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
    public interface IInboundService
    {
        [OperationContract]
        bool RegistrarActualizarDatosAdicionalesCliente(DatosAdicionalesCliente datosAdicionalesCliente);

        [OperationContract]
        ClientesTodo TraerClienteCompletoPorCuenta(int cuenta);

        [OperationContract]
        DatosAdicionalesCliente TraerDatosAdicionalesCliente(int cuenta);

        [OperationContract]
        List<ClientesTodo> ConsultarCuentasPorcedula(string cedula);

        [OperationContract]
        List<string> ConsultarHobbiesOptions();


        [OperationContract]
        void RegistrarIngresoInbound(ClientesTodo infoCliente, Ingreso ingreso, string observacion);

    }
}
