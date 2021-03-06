// <auto-generated>
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

namespace Telmexla.Servicios.DIME.Helpers.ReverseEngineer
{

    // TBL_USUARIOS_NOTIFICADOS
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class UsuariosNotificadoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsuariosNotificado>
    {
        public UsuariosNotificadoConfiguration()
            : this("dbo")
        {
        }

        public UsuariosNotificadoConfiguration(string schema)
        {
            ToTable("TBL_USUARIOS_NOTIFICADOS", schema);
            HasKey(x => x.IdVisto);

            Property(x => x.IdVisto).HasColumnName(@"ID_VISTO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdNotificado).HasColumnName(@"ID_NOTIFICADO").IsOptional().HasColumnType("numeric");
            Property(x => x.Usuario).HasColumnName(@"USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.FechaVisto).HasColumnName(@"FECHA_VISTO").IsOptional().HasColumnType("datetime");
            Property(x => x.NombreImagenVista).HasColumnName(@"NOMBRE_IMAGEN_VISTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.LinkDireccionamiento).HasColumnName(@"LINK_DIRECCIONAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.DescripcionImagenVista).HasColumnName(@"DESCRIPCION_IMAGEN_VISTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.AliadoUsuario).HasColumnName(@"ALIADO_USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PerfilUsuario).HasColumnName(@"PERFIL_USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.NombreLineaUsuario).HasColumnName(@"NOMBRE_LINEA_USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
        }
    }

}
// </auto-generated>
