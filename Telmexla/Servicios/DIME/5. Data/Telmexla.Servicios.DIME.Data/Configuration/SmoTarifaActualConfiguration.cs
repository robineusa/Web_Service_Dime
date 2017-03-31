// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{


    // TBL_SMO_TARIFA_ACTUAL
    public class SmoTarifaActualConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SmoTarifaActual>
    {
        public SmoTarifaActualConfiguration()
            : this("dbo")
        {
        }

        public SmoTarifaActualConfiguration(string schema)
        {
            ToTable("TBL_SMO_TARIFA_ACTUAL", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NombreTarifa).HasColumnName(@"NOMBRE_TARIFA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estrato).HasColumnName(@"ESTRATO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.CodTarifaRes).HasColumnName(@"COD_TARIFA_RES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CodTarifaSoho).HasColumnName(@"COD_TARIFA_SOHO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoInternet).HasColumnName(@"TIPO_INTERNET").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoTv).HasColumnName(@"TIPO_TV").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Voz).HasColumnName(@"VOZ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Paquete).HasColumnName(@"PAQUETE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ProductoPaq).HasColumnName(@"PRODUCTO_PAQ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.RentaPromocion).HasColumnName(@"RENTA_PROMOCION").IsOptional().HasColumnType("numeric");
            Property(x => x.RentaTotal).HasColumnName(@"RENTA_TOTAL").IsOptional().HasColumnType("numeric");
            Property(x => x.IncluyeHd).HasColumnName(@"INCLUYE_HD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IncluyePvr).HasColumnName(@"INCLUYE_PVR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.InclyeClarovideo).HasColumnName(@"INCLYE_CLAROVIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Periodo).HasColumnName(@"PERIODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Tarifa).HasColumnName(@"TARIFA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }

}
// </auto-generated>
