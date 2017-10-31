#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class VAMotivosSolicitudConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VAMotivosSolicitud>
    {
        public VAMotivosSolicitudConfiguration()
            : this("dbo")
        { }
        public VAMotivosSolicitudConfiguration(string schema)
        {
            ToTable("TBL_VAM_MOTIVOS_SOLICITUD", schema);
            HasKey(x => new { x.IdMotivo });

            Property(x => x.IdMotivo).HasColumnName(@"ID_MOTIVO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Motivo).HasColumnName(@"MOTIVO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
