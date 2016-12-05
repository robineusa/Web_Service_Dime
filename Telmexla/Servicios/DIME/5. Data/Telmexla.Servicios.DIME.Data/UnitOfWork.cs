﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DimeContext dimeContext;

        public UnitOfWork(DimeContext dimeContext)
        {
            this.dimeContext = dimeContext;
            accesos = new AccesoRepository(this.dimeContext);
            clientesTodo = new ClientesTodoRepository(this.dimeContext);
            gestionesOutbound = new GestionOutboundRepository(this.dimeContext);
            conveniosElectronicos = new ConvenioElectronicoRepository(this.dimeContext);
            docsisOverlaps =  new DocsisOverlapRepository(this.dimeContext);
            usuarios = new UsuarioRepository(this.dimeContext);
            claroVideos = new ClaroVideoRepository(this.dimeContext);
            cierreCiclos = new CierreCicloRepository(this.dimeContext);
            maestroMarcaciones = new MaestroMarcacioneRepository(this.dimeContext);
            notificacionesBuenServicio = new NotificacionesBuenServicioRepository(this.dimeContext);
        }
           

        public IAccesoRepository accesos
        {
            get; private set;
        }

        public IClientesTodoRespository clientesTodo
        {
            get; private set;
        }
        public IGestionOutboundRepository gestionesOutbound
        {
            get; private set;
        }

        public IConvenioElectronicoRepository conveniosElectronicos
        {
            get; private set;
        }

        public IDocsisOverlapRepository docsisOverlaps
        {
            get; private set;
        }

        public IUsuarioRepository usuarios
        {
            get; private set;
        }
        public IClaroVideoRepository claroVideos
        {
            get; private set;
        }
        public ICierreCicloRepository cierreCiclos
        {
            get; private set;
        }
        public IMaestroMarcacioneRepository maestroMarcaciones
        {
            get; private set;
        }
        public INotificacionesBuenServicioRepository notificacionesBuenServicio
        {
            get; private set;
        }
        public int Complete()
        {
            return this.dimeContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dimeContext.Dispose();
        }
    }
}