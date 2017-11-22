#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class RSMArbolesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RSMArboles>
    {
        public RSMArbolesConfiguration()
            : this("dbo")
        { }
        public RSMArbolesConfiguration(string schema)
        {
            ToTable("TBL_RSM_ARBOLES", schema);
            HasKey(x => new { x.IdArbol });

            Property(x => x.IdArbol).HasColumnName(@"ID_ARBOL").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdPadre).HasColumnName(@"ID_PADRE").IsOptional().HasColumnType("numeric");
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            }
    }
}
