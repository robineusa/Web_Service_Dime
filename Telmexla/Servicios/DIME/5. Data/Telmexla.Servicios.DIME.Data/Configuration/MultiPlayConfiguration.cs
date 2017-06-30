// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MultiPlayConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MultiPlay>
    {
        public MultiPlayConfiguration()
            : this("dbo")
        {
        }

        public MultiPlayConfiguration(string schema)
        {
            ToTable("TBL_MULTIPLAY", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestionUsuario).HasColumnName(@"FECHA_GESTION_USUARIO").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.SubRegistro).HasColumnName(@"SUB_REGISTRO ").IsRequired().HasColumnType("numeric");
            Property(x => x.RegBaGen).HasColumnName(@"REG_BA_GEN ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA ").IsRequired().HasColumnType("numeric");
            Property(x => x.Custcode).HasColumnName(@"CUSTCODE ").IsRequired().HasColumnType("decimal");
            Property(x => x.TipoCuscode).HasColumnName(@"TIPO_CUSCODE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Min).HasColumnName(@"MIN").IsRequired().HasColumnType("numeric");
            Property(x => x.CustomerId).HasColumnName(@"CUSTOMER_ID").IsRequired().HasColumnType("numeric");
            Property(x => x.NombreCliente).HasColumnName(@"NOMBRE_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Cedula).HasColumnName(@"CEDULA").IsRequired().HasColumnType("numeric");
            Property(x => x.EstratoCliente).HasColumnName(@"ESTRATO_CLIENTE").IsRequired().HasColumnType("numeric");
            Property(x => x.EstadoAC).HasColumnName(@"ESTADO_AC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.EstadoRR).HasColumnName(@"ESTADO_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.SaldoActualAC).HasColumnName(@"SALDO_ACTUAL_AC").IsRequired().HasColumnType("numeric");
            Property(x => x.SaldoEquipoAC).HasColumnName(@"SALDO_EQUIPO_AC").IsRequired().HasColumnType("numeric");
            Property(x => x.SaldoEquipoAscard).HasColumnName(@"SALDO_EQUIPO_ASCARD").IsRequired().HasColumnType("numeric");
            Property(x => x.SaldoGrupo1).HasColumnName(@"SALDO_GRUPO_1 ").IsRequired().HasColumnType("numeric");
            Property(x => x.SaldoGrupo2).HasColumnName(@"SALDO_GRUPO_2 ").IsRequired().HasColumnType("numeric");
            Property(x => x.SaldoGrupo3).HasColumnName(@"SALDO_GRUPO_3 ").IsRequired().HasColumnType("numeric");
            Property(x => x.SaldoTotalRR).HasColumnName(@"SALDO_TOTAL_RR").IsRequired().HasColumnType("numeric");
            Property(x => x.EscVentaCliente).HasColumnName(@"ESC_VENTA_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AplicAjusteRR).HasColumnName(@"APLIC_AJUSTE_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CampañaCaida).HasColumnName(@"CAMPAÑA_CAIDA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ValoraAjustarInternet).HasColumnName(@"VALOR_A_AJUSTAR_@").IsRequired().HasColumnType("numeric");
            Property(x => x.ValoraAjustarTv).HasColumnName(@"VALOR_A_AJUSTAR_TV").IsRequired().HasColumnType("numeric");
            Property(x => x.ValoraAjustarTel).HasColumnName(@"VALOR_A_AJUSTAR_TEL").IsRequired().HasColumnType("numeric");
            Property(x => x.ValAjuOtrosConcep).HasColumnName(@"VAL_AJU_OTROS_CONCEP").IsRequired().HasColumnType("numeric");
            Property(x => x.ValTotAjuFijo).HasColumnName(@"VAL_TOT_AJU_FIJO").IsRequired().HasColumnType("numeric");
            Property(x => x.PerCamNoApliRR).HasColumnName(@"PER_CAM_NO_APLI_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ObservacionesAjustes).HasColumnName(@"OBSERVACIONES_AJUSTES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.AjusteAC).HasColumnName(@"AJUSTE_AC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CamOfComApliCliente).HasColumnName(@"CAM_OF_COM_APLI_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CamAplACDiVenta).HasColumnName(@"CAM_APL_AC_DI_VENTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CfmDatosAntesIva).HasColumnName(@"CFM_DATOS_ANTES_IVA").IsRequired().HasColumnType("numeric");
            Property(x => x.CfmDatosAntesIva4Ipoc).HasColumnName(@"CFM_DATOS_ANTES_IVA_+4%_IPOC").IsRequired().HasColumnType("numeric");
            Property(x => x.CfmVozAntesIva4Ipoc).HasColumnName(@"CFM_VOZ_ANTES_IVA_+4%_IPOC").IsRequired().HasColumnType("numeric");
            Property(x => x.FechaACTMultAC).HasColumnName(@"FECHA_ACT_MULT_AC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.TiempoCampañaCFMAAjustar).HasColumnName(@"TIEMPO_CAMPAÑA_CFM_A_AJUSTAR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PagosACNoRefleRR).HasColumnName(@"PAGOS_AC_NO_REFLE_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaPago1).HasColumnName(@"FECHA_PAGO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ValorPago1).HasColumnName(@"VALOR_PAGO_1").IsRequired().HasColumnType("numeric");
            Property(x => x.PagosRRNoRefleAC).HasColumnName(@"PAGOS_RR_NO_REFLE_AC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaPago2).HasColumnName(@"FECHA_PAGO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ValorPago2).HasColumnName(@"VALOR_PAGO_2").IsRequired().HasColumnType("numeric");
            Property(x => x.PagoCambiarGrupo).HasColumnName(@"PAGO_CAMBIAR_GRUPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Fecha1).HasColumnName(@"FECHA_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Valor1).HasColumnName(@"VALOR_1").IsRequired().HasColumnType("numeric");
            Property(x => x.GrupoActual).HasColumnName(@"GRUPO_ACTUAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.GrupoDebeQuedar).HasColumnName(@"GRUPO_DEBE_QUEDAR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PagAnuACNoApliACy_0RR).HasColumnName(@"PAG_ANU_AC_NO_APLI_AC_Y/O_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Valor2).HasColumnName(@"VALOR_2").IsRequired().HasColumnType("numeric");
            Property(x => x.FechaIngresoPago).HasColumnName(@"FECHA_INGRESO_PAGO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PlataformaRepPagoAnulado).HasColumnName(@"PLATAFORMA_REP_PAGO_ANULADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AnularPago).HasColumnName(@"ANULAR_PAGO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Fecha2).HasColumnName(@"FECHA_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Valor3).HasColumnName(@"VALOR_3").IsRequired().HasColumnType("numeric");
            Property(x => x.Plataforma).HasColumnName(@"PLATAFORMA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ArrPropClieRR).HasColumnName(@"ARR_PROP_CLIE_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.NotasAdicionales).HasColumnName(@"NOTAS_ADICIONALES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Escenario1).HasColumnName(@"ESCENARIO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.AgenteGestiona).HasColumnName(@"AGENTE_GESTIONA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("date");
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
        }
    }
}
