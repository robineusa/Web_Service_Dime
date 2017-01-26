using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface ITrasladosService
    {
        [OperationContract]
        void RegistrarIngresoTraslado(IngresoTraslado ingreso, NotasTraslado notaTraslado);
        [OperationContract]
        bool ExisteCuentaEscalada(decimal cuenta);
        [OperationContract]
        List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion();
        [OperationContract]
        NotasTrasladoCollection ListaInteraccionesCrearDireccion(int id);
        [OperationContract]
        void ActualizarSolicitudCrearDireccion(IngresoTraslado ingreso, NotasTraslado notaTraslado);
        [OperationContract]
        bool TransaccionEnGestion(int id, String usrABackOffice);
        

   }
}
