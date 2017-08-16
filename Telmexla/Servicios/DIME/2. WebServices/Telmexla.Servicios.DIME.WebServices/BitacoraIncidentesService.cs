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
        public decimal RegistrarIncidente(BIPBitacoraIncidentes Bitacora)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.RegistrarIncidente(Bitacora);
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
        public List<BIMHerramientas> ListaDeHerramientas()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeHerramientas();
        }
        public List<BIMTipoFalla> ListaTiposDeFallas()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaTiposDeFallas();
        }
        public List<BIMPrioridades> ListaDePrioridades()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDePrioridades();
        }
        public List<BIMOperaciones> ListaDeOperaciones()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeOperaciones();
        }
        public List<BIMAliados> ListaDeAliadosPorGerencia(List<string> Gerencias)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeAliadosPorGerencia(Gerencias);
        }
        public List<BIMOperaciones> ListaDeOperacionesPorgerenciaYAliado(List<string> Gerencias, List<string> Aliados)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeOperacionesPorgerenciaYAliado(Gerencias, Aliados);
        }
        public void RegistrarOperacionesEnIncidente(List<string> Operaciones, decimal IdRegistro) {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.RegistrarOperacionesEnIncidente(Operaciones, IdRegistro);
        }
        public BIPBitacoraIncidentes TraeIncidentePorId(int IdRegistro)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.TraeIncidentePorId(IdRegistro);
        }
        public List<ViewModelIncidentesOperaciones> ListaDeIncidentesOperacionPorRegistro(decimal IdRegistro)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeIncidentesOperacionPorRegistro(IdRegistro);
        }
        public void EliminarOpoeracionDeIncidente(int Id)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.EliminarOpoeracionDeIncidente(Id);
        }
        public List<BIPBitacoraIncidentes> ListaDeIncidentesEnGestion()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeIncidentesEnGestion();
        }
    }
}
