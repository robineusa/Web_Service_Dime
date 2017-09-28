#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class VIPSolicitudesPorEquipoConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VIPSolicitudesPorEquipo>
    {
        public VIPSolicitudesPorEquipoConfiguration() : this("dbo") { }
        public VIPSolicitudesPorEquipoConfiguration(string schema)
        {
            ToTable("TBL_VIP_SOLICITUDES_X_EQUIPOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdSolicitud).HasColumnName(@"ID_SOLICITUD").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoDeEquipo).HasColumnName(@"TIPO_DE_EQUIPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Mac).HasColumnName(@"MAC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Tarjeta).HasColumnName(@"TARJETA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

        }
    }
}
