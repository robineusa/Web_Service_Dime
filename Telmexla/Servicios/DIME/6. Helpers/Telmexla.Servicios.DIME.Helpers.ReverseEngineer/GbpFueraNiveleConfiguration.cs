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

    // TBL_GBP_FUERA_NIVELES
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class GbpFueraNiveleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GbpFueraNivele>
    {
        public GbpFueraNiveleConfiguration()
            : this("dbo")
        {
        }

        public GbpFueraNiveleConfiguration(string schema)
        {
            ToTable("TBL_GBP_FUERA_NIVELES", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreCliente).HasColumnName(@"NOMBRE_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ApellidoCliente).HasColumnName(@"APELLIDO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DireccionInstalacion).HasColumnName(@"DIRECCION_INSTALACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DireccionCorrespondencia).HasColumnName(@"DIRECCION_CORRESPONDENCIA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Telefono1).HasColumnName(@"TELEFONO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Telefono2).HasColumnName(@"TELEFONO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Telefono3).HasColumnName(@"TELEFONO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Movil1).HasColumnName(@"MOVIL_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Movil2).HasColumnName(@"MOVIL_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MovilPostpago).HasColumnName(@"MOVIL_POSTPAGO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CorreoActual).HasColumnName(@"CORREO_ACTUAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstratoCliente).HasColumnName(@"ESTRATO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ServiciosActuales).HasColumnName(@"SERVICIOS_ACTUALES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreComunidad).HasColumnName(@"NOMBRE_COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Division).HasColumnName(@"DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoCliente).HasColumnName(@"TIPO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DescripcionTpc).HasColumnName(@"DESCRIPCION_TPC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Cmts).HasColumnName(@"CMTS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoModem).HasColumnName(@"TIPO_MODEM").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().HasColumnType("int");
            Property(x => x.TipoDeContacto).HasColumnName(@"TIPO_DE_CONTACTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Cierre).HasColumnName(@"CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaSeguimiento).HasColumnName(@"FECHA_SEGUIMIENTO").IsOptional().HasColumnType("datetime");
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
        }
    }

}
// </auto-generated>
