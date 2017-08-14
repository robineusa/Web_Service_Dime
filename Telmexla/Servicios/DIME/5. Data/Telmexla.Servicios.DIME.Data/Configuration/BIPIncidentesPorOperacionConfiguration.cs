#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BIPIncidentesPorOperacionConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BIPIncidentesPorOperacion>
    {
        public BIPIncidentesPorOperacionConfiguration()
            : this("dbo")
        { }
        public BIPIncidentesPorOperacionConfiguration(string schema)
        {
            ToTable("TBL_BIP_INCIDENTES_POR_OPERACION", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdRegistro).HasColumnName(@"ID_REGISTRO").IsOptional().HasColumnType("numeric");
            Property(x => x.IdGerencia).HasColumnName(@"ID_GERENCIA").IsOptional().HasColumnType("numeric");
            Property(x => x.IdAliado).HasColumnName(@"ID_ALIADO").IsOptional().HasColumnType("numeric");
            Property(x => x.IdOperacion).HasColumnName(@"ID_OPERACION").IsOptional().HasColumnType("numeric");
        }
    }
}
