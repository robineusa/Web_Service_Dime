
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

    // TBL_MODOS_LOGINS
    public class ModosLoginConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ModosLogin>
    {
        public ModosLoginConfiguration()
            : this("dbo")
        {
        }

        public ModosLoginConfiguration(string schema)
        {
            ToTable("TBL_MODOS_LOGINS", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
        }
    }

}

