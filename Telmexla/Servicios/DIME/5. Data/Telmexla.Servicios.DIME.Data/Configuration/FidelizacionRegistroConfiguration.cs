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
    //TBL_FID_OTROS_OFRECIMIENTOS
    public class FidelizacionRegistroConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FidelizacionRegistro>
    {
        public FidelizacionRegistroConfiguration()
            : this("dbo")
        {
        }

        public FidelizacionRegistroConfiguration(string schema)
        {
            ToTable("TBL_FID_REGISTRO", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("numeric");
            Property(x => x.DiaCorte).HasColumnName(@"DIA_CORTE").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaCorte).HasColumnName(@"FECHA_CORTE").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaRegistro).HasColumnName(@"FECHA_REGISTRO").IsRequired().HasColumnType("datetime");
            Property(x => x.Notas).HasColumnName(@"NOTAS").IsOptional().HasColumnType("varchar").HasMaxLength(5000);
            Property(x => x.OtrosOfrecimientosId).HasColumnName(@"OTROS_OFRECIMIENTOS_ID").IsOptional().HasColumnType("numeric");
            Property(x => x.Permanencia).HasColumnName(@"PERMANENCIA").IsOptional().HasColumnType("varchar");
            Property(x => x.RecursivaId).HasColumnName(@"RECURSIVA_ID").IsOptional().HasColumnType("decimal");
            Property(x => x.ServiciosId).HasColumnName(@"SERVICIOS_ID").IsRequired().HasColumnType("varchar");
            Property(x => x.ServiciosRetenidosId).HasColumnName(@"SERVICIOS_RETENIDOS_ID").IsOptional().HasColumnType("varchar");
            Property(x => x.SubmotivoId).HasColumnName(@"SUBMOTIVO_ID").IsRequired().HasColumnType("decimal");
            Property(x => x.TipificacionId).HasColumnName(@"TIPIFICACION_ID").IsOptional().HasColumnType("decimal");
            Property(x => x.UsuarioId).HasColumnName(@"USUARIO_ID").IsRequired().HasColumnType("int");
        }
    }
}
