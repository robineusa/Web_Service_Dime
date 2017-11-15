using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IBannerAlertasService
    {
        [OperationContract]
        bool ValidarClienteEnConvenioElectronico(decimal CuentaCliente);
        [OperationContract]
        bool ValidarClienteEnClaroVideo(decimal CuentaCliente);
        [OperationContract]
        bool ValidarClienteEnMejorOferta(decimal CuentaCliente);
        [OperationContract]
        bool ValidarClienteEnSiembraHD(decimal CuentaCliente);
        [OperationContract]
        bool ValidarClienteEnMejorasTecnicas(decimal CuentaCliente);
        [OperationContract]
        bool ValidarClienteEnFox(decimal CuentaCliente);
        [OperationContract]
        CuentasSiguienteMejorOferta ConsultarClienteMejorOferta(decimal CuentaCliente);
        [OperationContract]
        void RegistrarSMO(SiguienteMejorOferta smo);
        [OperationContract]
        void RegistrarClaroVideo(ActivacionClaroVideo ClaroVideo);
        [OperationContract]
        CuentasSiembraHD ConsultarCuentaSiembraHD(decimal CuentaCliente);
        [OperationContract]
        void RegistrarSiembraHD(SiembraHD siembra);
        [OperationContract]
        CuentasMejorasTecnicas ConsultarCuentaMejorasTecnicas(decimal CuentaCliente);
        [OperationContract]
        void RegistrarMejorasTecnicas(MejorasTecnicas Mejoras);
        [OperationContract]
        CargaBaseFoxInbound ConsultaCuentaBaseFox(decimal CuentaCliente);
        [OperationContract]
        void RegistraFox(GestionFoxInbound Fox);
    }
}
