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
    public interface IBlendingService
    {
        [OperationContract]
        ClientesTodo TraerMisDatosClienteAutomaticos(int idAsesor, string gestionBlendingActual);

        [OperationContract]
        ConvenioElectronicoCollection TraerHistorialConvenioElectroDeAsesor(int idAsesor);


        [OperationContract]
        bool GuardarGestionConvenioElectronico(int idAsesor, ClientesTodo datosCliente, ConvenioElectronico convElectGestionado );

        [OperationContract]
        ConvenioElectronico TraerConvenioElectronicoGestionado(int idGestionado);

        [OperationContract]
        DocsisOverlapCollection TraerHistorialDocsisDeAsesor(int idAsesor);

        [OperationContract]
        DocsisOverlap TraerDocsisGestionado(int idGestionado);

        [OperationContract]
        bool GuardarGestionDocsis(int idAsesor, ClientesTodo datosCliente, DocsisOverlap docsisGestionado);

        [OperationContract]
        ClaroVideoCollection TraerHistorialClaroVideoDeAsesor(int idAsesor);

        [OperationContract]
        ClaroVideo TraerClaroVideoGestionado(int idGestionado);

        [OperationContract]
        bool GuardarGestionClaroVideo(int idAsesor, ClientesTodo datosCliente, ClaroVideo claroVideoGestionado);

        [OperationContract]
        CierreCicloCollection TraerHistorialCierreCicloDeAsesor(int idAsesor);
        [OperationContract]
        List<String> TraerNombresDeClientesCierreCiclo(CierreCicloCollection cuentasATraer);

        [OperationContract]
        GestionOutbound TraerGestionOutboundInfoDeCuenta(int cuenta, string gestion);

        [OperationContract]
        CierreCiclo TraerCierreCicloGestionado(int idGestionado);

        [OperationContract]
        bool GuardarCierreCiclo(int idAsesor, ClientesTodo datosCliente, CierreCiclo cierreCicloGestionado);

    }
}
