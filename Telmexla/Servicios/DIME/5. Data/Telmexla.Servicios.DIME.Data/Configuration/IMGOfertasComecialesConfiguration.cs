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

            Property(x => x.IdImagen).HasColumnName(@"ID_SOLICITUD").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Imagen).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("byte");
            Property(x => x.Link).HasColumnName(@"LLSOT").IsOptional().HasColumnType("numeric");
            Property(x => x.Descripcion).HasColumnName(@"TIPO_DE_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"DETALLE_DE_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaCreacion).HasColumnName(@"FECHA_DE_SOLICITUD").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioCreacion).HasColumnName(@"USUARIO_QUE_SOLICTA").IsOptional().HasColumnType("numeric");
        }
    }
}
