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
    public class FidelizacionRegistroCamposConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FidelizacionRegistroCampos>
    {
        public FidelizacionRegistroCamposConfiguration()
            : this("dbo")
        {
        }

        public FidelizacionRegistroCamposConfiguration(string schema)
        {
            ToTable("TBL_FID_REGISTRO_CAMPOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RegistroId).HasColumnName(@"REGISTRO_ID").IsRequired().HasColumnType("numeric");
            Property(x => x.OtrosCamposId).HasColumnName(@"OTROS_CAMPOS_ID").IsRequired().HasColumnType("numeric");
            Property(x => x.Valor).HasColumnName(@"VALOR").IsRequired().HasColumnType("varchar");
            
        }
    }
}
