#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MecListasDistribucionConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MecListasDistribucion>
    {
        public MecListasDistribucionConfiguration()
           : this("dbo")
        { }
        public MecListasDistribucionConfiguration(string schema)
        {
            ToTable("TBL_MEC_LISTA_DISTRUCIONES", schema);
            HasKey(x => new { x.IdLista });

            Property(x => x.IdLista).HasColumnName(@"ID_LISTA").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdLinea).HasColumnName(@"ID_LINEA").IsOptional().HasColumnType("numeric");
            Property(x => x.Destinatarios).HasColumnName(@"DESTINATARIOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
