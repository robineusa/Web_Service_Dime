﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.IData
{
    public interface IUnitOfWork : IDisposable
    {
        IAccesoRepository accesos { get; }
        IClientesTodoRespository clientesTodo { get; }
        IGestionOutboundRepository gestionesOutbound { get; }
        IConvenioElectronicoRepository conveniosElectronicos { get; }
        IDocsisOverlapRepository docsisOverlaps { get; }
        IUsuarioRepository usuarios { get; }
        IClaroVideoRepository claroVideos { get; }
        ICierreCicloRepository cierreCiclos { get; }
        IMaestroMarcacioneRepository maestroMarcaciones { get; }
        INotificacionesBuenServicioRepository notificacionesBuenServicio { get; }
        ILogConvenioElectronicoRepository logConveniosElectronicos { get; }
        ILogDocsisOverlapRepository logDocsisOverlaps { get; }
        ILogClaroVideoRepository logClaroVideos { get; }
        ILogCierreCicloRepository logCierreCiclos { get; }
        IIngresoRepository ingresos { get; }
        INotasIngresoRepository notasIngresos { get; }
        IPqrMaestroCodCierreRepository pqrMaestroCodigos { get; }
        IRechazoRepository rechazos { get; }
        IIngresoTrasladoRepository ingresoTraslados { get; }
        INotasTrasladoRepository notasTraslados { get; }
        IMaestroNodoRepository maestroNodos { get; }
        IActivacionClaroVideoRepository activacionClaroVideo { get; }
        ICuentasSiembraHDRepository CuentasSiembraHD { get; }
        ISiembraHDRepository ActivacionSiembraHD { get; }
        ICambioEstratoRepository cambioEstratos { get; }
        ITraficoTrasladoRepository traficoTraslados { get; }
        ILiberacionHomePassRepository liberacionesHomePass { get; }
        IGestionMatrizRepository gestionMatrices { get; }
        IIngresoSoporteRepository ingresosSoporte { get; }
        IUsuariosNotificadosRepository usuariosNotificados { get; }
        IBalanceScoreCardRepository balanceScoreCards { get; }
        ICuentasSiguienteMejorOfertaRepository CuentaSMO { get; }
        ISiguienteMejorOfertaRepository SMO { get; }
        ITrasladoFallidoRepository trasladosFallidos { get; }
        IUsabilidadConvenoInboundRepository UsabilidadConvenoInbound { get; }
        IDepartamentoRepository Departamentos { get; }
        IUsabilidadBusquedaCuentaInboundRepositiry UsabilidadCuentaInbound { get; }
        ISkillsUsuariosBlendingRepository SkillsUsuariosBlending { get; }
        IBlendingFueraNivelRepository blendingFueraNiveles { get; }
        IDistribucionBlendingRepository distribucionesBlending { get; }
        IGBPFueraNivelesRepository GBPFueradeNiveles { get; }
        IGBLFueraNivelesRepository GBLFueradeNiveles { get; }
        IGBPRentabilizacionRepository GBPRentabilizacion { get; }
        IGBLRentabilizacionRepository GBLRentabilizacion { get; }
        IGBCRentabilizacionRepository GBCRentabilizacion { get; }
        ICuentasMejorasTecnicasRepository CuentasMejorasTecnicas { get; }
        IMejorasTecnicasRepository MejorasTecnicas { get; }
        IGBPProductoRepository GBPProducto { get; }
        IGBLProductoRepository GBLProducto { get; }
        IGBCProductoRepository GBCProducto { get; }
        IGBPDocsisRepository GBPDocsis { get; }
        IGBLDocsisRepository GBLDocsis { get; }
        IGBCDocsisRepository GBCDocsis { get; }
        IRetencionRepository Retencion { get; }
        IMultiplayCargueRepository MultiplayCargue { get; }
        IMultiPlayRegistroRepository MultiPlayRegistro { get; }
        IMecMonitoreosPRepository MecMonitoreosP { get; }
        IMecMonitoreosLRepository MecMonitoreosL { get; }
        IMecProcesosRepository MecProcesos { get; }
        IMecLineasRepository MecLineas { get; }
        IMecListasDistribucionRepository MecListasDistribucion { get; }
        IMecTipoAlarmasRepository MecTipoAlarmas { get; }
        ICargueBaseFoxInboundRepository CargaBaseFoxInbound { get; }
        IGestionFoxInboundRepository GestionFoxInbound { get; }
        IBELSolicitudesRepository BELSolicitudes { get; }
        IBEMDetalleDeGestionRepository BEMDetalleDeGestion { get; }
        IBEMDetalleEscalamientosRepository BEMDetalleEscalamientos { get; }
        IBEMDistribucionesRepository BEMDistribuciones { get; }
        IBEMRazonMalEscalamientoRepository BEMRazonMalEscalamiento { get; }
        IBEMTipoDeEscalamientosRepository BEMTipoDeEscalamientos { get; }
        IBEPSolicitudesRepository BEPSolicitudes { get; }
        INodosZonificadosRepository NodosZonificados { get; }
        ICcGestionResidencialPredictivoRepository CcGestionResidencialPredictivo { get; }
        ICcSegundaTipificacionRepository CcSegundaTipificacion { get; }
        IRecurrenciaCargaBaseRepository RecurrenciaCargaBase { get; }
        IGPrincipalRecurrenciaRepository GPrincipalRecurrencia { get; }
        IGLogRecurrenciaRepository GLogRecurrencia { get; }
        IBIPBitacoraIncidentesRepository BIPBitacoraIncidentes { get; }
        IBILBitacoraIncidentesRepository BILBitacoraIncidentes { get; }
        IBIMGerenciasRepository BIMGerencias { get; }
        IBIMAliadosRepository BIMAliados { get; }
        IBIMOperacionesRepository BIMOperaciones { get; }
        IBIPIncidentesPorOperacionRepository BIPIncidentesPorOperacion { get; }
        IBIMTipoFallaRepository BIMTipoFalla { get; }
        IBIMPrioridadesRepository BIMPrioridades { get; }
        IBIMHerramientasRepository BIMHerramientas { get; }
        IAccesosXLineaRepository AccesosXLinea { get; }
        int Complete();
    }
}