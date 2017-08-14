using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class BitacoraIncidentesService : IBitacoraIncidentesService
    {
        public void RegistrarIncidente(BIPBitacoraIncidentes Bitacora)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.RegistrarIncidente(Bitacora);
        }
        public void ActualizarRegistroIncidente(BIPBitacoraIncidentes Bitacora)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.ActualizarRegistroIncidente(Bitacora);
        }
        public void RegistrarOperacionesPorIncidente(List<string> Operaciones, decimal IdRegistro)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.RegistrarOperacionesPorIncidente(Operaciones,IdRegistro);
        }
        public void EliminarIncidenteOperacion(decimal Id)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.EliminarIncidenteOperacion(Id);
        }
        public List<BIMGerencias> ListaDeGerencias()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeGerencias();
        }
        public List<BIMAliados> ListaDeAliados()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeAliados();
        }
        public List<BIMOperaciones> ListaOperaciones()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaOperaciones();
        }
    }
}
