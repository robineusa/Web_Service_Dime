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

    // TBL_USUARIOS
    public class UsuarioConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
            : this("dbo")
        {
        }

        public UsuarioConfiguration(string schema)
        {
            ToTable("TBL_USUARIOS", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Cedula).HasColumnName(@"CEDULA").IsOptional().HasColumnType("numeric");
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.Contrasena).HasColumnName(@"CONTRASENA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(300);
        }
    }

}

