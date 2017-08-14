#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BIMOperacionesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BIMOperaciones>
    {
        public BIMOperacionesConfiguration()
            : this("dbo")
        { }
        public BIMOperacionesConfiguration(string schema)
        {
            ToTable("TBL_BIM_OPERACIONES", schema);
            HasKey(x => new { x.IdOperacion });

            Property(x => x.IdOperacion).HasColumnName(@"ID_OPERACION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdGerencia).HasColumnName(@"ID_GERENCIA").IsOptional().HasColumnType("numeric");
            Property(x => x.IdAliado).HasColumnName(@"ID_ALIADO").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreOperacion).HasColumnName(@"NOMBRE_OPERACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
