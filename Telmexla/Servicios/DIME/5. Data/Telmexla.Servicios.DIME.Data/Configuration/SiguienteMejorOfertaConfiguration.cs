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

namespace Telmexla.Servicios.DIME.Data
{
    public class SiguienteMejorOfertaConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SiguienteMejorOferta>
    {
        public SiguienteMejorOfertaConfiguration()
            : this("dbo")
        {
        }

        public SiguienteMejorOfertaConfiguration(string schema)
        {
            ToTable("TBL_VENTAS_SMO_INBOUND", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA").IsRequired().HasColumnType("numeric");
            Property(x => x.Ofrecimiento1).HasColumnName(@"OFRECIMIENTO_1").IsRequired().HasColumnType("numeric");
            Property(x => x.Ofrecimiento2).HasColumnName(@"OFRECIMIENTO_2").IsRequired().HasColumnType("numeric");
            Property(x => x.Ofrecimiento3).HasColumnName(@"OFRECIMIENTO_3").IsRequired().HasColumnType("numeric");
            Property(x => x.TipoContacto).HasColumnName(@"TIPO_CONTACTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Cierre).HasColumnName(@"CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Observaciones).HasColumnName(@"OBERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
        }
    }
}
