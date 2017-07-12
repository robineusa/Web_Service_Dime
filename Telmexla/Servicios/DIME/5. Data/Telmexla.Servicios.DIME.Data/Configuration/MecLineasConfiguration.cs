#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;
namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MecLineasConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MecLineas>
    {
        public MecLineasConfiguration()
           : this("dbo")
        { }
        public MecLineasConfiguration(string schema)
        {
            ToTable("TBL_MEC_NOMBRE_LINEAS", schema);
            HasKey(x => new { x.IdLinea });

            Property(x => x.IdLinea).HasColumnName(@"ID_LINEA").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdProceso).HasColumnName(@"ID_PROCESO").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreLinea).HasColumnName(@"NOMBRE_DE_LINEA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
