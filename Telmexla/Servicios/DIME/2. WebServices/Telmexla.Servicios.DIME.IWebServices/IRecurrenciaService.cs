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

        [OperationContract]
        List<GLogRecurrencia> ListaHistorialSeguimientosRecurrencia(decimal CuentaCliente);

        [OperationContract]
        void InsertarGRecurrenciaInbound(GPrincipalRecurrenciaInbound recurrenciainbound);

        [OperationContract]
        void ActualizarGRecurrenciaInbound(GPrincipalRecurrenciaInbound recurrenciainbound);

        [OperationContract]
        GPrincipalRecurrenciaInbound TraerGPrinRecurrenciaInbound(int CuentaCliente);

        [OperationContract]
        List<GPrincipalRecurrenciaInbound> ListaSeguimientosRecurrenciaInbound();

        [OperationContract]
        List<GLogRecurrenciaInbound> ListaHistSeguiRecurrenciaInbound(decimal CuentaCliente);

        [OperationContract]
        NodosZonificados AliadoTecnico(string Nodo);

        [OperationContract]
        List<InventarioEquipos> InventarioEquiposCuenta(decimal CuentaCliente);

        [OperationContract]
        List<GPrincipalRecurrenciaInbound> ConsultaAdminPrincipalRecurrenciaInbound(DateTime FechaInicial, DateTime FechaFinal);

        [OperationContract]
        List<GLogRecurrenciaInbound> ConsultaAdminLogRecurrenciaInbound(DateTime FechaInicial, DateTime FechaFinal);

        [OperationContract]
        RecurrenciaCargaBase TraerDatosRecurrenciaCarga(decimal CuentaCliente);

        [OperationContract]
        void ActualizarUusuarioGestionando(int Usuario, decimal Cuenta);

        [OperationContract]
        List<GPrincipalRecurrencia> CuentaGprincipalRecurrencia(int CuentaCliente);

        [OperationContract]
        List<GLogRecurrencia> ListaMiHistorialRecurrencia(string usuarioGestion);

        [OperationContract]
        GPrincipalRecurrencia TraerGPrinRecurrenciaid(int CuentaCliente, int id);

    }
}
