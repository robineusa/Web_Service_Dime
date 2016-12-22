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
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Contrasena).HasColumnName(@"CONTRASENA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(300);
            Property(x => x.Genero).HasColumnName(@"GENERO").IsOptional().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(1);
            Property(x => x.Correo).HasColumnName(@"CORREO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.FechaNacimiento).HasColumnName(@"FECHA_NACIMIENTO").IsOptional().HasColumnType("date");
            Property(x => x.Telefono).HasColumnName(@"TELEFONO").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaContrasena).HasColumnName(@"FECHA_CONTRASENA").IsOptional().HasColumnType("date");
            Property(x => x.Capacitado).HasColumnName(@"Capacitado").IsOptional().HasColumnType("bit");
            Property(x => x.Aliado).HasColumnName(@"ALIADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.IdLinea).HasColumnName(@"ID_LINEA").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.Linea).WithMany(b => b.Usuarios).HasForeignKey(c => c.IdLinea).WillCascadeOnDelete(false); // FK__TBL_USUAR__ID_LI__0E6E26BF
        }
    }

}
