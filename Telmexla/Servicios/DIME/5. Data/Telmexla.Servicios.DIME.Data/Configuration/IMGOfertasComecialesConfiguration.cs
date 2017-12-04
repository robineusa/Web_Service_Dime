#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class IMGOfertasComecialesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<IMGOfertasComeciales>
    {
        public IMGOfertasComecialesConfiguration()
            : this("dbo")
        { }
        public IMGOfertasComecialesConfiguration(string schema)
        {
            ToTable("TBL_IMG_OFERTAS_COMERCIALES", schema);
            HasKey(x => new { x.IdImagen });

            Property(x => x.IdImagen).HasColumnName(@"ID_IMAGEN").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Imagen).HasColumnName(@"IMAGEN").IsOptional();
            Property(x => x.Link).HasColumnName(@"LINK").IsOptional().HasColumnType("varchar");
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaCreacion).HasColumnName(@"FECHA_CREACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioCreacion).HasColumnName(@"USUARIO_CREACION").IsOptional().HasColumnType("numeric");
        }
    }
}
