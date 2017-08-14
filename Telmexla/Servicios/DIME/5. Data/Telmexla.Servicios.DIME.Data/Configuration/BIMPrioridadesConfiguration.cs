#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BIMPrioridadesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BIMPrioridades>
    {
        public BIMPrioridadesConfiguration()
            : this("dbo")
        { }
        public BIMPrioridadesConfiguration(string schema)
        {
            ToTable("TBL_BIM_PRIORIDADES", schema);
            HasKey(x => new { x.IdPrioridad });

            Property(x => x.IdPrioridad).HasColumnName(@"ID_PRIORIDAD").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
