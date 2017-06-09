// <auto-generated>
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

namespace Telmexla.Servicios.DIME.Helpers.ReverseEngineer
{

    // TBL_LOG_DOCSIS_OVERLAP
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class LogDocsisOverlapConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<LogDocsisOverlap>
    {
        public LogDocsisOverlapConfiguration()
            : this("dbo")
        {
        }

        public LogDocsisOverlapConfiguration(string schema)
        {
            ToTable("TBL_LOG_DOCSIS_OVERLAP", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.OperacionGestion).HasColumnName(@"OPERACION_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreBase).HasColumnName(@"NOMBRE_BASE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("float");
            Property(x => x.NombreCliente).HasColumnName(@"NOMBRE_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ApellidoCliente).HasColumnName(@"APELLIDO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DireccionInstalacion).HasColumnName(@"DIRECCION_INSTALACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.DireccionCorrespondencia).HasColumnName(@"DIRECCION_CORRESPONDENCIA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.CorreoElectronico).HasColumnName(@"CORREO_ELECTRONICO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Telefono1).HasColumnName(@"TELEFONO_1").IsOptional().HasColumnType("numeric");
            Property(x => x.Telefono2).HasColumnName(@"TELEFONO_2").IsOptional().HasColumnType("numeric");
            Property(x => x.Telefono3).HasColumnName(@"TELEFONO_3").IsOptional().HasColumnType("numeric");
            Property(x => x.Movil1).HasColumnName(@"MOVIL_1").IsOptional().HasColumnType("numeric");
            Property(x => x.Movil2).HasColumnName(@"MOVIL_2").IsOptional().HasColumnType("numeric");
            Property(x => x.PaqueteActual).HasColumnName(@"PAQUETE_ACTUAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(15);
            Property(x => x.TipoDeContacto).HasColumnName(@"TIPO_DE_CONTACTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Cierre).HasColumnName(@"CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Aliado).HasColumnName(@"ALIADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Seguimiento).HasColumnName(@"SEGUIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.FechaSeguimiento).HasColumnName(@"FECHA_SEGUIMIENTO").IsOptional().HasColumnType("datetime");
        }
    }

}
// </auto-generated>
