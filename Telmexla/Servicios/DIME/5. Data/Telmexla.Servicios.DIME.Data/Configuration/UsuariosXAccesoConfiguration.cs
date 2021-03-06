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

    // TBL_USUARIOS_X_ACCESOS
    public class UsuariosXAccesoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsuariosXAcceso>
    {
        public UsuariosXAccesoConfiguration()
            : this("dbo")
        {
        }

        public UsuariosXAccesoConfiguration(string schema)
        {
            ToTable("TBL_USUARIOS_X_ACCESOS", schema);
            HasKey(x => new { x.Id, x.IdAcceso, x.IdUsuario });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdUsuario).HasColumnName(@"ID_USUARIO").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdAcceso).HasColumnName(@"ID_ACCESO").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdUserCambioo).HasColumnName(@"ID_USER_CAMBIOO").IsOptional().HasColumnType("int");
            Property(x => x.FechaCreacion).HasColumnName(@"FECHA_CREACION").IsOptional().HasColumnType("date");
            Property(x => x.HoraCreacion).HasColumnName(@"HORA_CREACION").IsOptional().HasColumnType("time");
            Property(x => x.IpPublicaCreacion).HasColumnName(@"IP_PUBLICA_CREACION").IsOptional().HasColumnType("nvarchar").HasMaxLength(15);
            Property(x => x.IpPrivadaCreacion).HasColumnName(@"IP_PRIVADA_CREACION").IsOptional().HasColumnType("nvarchar").HasMaxLength(15);

            // Foreign keys
            HasRequired(a => a.Acceso).WithMany(b => b.UsuariosXAccesoes).HasForeignKey(c => c.IdAcceso).WillCascadeOnDelete(false); // FK__TBL_USUAR__ID_AC__36B12243
            HasRequired(a => a.Usuario).WithMany(b => b.UsuariosXAccesoes).HasForeignKey(c => c.IdUsuario).WillCascadeOnDelete(false); // FK__TBL_USUAR__ID_US__37A5467C
        }
    }

}
