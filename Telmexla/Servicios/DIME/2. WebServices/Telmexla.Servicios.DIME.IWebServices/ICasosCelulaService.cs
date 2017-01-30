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
    public interface ICasosCelulaService
    {

        [OperationContract]
        IngresoCollection ListaCasosAbiertosDeCelulaUser(string lineaUser, string aliadoUser);

        [OperationContract]
        IngresoCollection ListaCasosEnSeguimiento(string usuario);

        [OperationContract]
        List<GestionDeCelulaUsr> ListaGestionCasos(DateTime inicial, DateTime final, string idUsr);

        [OperationContract]
        IngresoCollection ListaIngresosPorCuenta(string  cuenta);

        [OperationContract]
        IngresoCollection ListaIngresosPorId(string id);

        [OperationContract]
        bool CasoTomadoPorUsrBackActualizar(int idIngreso, string usrBack);

        [OperationContract]
        void ActualizarIngresoPorCelula(string estadoCaso, string areaAEscalar, string aplicaRechazo, string razonRechazo, string notas, int idIngreso);
  
    }
}
