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
    public interface IActivacionSiembraHDService
    {
        [OperationContract]
        List<CuentasSiembraHD> BuscarCuentaSiembraHD(decimal cuentacliente);

        [OperationContract]
        void InsertarSiembraHDInbound(SiembraHD siembra);

        [OperationContract]
        List<CuentasSiguienteMejorOferta> BuscarCuentaSMO(decimal cuentacliente);

        [OperationContract]
        void InsertarSMOInbound(SiguienteMejorOferta smo);
    }
}
