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
    //TBL_FID_MOTIVOS_CANCELACION
    public class FidelizacionMotivosCancelacionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FidelizacionMotivosCancelacion>
    {
        public FidelizacionMotivosCancelacionConfiguration()
            : this("dbo")
        {
        }

        public FidelizacionMotivosCancelacionConfiguration(string schema)
        {
            ToTable("TBL_FID_MOTIVOS_CANCELACION", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Motivo).HasColumnName(@"MOTIVO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.OtrosCampos).HasColumnName(@"OTROS_CAMPOS").IsOptional().HasColumnType("numeric");
            Property(x => x.OtrosOfrecimientos).HasColumnName(@"OTROS_OFRECIMIENTOS").IsOptional().HasColumnType("numeric");
            Property(x => x.Registro).HasColumnName(@"REGISTRADO").IsOptional().HasColumnType("datetime");
            Property(x => x.Eliminado).HasColumnName(@"ELIMINADO").IsOptional().HasColumnType("numeric");
        }
    }
}
