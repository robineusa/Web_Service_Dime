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
        int Complete();
    }
}