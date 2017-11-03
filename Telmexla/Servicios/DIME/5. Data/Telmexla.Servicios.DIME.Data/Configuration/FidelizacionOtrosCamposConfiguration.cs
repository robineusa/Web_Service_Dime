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
    //TBL_FID_OTROS_OFRECIMIENTOS
    public class FidelizacionOtrosCamposConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FidelizacionOtrosCampos>
    {
        public FidelizacionOtrosCamposConfiguration()
            : this("dbo")
        {
        }

        public FidelizacionOtrosCamposConfiguration(string schema)
        {
            ToTable("TBL_FID_OTROS_CAMPOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Tipo).HasColumnName(@"TIPO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Opciones).HasColumnName(@"OPCIONES").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(5000);
            Property(x => x.Nivel).HasColumnName(@"NIVEL").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(5);
            Property(x => x.Eliminado).HasColumnName(@"ELIMINADO").IsRequired().HasColumnType("numeric");
        }
    }
}
