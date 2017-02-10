using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class UsuariosNotificadosConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsuariosNotificados>
    {
        public UsuariosNotificadosConfiguration()
            : this("dbo")
        {
        }
        public UsuariosNotificadosConfiguration(string schema)
        {
            ToTable("TBL_USUARIOS_NOTIFICADOS", schema);
            HasKey(x => x.Id_Visto);
            Property(x => x.Id_Visto).HasColumnName(@"ID_VISTO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Id_Notificado).HasColumnName(@"ID_NOTIFICADO").IsRequired().HasColumnType("numeric");
            Property(x => x.Usuario).HasColumnName(@"USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Fecha_Visto).HasColumnName(@"FECHA_VISTO").IsOptional().HasColumnType("datetime");            
            Property(x => x.Nombre_Imagen_Vista).HasColumnName(@"NOMBRE_IMAGEN_VISTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Link_Direccionamiento).HasColumnName(@"LINK_DIRECCIONAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Descripcion_Imagen_Vista).HasColumnName(@"DESCRIPCION_IMAGEN_VISTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Aliado_Usuario).HasColumnName(@"ALIADO_USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Perfil_Usario).HasColumnName(@"PERFIL_USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Nombre_Linea_Usuario).HasColumnName(@"NOMBRE_LINEA_USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);

        }
    }
}
