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
    public class CuentasSiguienteMejorOfertaConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CuentasSiguienteMejorOferta>
    {
        public CuentasSiguienteMejorOfertaConfiguration()
            : this("dbo")
        {
        }

        public CuentasSiguienteMejorOfertaConfiguration(string schema)
        {
            ToTable("TBL_CUENTAS_MEJOR_OFERTA", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA").IsRequired().HasColumnType("numeric");
            Property(x => x.Ofrecimiento1).HasColumnName(@"OFRECIMIENTO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Ofrecimiento2).HasColumnName(@"OFRECIMIENTO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Ofrecimiento3).HasColumnName(@"OFRECIMIENTO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}
