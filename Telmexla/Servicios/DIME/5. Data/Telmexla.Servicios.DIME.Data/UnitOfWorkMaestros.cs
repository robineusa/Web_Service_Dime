using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class UnitOfWorkMaestros : IUnitOfWorkMaestros
    {

        private readonly MaestrosContext maestrosContext;

        public UnitOfWorkMaestros(MaestrosContext maestrosContext)
        {
            this.maestrosContext = maestrosContext;
             maestrosOutboundTipoContactos = new MaestroOutboundTipoContactoRepository(this.maestrosContext);
            maestrosOutboundCierres = new MaestroOutboundCierreRepository(this.maestrosContext);
            maestrosOutboundRazon = new MaestroOutboundRazonRepository(this.maestrosContext);
            maestrosOutboundCausa = new MaestroOutboundCausaRepository(this.maestrosContext);
            maestrosOutboundMotivo = new MaestroOutboundMotivoRepository(this.maestrosContext);
            maestrosLineasBlending = new MaestroLineasBlendingRepository(this.maestrosContext);
            maestroRecurrencia = new MaestroRecurrenciaRepository(this.maestrosContext);
            maestroOpcionesRecurrencia = new MaestroOpcionesRecurrenciaRepository(this.maestrosContext);
            maestroFallaEspecifica = new MaestroFallaEspecificaRepository(this.maestrosContext);
            maestroFallaCausaRaiz = new MaestroFallaCausaRaizRepository(this.maestrosContext);
        }

        public IMaestroOutboundTipoContactoRepository maestrosOutboundTipoContactos
        {
            get; private set;
        }
        public IMaestroOutboundCierreRepository maestrosOutboundCierres
        {
            get; private set;
        }
        public IMaestroOutboundRazonRepository maestrosOutboundRazon
        {
            get; private set;
        }
        public IMaestroOutboundCausaRepository maestrosOutboundCausa
        {
            get; private set;
        }
        public IMaestroOutboundMotivoRepository maestrosOutboundMotivo
        {
            get; private set;
        }
        public IMaestroLineasBlendingRepository maestrosLineasBlending
        {
            get; private set;
        }
        public IMaestroRecurrenciaRepository maestroRecurrencia
        {
            get; private set;
        }
        public IMaestroOpcionesRecurrenciaRepository maestroOpcionesRecurrencia
        {
            get; private set;
        }
        public IMaestroFallaEspecificaRepository maestroFallaEspecifica
        {
            get; private set;
        }
        public IMaestroFallaCausaRaizRepository maestroFallaCausaRaiz
        {
            get; private set;
        }
        
        
        public int Complete()
        {
            return this.maestrosContext.SaveChanges();
        }

        public void Dispose()
        {
            this.maestrosContext.Dispose();
        }
    }
}
