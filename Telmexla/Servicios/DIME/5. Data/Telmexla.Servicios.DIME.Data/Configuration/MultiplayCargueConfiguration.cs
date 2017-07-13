
#pragma warning disable 1591    

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MultiplayCargueConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MultiplayCargue>
    {
        public MultiplayCargueConfiguration()
            : this("dbo")
        {
        }

        public MultiplayCargueConfiguration(string schema)
        {
            ToTable("TBL_MCB_MULTIPLAY", schema);
            HasKey(x => new { x.IdSubReg });

            Property(x => x.IdSubReg).HasColumnName(@"ID_SUB_REG").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RegBaGen).HasColumnName(@"REG_BA_GEN").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("numeric");
            Property(x => x.Custcode).HasColumnName(@"CUSTCODE").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoCuscode).HasColumnName(@"TIPO_CUSCODE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Min).HasColumnName(@"MIN").IsOptional().HasColumnType("numeric");
            Property(x => x.CustomerId).HasColumnName(@"CUSTOMER_ID").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreCliente).HasColumnName(@"NOMBRE_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Cedula).HasColumnName(@"CEDULA").IsOptional().HasColumnType("numeric");
            Property(x => x.EstratoCliente).HasColumnName(@"ESTRATO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.EstadoAC).HasColumnName(@"ESTADO_AC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.EstadoRR).HasColumnName(@"ESTADO_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.SaldoActualAC).HasColumnName(@"SALDO_ACTUAL_AC").IsOptional().HasColumnType("numeric");
            Property(x => x.SaldoEquipoAC).HasColumnName(@"SALDO_EQUIPO_AC").IsOptional().HasColumnType("numeric");
            Property(x => x.SaldoEquipoAscard).HasColumnName(@"SALDO_EQUIPO_ASCARD").IsOptional().HasColumnType("numeric");
            Property(x => x.SaldoGrupo1).HasColumnName(@"SALDO_GRUPO_1").IsOptional().HasColumnType("numeric");
            Property(x => x.SaldoGrupo2).HasColumnName(@"SALDO_GRUPO_2").IsOptional().HasColumnType("numeric");
            Property(x => x.SaldoGrupo3).HasColumnName(@"SALDO_GRUPO_3").IsOptional().HasColumnType("numeric");
            Property(x => x.SaldoTotalRR).HasColumnName(@"SALDO_TOTAL_RR").IsOptional().HasColumnType("numeric");
            Property(x => x.EscVentaCliente).HasColumnName(@"ESC_VENTA_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AplicAjusteRR).HasColumnName(@"APLIC_AJUSTE_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CampañaCaida).HasColumnName(@"CAMPANA_CAIDA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ValoraAjustarInternet).HasColumnName(@"VALOR_A_AJUSTAR_INT").IsOptional().HasColumnType("numeric");
            Property(x => x.ValoraAjustarTv).HasColumnName(@"VALOR_A_AJUSTAR_TV").IsOptional().HasColumnType("numeric");
            Property(x => x.ValoraAjustarTel).HasColumnName(@"VALOR_A_AJUSTAR_TEL").IsOptional().HasColumnType("numeric");
            Property(x => x.ValAjuOtrosConcep).HasColumnName(@"VAL_AJU_OTROS_CONCEP").IsOptional().HasColumnType("numeric");
            Property(x => x.ValTotAjuFijo).HasColumnName(@"VAL_TOT_AJU_FIJO").IsOptional().HasColumnType("numeric");
            Property(x => x.PerCamNoApliRR).HasColumnName(@"PER_CAM_NO_APLI_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ObservacionesAjustes).HasColumnName(@"OBSERVACIONES_AJUSTES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.AjusteAC).HasColumnName(@"AJUSTE_AC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CamOfComApliCliente).HasColumnName(@"CAM_OF_COM_APLI_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CamAplACDiVenta).HasColumnName(@"CAM_APL_AC_DI_VENTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CfmDatosAntesIva).HasColumnName(@"CFM_DATOS_ANTES_IVA").IsOptional().HasColumnType("numeric");
            Property(x => x.CfmDatosAntesIva4Ipoc).HasColumnName(@"CFM_DATOS_ANTES_IVA_IPOC").IsOptional().HasColumnType("numeric");
            Property(x => x.CfmVozAntesIva4Ipoc).HasColumnName(@"CFM_VOZ_ANTES_IVA_IPOC").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaACTMultAC).HasColumnName(@"FECHA_ACT_MULT_AC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.TiempoCampañaCFMAAjustar).HasColumnName(@"TIEMPO_CAMPANA_CFM_A_AJUSTAR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PagosACNoRefleRR).HasColumnName(@"PAGOS_AC_NO_REFLE_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaPago1).HasColumnName(@"FECHA_PAGO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ValorPago1).HasColumnName(@"VALOR_PAGO_1").IsOptional().HasColumnType("numeric");
            Property(x => x.PagosRRNoRefleAC).HasColumnName(@"PAGOS_RR_NO_REFLE_AC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaPago2).HasColumnName(@"FECHA_PAGO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ValorPago2).HasColumnName(@"VALOR_PAGO_2").IsOptional().HasColumnType("numeric");
            Property(x => x.PagoCambiarGrupo).HasColumnName(@"PAGO_CAMBIAR_GRUPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Fecha1).HasColumnName(@"FECHA_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Valor1).HasColumnName(@"VALOR_1").IsOptional().HasColumnType("numeric");
            Property(x => x.GrupoActual).HasColumnName(@"GRUPO_ACTUAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.GrupoDebeQuedar).HasColumnName(@"GRUPO_DEBE_QUEDAR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PagAnuACNoApliACy_0RR).HasColumnName(@"PAG_ANU_AC_NO_APLI_AC_Y_O_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Valor2).HasColumnName(@"VALOR_2").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaIngresoPago).HasColumnName(@"FECHA_INGRESO_PAGO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PlataformaRepPagoAnulado).HasColumnName(@"PLATAFORMA_REP_PAGO_ANULADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AnularPago).HasColumnName(@"ANULAR_PAGO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Fecha2).HasColumnName(@"FECHA_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Valor3).HasColumnName(@"VALOR_3").IsOptional().HasColumnType("numeric");
            Property(x => x.Plataforma).HasColumnName(@"PLATAFORMA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ArrPropClieRR).HasColumnName(@"ARR_PROP_CLIE_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Escenario1).HasColumnName(@"ESCENARIO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.FechaCargueBase).HasColumnName(@"FECHA_CARGUE_BASE").IsOptional().HasColumnType("datetime");
            Property(x => x.NombreBase).HasColumnName(@"NOMBRE_BASE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}
