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
        public void AgregarAliado(BIMAliados AliadoNuevo) {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.AgregarAliado(AliadoNuevo);
        }
        public void ActualizarAliado(BIMAliados Aliado) {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.ActualizarAliado(Aliado);
        }
        public void AgregarGerencia(BIMGerencias GerenciaNueva)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.AgregarGerencia(GerenciaNueva);
        }
        public void ActualizarGerencia(BIMGerencias Gerencia)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.ActualizarGerencia(Gerencia);
        }
        public void AgregarOperaciones(BIMOperaciones OperacionNueva)
        {

            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.AgregarOperaciones(OperacionNueva);
        }
        public void ActualizarOperacion(BIMOperaciones Operacion)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            Bitacorabusiness.ActualizarOperacion(Operacion);
        }
        public List<BIMGerencias> ListaDeGerenciasAdmin()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeGerenciasAdmin();
        }
        public List<BIMAliados> ListaDeAliadosAdmin()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeAliadosAdmin();
        }
        public List<ViewModelIncidentesOperaciones> ListaDeOperacionesAdmin()
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.ListaDeOperacionesAdmin();
        }
        public BIMGerencias GerenciaPorId(int Id)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.GerenciaPorId(Id);
        }
        public BIMAliados AliadoPorId(int Id)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.AliadoPorId(Id);
        }
        public BIMOperaciones OperacionPorId(int Id)
        {
            BitacoraIncidentesBusiness Bitacorabusiness = new BitacoraIncidentesBusiness();
            return Bitacorabusiness.OperacionPorId(Id);
        }
    }
}
