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
    public class FidelizacionSubmotivosCancelacionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FidelizacionSubmotivosCancelacion>
    {
        public FidelizacionSubmotivosCancelacionConfiguration()
            : this("dbo")
        {
        }

        public FidelizacionSubmotivosCancelacionConfiguration(string schema)
        {
            ToTable("TBL_FID_SUBMOTIVOS_CANCELACION", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Submotivo).HasColumnName(@"SUBMOTIVO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Eliminado).HasColumnName(@"ELIMINADO").IsRequired().HasColumnType("numeric");
            Property(x => x.Registro).HasColumnName(@"REGISTRO").IsRequired().HasColumnType("datetime");
            Property(x => x.FIDMotivoId).HasColumnName(@"FID_MOTIVO_ID").IsRequired().HasColumnType("numeric");
        }
    }
}
