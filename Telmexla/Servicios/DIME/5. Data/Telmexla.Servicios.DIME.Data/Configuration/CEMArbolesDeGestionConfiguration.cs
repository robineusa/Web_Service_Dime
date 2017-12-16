#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data
{
    public class CEMArbolesDeGestionConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CEMArbolesDeGestion>
    {
        public CEMArbolesDeGestionConfiguration()
            : this("dbo")
        { }
        public CEMArbolesDeGestionConfiguration(string schema)
        {
            ToTable("TBL_CEM_ARBOLES", schema);
            HasKey(x => new { x.IdArbol });

            Property(x => x.IdArbol).HasColumnName(@"ID_ARBOL").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdPadre).HasColumnName(@"ID_PADRE").IsOptional().HasColumnType("numeric");
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoDeGestion).HasColumnName(@"ESTADO_DE_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoArbol).HasColumnName(@"ESTADO_ARBOL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
