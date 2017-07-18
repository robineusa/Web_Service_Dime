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

    // TBL_CC_RESIDENCIAL_PREDICTIVO_INFO
    public class CcResidencialPredictivoInfoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CcResidencialPredictivoInfo>
    {
        public CcResidencialPredictivoInfoConfiguration()
            : this("dbo")
        {
        }

        public CcResidencialPredictivoInfoConfiguration(string schema)
        {
            ToTable("TBL_CC_RESIDENCIAL_PREDICTIVO_INFO", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsOptional().HasColumnType("float");
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Direccion).HasColumnName(@"DIRECCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.NotasDeExperto).HasColumnName(@"NOTAS_DE_EXPERTO").IsOptional().HasColumnType("float");
            Property(x => x.Comunidad).HasColumnName(@"COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.EstadoInicial).HasColumnName(@"ESTADO_INICIAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CuentaMatriz).HasColumnName(@"CUENTA_MATRIZ").IsOptional().HasColumnType("float");
            Property(x => x.ProblemaDelEdificio).HasColumnName(@"PROBLEMA_DEL_EDIFICIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(300);
            Property(x => x.ServicioAfectado).HasColumnName(@"SERVICIO_AFECTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Telefono1).HasColumnName(@"TELEFONO1").IsOptional().HasColumnType("float");
            Property(x => x.Telefono2).HasColumnName(@"TELEFONO2").IsOptional().HasColumnType("float");
            Property(x => x.Telefono3).HasColumnName(@"TELEFONO3").IsOptional().HasColumnType("float");
            Property(x => x.Celular).HasColumnName(@"CELULAR").IsOptional().HasColumnType("float");
            Property(x => x.Celular2).HasColumnName(@"CELULAR2").IsOptional().HasColumnType("float");
            Property(x => x.MarcacionBd).HasColumnName(@"Marcacion_BD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.MarcacionBdIi).HasColumnName(@"Marcacion_BD_II").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.LoginId).HasColumnName(@"Login_ID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(150);
        }
    }

}
// </auto-generated>
