#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MecTipoAlarmasConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MecTipoAlarmas>
    {
        public MecTipoAlarmasConfiguration()
           : this("dbo")
        { }
        public MecTipoAlarmasConfiguration(string schema)
        {
            ToTable("TBL_MEC_TIPO_ALARMAS", schema);
            HasKey(x => new { x.IdAlarma });

            Property(x => x.IdAlarma).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NombreAlarma).HasColumnName(@"NOMBRE_TIPO_ALARMA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

        }
    }
}
