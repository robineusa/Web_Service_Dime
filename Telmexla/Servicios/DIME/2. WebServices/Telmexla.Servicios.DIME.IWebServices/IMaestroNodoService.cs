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
    public interface IMaestroNodoService
    {
        [OperationContract]
        void InsertarNodo(MaestroNodo nodo);
        [OperationContract]
        bool ExisteNodo(string nodo);
        [OperationContract]
        MaestroNodo GetInformacionNodo(string nodo);
        [OperationContract]
        void ActualizarInformacionNodo(MaestroNodo nodo);
        [OperationContract]
        MaestroNodoCollection ListaNodosCreados();
        [OperationContract]
        MaestroNodo GetInformacionNodoId(int id);
    }
    
}
