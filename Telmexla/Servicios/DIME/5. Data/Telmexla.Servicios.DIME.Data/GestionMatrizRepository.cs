using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class GestionMatrizRepository: Repository<GestionMatriz>,IGestionMatrizRepository
    {

        public GestionMatrizRepository(DimeContext context) : base(context)
        {


        }

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }
        public string ComprobarActualizarUsrBackofficeCreacion(decimal idTransaccion, string usuarioBack)
        {
            var result = dimeContext.ActualizaUsuarioGestionBackCreacionMatriz(idTransaccion, usuarioBack);
            if (result.Count > 0)
                return result.First().USUARIO_BACKOFFICE_CREACION;
            else
                return "";
        }
        public string ComprobarActualizarUsrBackofficeGestion(decimal idTransaccion, string usuarioOut)
        {
            var result = dimeContext.ActualizaUsuarioGestionBackGestionMatriz(idTransaccion, usuarioOut);
            if (result.Count > 0)
                return result.First().USUARIO_BACKOFFICE_GESTION;
            else
                return "";
        }
    }
}
