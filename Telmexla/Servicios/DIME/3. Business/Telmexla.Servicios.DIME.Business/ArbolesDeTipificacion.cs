using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.IData;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class ArbolesDeTipificacion
    {

        public MaestroOutboundTipoContactoCollection GetTipoContactosPorGestion(decimal gestionId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            List<MaestroOutboundTipoContacto> tiposContacto = unitOfWork.maestrosOutboundTipoContactos.Find(c => c.IdTipoGestion == gestionId).ToList();
            MaestroOutboundTipoContactoCollection result = new MaestroOutboundTipoContactoCollection();
            result.AddRange(tiposContacto);
            return result;
        }



        public MaestroOutboundCierreCollection GetTipoCierrePorContacto(decimal contactoId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            MaestroOutboundCierreCollection result = new MaestroOutboundCierreCollection();
            result.AddRange(unitOfWork.maestrosOutboundCierres.Find(c => c.IdTipoContacto == contactoId).ToList());
            return result;

        }




        public MaestroOutboundRazonCollection GetTipoRazonPorTipoCierre(decimal cierreId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            MaestroOutboundRazonCollection result = new MaestroOutboundRazonCollection();
            result.AddRange(unitOfWork.maestrosOutboundRazon.Find(c => c.IdCierre  == cierreId).ToList());
            return result;

        }



        public MaestroOutboundCausaCollection GetTipoCausanPorTipoRazon(decimal razonId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            MaestroOutboundCausaCollection result = new MaestroOutboundCausaCollection();
            result.AddRange(unitOfWork.maestrosOutboundCausa.Find(c => c.IdRazon == razonId).ToList());
            return result;

        }

        public MaestroOutboundMotivoCollection GetTipoMotivoPorTipoCausa(decimal causaId)
        {
            UnitOfWorkMaestros unitOfWork = new UnitOfWorkMaestros(new MaestrosContext());
            MaestroOutboundMotivoCollection result = new MaestroOutboundMotivoCollection();
            result.AddRange(unitOfWork.maestrosOutboundMotivo.Find(c => c.IdCausa == causaId).ToList());
            return result;

        }

    }
}
