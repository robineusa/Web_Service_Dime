using System;
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
    public interface IRecurrenciaService
    {
        [OperationContract]
        ClientesTodo TraerInformacionCuentaRecurrencia(int idAsesor);

        [OperationContract]
        RecurrenciaCargaBase TraerDatosRecurrencia(int idAsesor, int CuentaCliente);

        [OperationContract]
        List<MaestroOpcionesRecurrencia> GetOpcionesRecurrencia(int idProceso);

        [OperationContract]
        List<MaestroFallaEspecifica> GetFallaEspecifica(int idOpcionesRecurrencia);

        [OperationContract]
        List<MaestroFallaCausaRaiz> GetFallaCausaRaiz(int idFallaEspecifica);

        [OperationContract]
        void EliminaCuentaRecurrencia(decimal Cuenta);

        [OperationContract]
        void InsertarGRecurrencia(GPrincipalRecurrencia recurrencia);

        [OperationContract]
        void ActualizarGRecurrencia(GPrincipalRecurrencia recurrencia);

        [OperationContract]
        GPrincipalRecurrencia TraerGPrinRecurrencia(int CuentaCliente);

        [OperationContract]
        List<GPrincipalRecurrencia> ListaSeguimientosRecurrencia();

        [OperationContract]
        void UsuarioGestionandoGRecurrencia(int idUsuario, int idCaso);

        [OperationContract]
        List<GPrincipalRecurrencia> ConsultaAdminGPrincipalRecurrencia(DateTime FechaInicial, DateTime FechaFinal);

        [OperationContract]
        List<GLogRecurrencia> ConsultaAdminGLogRecurrencia(DateTime FechaInicial, DateTime FechaFinal);


    }
}
