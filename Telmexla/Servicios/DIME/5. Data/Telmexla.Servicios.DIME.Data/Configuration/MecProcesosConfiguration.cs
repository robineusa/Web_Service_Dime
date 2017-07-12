#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;
namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MecProcesosConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MecProcesos>
    {
        public MecProcesosConfiguration()
           : this("dbo")
        { }
        public MecProcesosConfiguration(string schema) {
            ToTable("TBL_MEC_PROCESOS", schema);
            HasKey(x => new { x.IdProceso });

            Property(x => x.IdProceso).HasColumnName(@"ID_PROCESO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Proceso).HasColumnName(@"NOMBRE_PROCESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
