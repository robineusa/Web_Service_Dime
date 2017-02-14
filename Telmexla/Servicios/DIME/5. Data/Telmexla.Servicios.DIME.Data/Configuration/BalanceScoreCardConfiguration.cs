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
    //TBL_BALANCE_SCORE_CARD
    public class BalanceScoreCardConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BalanceScoreCard>
    {
        public BalanceScoreCardConfiguration()
            : this("dbo")
        {
        }

        public BalanceScoreCardConfiguration(string schema)
        {
            ToTable("TBL_BALANCE_SCORE_CARD", schema);
            HasKey(x => new { x.Cedula});

            Property(x => x.Cedula).HasColumnName(@"CEDULA").IsRequired().HasColumnType("numeric");
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Aliado).HasColumnName(@"ALIADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Canal).HasColumnName(@"CANAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Operacion).HasColumnName(@"OPERACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Grupo).HasColumnName(@"GRUPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Cargo).HasColumnName(@"CARGO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Segmento).HasColumnName(@"SEGMENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Supervisor).HasColumnName(@"SUPERVISOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Acdcalls).HasColumnName(@"ACDCALLS").IsOptional().HasColumnType("numeric");
            Property(x => x.Tmo).HasColumnName(@"TMO").IsOptional().HasColumnType("numeric");
            Property(x => x.Espera).HasColumnName(@"ESPERA").IsOptional().HasColumnType("numeric");
            Property(x => x.AjustesCorrectos).HasColumnName(@"AJUSTES_CORRECTO").IsOptional().HasColumnType("numeric");
            Property(x => x.PqrsCorrectos).HasColumnName(@"PQR_CORRECTOS").IsOptional().HasColumnType("float");
            Property(x => x.MetaVentas).HasColumnName(@"META_VENTAS").IsOptional().HasColumnType("numeric");
            Property(x => x.ReincidenciaAsesor).HasColumnName(@"REINCIDENCIA_ASESOR").IsOptional().HasColumnType("numeric");
            Property(x => x.NpsSolucion).HasColumnName(@"NPS_SOLUCION").IsOptional().HasColumnType("numeric");
            Property(x => x.NpsSatisfaccion).HasColumnName(@"NPS_SATISFACCION").IsOptional().HasColumnType("numeric");
            Property(x => x.CalificacionMec).HasColumnName(@"CALIFICACION_MEC").IsOptional().HasColumnType("numeric");
            Property(x => x.ActivacionesClaroVideo).HasColumnName(@"ACTIVACIONES_CLAROVIDEO").IsOptional().HasColumnType("numeric");
            Property(x => x.ActivacionesConvenioFactura).HasColumnName(@"ACTIVACIONES_CONVENIO_FACTURA").IsOptional().HasColumnType("numeric");
            Property(x => x.CalificacionTmo).HasColumnName(@"CALIFICACION_TMO").IsOptional().HasColumnType("numeric");
            Property(x => x.PuntajeTotal).HasColumnName(@"PUNTAJE_TOTAL").IsOptional().HasColumnType("numeric");
            Property(x => x.Fecha).HasColumnName(@"FECHA").IsOptional().HasColumnType("date");
            Property(x => x.Periodo).HasColumnName(@"PERIODO").IsOptional().HasColumnType("numeric");
            }
    }
}
