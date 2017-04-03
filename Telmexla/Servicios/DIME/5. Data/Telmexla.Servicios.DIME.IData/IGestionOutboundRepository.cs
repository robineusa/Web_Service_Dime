using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IData
{
    public interface IGestionOutboundRepository : IRepository<GestionOutbound>
    {

        bool ApartarCuentaAGestionarAsesor(string gestionBlending, int idAsesor, string aliado, string linea);




    }
}
