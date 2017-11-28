using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IProcesosService
    {
        [OperationContract]
        void CrearNodo(Nodo nodo);
        [OperationContract]
        List<Nodo> ConsultarNodos(int IdArbol);
        [OperationContract]
        Arbol ConsultarArbol(int IdArbol);
        [OperationContract]
        Nodo ConsultarNodoCreado();
    }
}
