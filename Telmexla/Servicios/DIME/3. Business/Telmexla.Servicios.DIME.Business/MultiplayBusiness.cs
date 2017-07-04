using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class MultiplayBusiness
    {
        public DatosMultiplay BuscarDatosMultiplay(int cuentacliente)
        {
            DimeContext context = new DimeContext();
            return context.DatosMultiplay.Where(c => c.Cuenta == cuentacliente).FirstOrDefault();
            //UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            //DatosMultiplayCollection result = new DatosMultiplayCollection();
            //result.AddRange(unitwork.DatosMultiplay.Find(x => x.Cuenta == cuentacliente).Select(a => new DatosMultiplay
            //{
            //    Id = a.Id,
            //    SubRegistro = a.SubRegistro,
            //    RegBaGen = a.RegBaGen,
            //    Cuenta = a.Cuenta,
            //    Custcode = a.Custcode,
            //    TipoCuscode = a.TipoCuscode,
            //    Min = a.Min,
            //    CustomerId = a.CustomerId,
            //    NombreCliente = a.NombreCliente,
            //    Cedula = a.Cedula,
            //    EstratoCliente = a.EstratoCliente,
            //    EstadoAC = a.EstadoAC,
            //    EstadoRR = a.EstadoRR,
            //    SaldoActualAC = a.SaldoActualAC,
            //    SaldoEquipoAC = a.SaldoEquipoAC,
            //    SaldoEquipoAscard = a.SaldoEquipoAscard,
            //    SaldoGrupo1 = a.SaldoGrupo1,
            //    SaldoGrupo2 = a.SaldoGrupo2,
            //    SaldoGrupo3 = a.SaldoGrupo3,
            //    SaldoTotalRR = a.SaldoTotalRR,
            //    EscVentaCliente = a.EscVentaCliente,
            //    AplicAjusteRR = a.AplicAjusteRR,
            //    CampañaCaida = a.CampañaCaida,
            //    ValoraAjustarInternet = a.ValoraAjustarInternet,
            //    ValoraAjustarTv = a.ValoraAjustarTv,
            //    ValoraAjustarTel = a.ValoraAjustarTel,
            //    ValAjuOtrosConcep = a.ValAjuOtrosConcep,
            //    ValTotAjuFijo = a.ValTotAjuFijo,
            //    PerCamNoApliRR = a.PerCamNoApliRR,
            //    ObservacionesAjustes = a.ObservacionesAjustes,
            //    AjusteAC = a.AjusteAC,
            //    CamOfComApliCliente = a.CamOfComApliCliente,
            //    CamAplACDiVenta = a.CamAplACDiVenta,
            //    CfmDatosAntesIva = a.CfmDatosAntesIva,
            //    CfmDatosAntesIva4Ipoc = a.CfmDatosAntesIva4Ipoc,
            //    CfmVozAntesIva4Ipoc = a.CfmVozAntesIva4Ipoc,
            //    FechaACTMultAC = a.FechaACTMultAC,
            //    TiempoCampañaCFMAAjustar = a.TiempoCampañaCFMAAjustar,
            //    PagosACNoRefleRR = a.PagosACNoRefleRR,
            //    FechaPago1 = a.FechaPago1,
            //    ValorPago1 = a.ValorPago1,
            //    PagosRRNoRefleAC = a.PagosRRNoRefleAC,
            //    FechaPago2 = a.FechaPago2,
            //    ValorPago2 = a.ValorPago2,
            //    PagoCambiarGrupo = a.PagoCambiarGrupo,
            //    Fecha1 = a.Fecha1,
            //    Valor1 = a.Valor1,
            //    GrupoActual = a.GrupoActual,
            //    GrupoDebeQuedar = a.GrupoDebeQuedar,
            //    PagAnuACNoApliACy_0RR = a.PagAnuACNoApliACy_0RR,
            //    Valor2 = a.Valor2,
            //    FechaIngresoPago = a.FechaIngresoPago,
            //    PlataformaRepPagoAnulado = a.PlataformaRepPagoAnulado,
            //    AnularPago = a.AnularPago,
            //    Fecha2 = a.Fecha2,
            //    Valor3 = a.Valor3,
            //    Plataforma = a.Plataforma,
            //    ArrPropClieRR = a.ArrPropClieRR,
            //    NotasAdicionales = a.NotasAdicionales,
            //    Escenario1 = a.Escenario1,
            //    AgenteGestiona = a.AgenteGestiona,
            //    FechaGestion = a.FechaGestion

            //}).ToList());

            //return result;



        }

        public void InsertarMultiPlay(MultiPlay multiplay)
        {
            try
            {
                multiplay.FechaGestionUsuario = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.MultiPlay.Add(multiplay);
                unitWork.Complete();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }

        public void EliminaCuentaDatosMultiplay(int Id_Cuenta, int Cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DatosMultiplay CuentaEliminar = unitWork.DatosMultiplay.Find(c => c.Id == Id_Cuenta && c.Cuenta == Id_Cuenta).FirstOrDefault();

            if (CuentaEliminar != null)
            {
                unitWork.DatosMultiplay.Remove(CuentaEliminar);
                unitWork.Complete();
            }
            else { }
        }

    }
}
