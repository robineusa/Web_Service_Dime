using System;
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
        int Complete();
    }
}