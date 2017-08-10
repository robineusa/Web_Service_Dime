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
        public MultiplayCargue BuscarDatosMultiplay(decimal cuentacliente)
        {
            DimeContext context = new DimeContext();
            return context.MultiplayCargue.Where(c => c.Cuenta == cuentacliente).FirstOrDefault();
        }

        public void InsertarMultiPlay(MultiPlayRegistro multiplay)
        {
            try
            {
                multiplay.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.MultiPlayRegistro.Add(multiplay);
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

        public void EliminaCuentaDatosMultiplay(decimal Id_Cuenta, decimal Cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            MultiplayCargue CuentaEliminar = unitWork.MultiplayCargue.Find(c => c.IdSubReg == Id_Cuenta && c.Cuenta == Cuenta).FirstOrDefault();

            if (CuentaEliminar != null)
            {
                unitWork.MultiplayCargue.Remove(CuentaEliminar);
                unitWork.Complete();
            }
            else { }
        }

        public List<MultiPlayRegistro> ConsultaAdminBasePresidencial(DateTime inicial, DateTime final)
        {
            DimeContext dimContext = new DimeContext();
            List<MultiPlayRegistro> result = new List<MultiPlayRegistro>();
            var objetosResult = (from a in dimContext.MultiPlayRegistro
                                 where a.FechaGestion >= inicial && a.FechaGestion <= final
                                 orderby a.IdSubReg ascending
                                 select new
                                 {
                                     a.IdSubReg,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.RegBaGen,
                                     a.Cuenta,
                                     a.Custcode,
                                     a.TipoCuscode,
                                     a.Min,
                                     a.CustomerId,
                                     a.NombreCliente,
                                     a.Cedula,
                                     a.EstratoCliente,
                                     a.EstadoAC,
                                     a.EstadoRR,
                                     a.SaldoActualAC,
                                     a.SaldoEquipoAC,
                                     a.SaldoEquipoAscard,
                                     a.SaldoGrupo1,
                                     a.SaldoGrupo2,
                                     a.SaldoGrupo3,
                                     a.SaldoTotalRR,
                                     a.EscVentaCliente,
                                     a.AplicAjusteRR,
                                     a.CampañaCaida,
                                     a.ValoraAjustarInternet,
                                     a.ValoraAjustarTv,
                                     a.ValoraAjustarTel,
                                     a.ValAjuOtrosConcep,
                                     a.ValTotAjuFijo,
                                     a.PerCamNoApliRR,
                                     a.ObservacionesAjustes,
                                     a.AjusteAC,
                                     a.CamOfComApliCliente,
                                     a.CamAplACDiVenta,
                                     a.CfmDatosAntesIva,
                                     a.CfmDatosAntesIva4Ipoc,
                                     a.CfmVozAntesIva4Ipoc,
                                     a.FechaACTMultAC,
                                     a.TiempoCampañaCFMAAjustar,
                                     a.PagosACNoRefleRR,
                                     a.FechaPago1,
                                     a.ValorPago1,
                                     a.PagosRRNoRefleAC,
                                     a.FechaPago2,
                                     a.ValorPago2,
                                     a.PagoCambiarGrupo,
                                     a.Fecha1,
                                     a.Valor1,
                                     a.GrupoActual,
                                     a.GrupoDebeQuedar,
                                     a.PagAnuACNoApliACy_0RR,
                                     a.Valor2,
                                     a.FechaIngresoPago,
                                     a.PlataformaRepPagoAnulado,
                                     a.AnularPago,
                                     a.Fecha2,
                                     a.Valor3,
                                     a.Plataforma,
                                     a.ArrPropClieRR,
                                     a.NotasAdicionales,
                                     a.Escenario1,
                                     a.FechaGestion,
                                     a.NombreBase
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MultiPlayRegistro());
                result[i].IdSubReg = objetosResult[i].IdSubReg;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].RegBaGen = objetosResult[i].RegBaGen;
                result[i].Cuenta = objetosResult[i].Cuenta;
                result[i].Custcode = objetosResult[i].Custcode;
                result[i].TipoCuscode = objetosResult[i].TipoCuscode;
                result[i].Min = objetosResult[i].Min;
                result[i].CustomerId = objetosResult[i].CustomerId;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].Cedula = objetosResult[i].Cedula;
                result[i].EstratoCliente = objetosResult[i].EstratoCliente;
                result[i].EstadoAC = objetosResult[i].EstadoAC;
                result[i].EstadoRR = objetosResult[i].EstadoRR;
                result[i].SaldoActualAC = objetosResult[i].SaldoActualAC;
                result[i].SaldoEquipoAC = objetosResult[i].SaldoEquipoAC;
                result[i].SaldoEquipoAscard = objetosResult[i].SaldoEquipoAscard;
                result[i].SaldoGrupo1 = objetosResult[i].SaldoGrupo1;
                result[i].SaldoGrupo2 = objetosResult[i].SaldoGrupo2;
                result[i].SaldoGrupo3 = objetosResult[i].SaldoGrupo3;
                result[i].SaldoTotalRR = objetosResult[i].SaldoTotalRR;
                result[i].EscVentaCliente = objetosResult[i].EscVentaCliente;
                result[i].AplicAjusteRR = objetosResult[i].AplicAjusteRR;
                result[i].CampañaCaida = objetosResult[i].CampañaCaida;
                result[i].ValoraAjustarInternet = objetosResult[i].ValoraAjustarInternet;
                result[i].ValoraAjustarTv = objetosResult[i].ValoraAjustarTv;
                result[i].ValoraAjustarTel = objetosResult[i].ValoraAjustarTel;
                result[i].ValAjuOtrosConcep = objetosResult[i].ValAjuOtrosConcep;
                result[i].ValTotAjuFijo = objetosResult[i].ValTotAjuFijo;
                result[i].PerCamNoApliRR = objetosResult[i].PerCamNoApliRR;
                result[i].ObservacionesAjustes = objetosResult[i].ObservacionesAjustes;
                result[i].AjusteAC = objetosResult[i].AjusteAC;
                result[i].CamOfComApliCliente = objetosResult[i].CamOfComApliCliente;
                result[i].CamAplACDiVenta = objetosResult[i].CamAplACDiVenta;
                result[i].CfmDatosAntesIva = objetosResult[i].CfmDatosAntesIva;
                result[i].CfmDatosAntesIva4Ipoc = objetosResult[i].CfmDatosAntesIva4Ipoc;
                result[i].CfmVozAntesIva4Ipoc = objetosResult[i].CfmVozAntesIva4Ipoc;
                result[i].FechaACTMultAC = objetosResult[i].FechaACTMultAC;
                result[i].TiempoCampañaCFMAAjustar = objetosResult[i].TiempoCampañaCFMAAjustar;
                result[i].PagosACNoRefleRR = objetosResult[i].PagosACNoRefleRR;
                result[i].FechaPago1 = objetosResult[i].FechaPago1;
                result[i].ValorPago1 = objetosResult[i].ValorPago1;
                result[i].PagosRRNoRefleAC = objetosResult[i].PagosRRNoRefleAC;
                result[i].FechaPago2 = objetosResult[i].FechaPago2;
                result[i].ValorPago2 = objetosResult[i].ValorPago2;
                result[i].PagoCambiarGrupo = objetosResult[i].PagoCambiarGrupo;
                result[i].Fecha1 = objetosResult[i].Fecha1;
                result[i].Valor1 = objetosResult[i].Valor1;
                result[i].GrupoActual = objetosResult[i].GrupoActual;
                result[i].GrupoDebeQuedar = objetosResult[i].GrupoDebeQuedar;
                result[i].PagAnuACNoApliACy_0RR = objetosResult[i].PagAnuACNoApliACy_0RR;
                result[i].Valor2 = objetosResult[i].Valor2;
                result[i].FechaIngresoPago = objetosResult[i].FechaIngresoPago;
                result[i].PlataformaRepPagoAnulado = objetosResult[i].PlataformaRepPagoAnulado;
                result[i].AnularPago = objetosResult[i].AnularPago;
                result[i].Fecha2 = objetosResult[i].Fecha2;
                result[i].Valor3 = objetosResult[i].Valor3;
                result[i].Plataforma = objetosResult[i].Plataforma;
                result[i].ArrPropClieRR = objetosResult[i].ArrPropClieRR;
                result[i].NotasAdicionales = objetosResult[i].NotasAdicionales;
                result[i].Escenario1 = objetosResult[i].Escenario1;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].NombreBase = objetosResult[i].NombreBase;
            }
            return result;

        }

    }
}


