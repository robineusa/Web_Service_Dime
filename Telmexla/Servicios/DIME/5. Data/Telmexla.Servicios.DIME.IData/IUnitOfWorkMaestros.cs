using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.IData
{
    public interface IUnitOfWorkMaestros : IDisposable
    {
        IMaestroOutboundTipoContactoRepository maestrosOutboundTipoContactos { get; }
        IMaestroOutboundCierreRepository maestrosOutboundCierres { get; }
        IMaestroOutboundRazonRepository maestrosOutboundRazon {get;}
        IMaestroOutboundCausaRepository maestrosOutboundCausa { get; }
        IMaestroOutboundMotivoRepository maestrosOutboundMotivo { get; }
        int Complete();
    }
}
