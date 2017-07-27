#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class NodosZonificadosConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NodosZonificados>
    {
        public NodosZonificadosConfiguration()
            : this("dbo")
        { }
        public NodosZonificadosConfiguration(string schema)
        {
            ToTable("TBL_NODOS_ZONIFICADOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdDivisional).HasColumnName(@"ID_DIVISIONAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Divisional).HasColumnName(@"DIVISIONAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdArea).HasColumnName(@"ID_AREA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Area).HasColumnName(@"AREA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdZona).HasColumnName(@"ID_ZONA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Zona).HasColumnName(@"ZONA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdDistrito).HasColumnName(@"ID_DISTRITO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Distrito).HasColumnName(@"DISTRITO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdUd).HasColumnName(@"ID_UD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UnidadGestion).HasColumnName(@"UNIDAD_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreNodo).HasColumnName(@"NOMBRENODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdNodo).HasColumnName(@"ID_NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdUnidad).HasColumnName(@"ID_UNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Red).HasColumnName(@"RED").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreUnidadGestion).HasColumnName(@"NOMBRE_UNIDAD_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.RentaUnidadGestion).HasColumnName(@"RANGO_RENTA_UG").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdEmpresa).HasColumnName(@"ID_EMPRESA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Empresa).HasColumnName(@"EMPRESA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdDivision).HasColumnName(@"ID_DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdComunidad).HasColumnName(@"ID_COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DscDivision).HasColumnName(@"DSC_DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DscComunidad).HasColumnName(@"DSC_COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estrato).HasColumnName(@"ESTRATO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoZonificado).HasColumnName(@"ALIADO_ZONIFICADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoLls).HasColumnName(@"ALIADO_LLS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoRe).HasColumnName(@"ALIADO_RE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Regional).HasColumnName(@"REGIONAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaActivacion).HasColumnName(@"FECHA_ACTIVACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ObservacionesAdicionales).HasColumnName(@"OBSERVACIONES_ADICIONALES").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Regional2).HasColumnName(@"REGIONAL2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
