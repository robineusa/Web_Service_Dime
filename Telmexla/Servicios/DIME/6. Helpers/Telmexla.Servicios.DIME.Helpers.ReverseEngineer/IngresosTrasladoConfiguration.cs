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

    // TBL_INGRESOS_TRASLADOS
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class IngresosTrasladoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<IngresosTraslado>
    {
        public IngresosTrasladoConfiguration()
            : this("dbo")
        {
        }

        public IngresosTrasladoConfiguration(string schema)
        {
            ToTable("TBL_INGRESOS_TRASLADOS", schema);
            HasKey(x => x.IdTraslado);

            Property(x => x.IdTraslado).HasColumnName(@"ID_TRASLADO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsRequired().HasColumnType("numeric");
            Property(x => x.Direccion).HasColumnName(@"DIRECCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Estrato).HasColumnName(@"ESTRATO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(15);
            Property(x => x.TelefonoCelular).HasColumnName(@"TELEFONO_CELULAR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.TelefonoFijo).HasColumnName(@"TELEFONO_FIJO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.FechaApertura).HasColumnName(@"FECHA_APERTURA").IsOptional().HasColumnType("date");
            Property(x => x.HoraApertura).HasColumnName(@"HORA_APERTURA").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaCierre).HasColumnName(@"FECHA_CIERRE").IsOptional().HasColumnType("date");
            Property(x => x.HoraCierre).HasColumnName(@"HORA_CIERRE").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioApertura).HasColumnName(@"USUARIO_APERTURA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.UsuarioCierre).HasColumnName(@"USUARIO_CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaUltimaActualizacion).HasColumnName(@"FECHA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioUltimaActualizacion).HasColumnName(@"USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.HoraUltimaActualizacion).HasColumnName(@"HORA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.EstadoCaso).HasColumnName(@"ESTADO_CASO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.EstadoBackoffice).HasColumnName(@"ESTADO_BACKOFFICE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.UsuarioBackoffice).HasColumnName(@"USUARIO_BACKOFFICE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.FechaInicioGestionBackoffice).HasColumnName(@"FECHA_INICIO_GESTION_BACKOFFICE").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestionOutbound).HasColumnName(@"USUARIO_GESTION_OUTBOUND").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.FechaInicioGestionOutbound).HasColumnName(@"FECHA_INICIO_GESTION_OUTBOUND").IsOptional().HasColumnType("datetime");
            Property(x => x.AliadoApertura).HasColumnName(@"ALIADO_APERTURA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreLineaIngreso).HasColumnName(@"NOMBRE_LINEA_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreLineaEscalado).HasColumnName(@"NOMBRE_LINEA_ESCALADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.IngresosTraslado1).WithOptional(b => b.IngresosTraslado2).WillCascadeOnDelete(false); // FK__TBL_INGRE__ID_TR__19DFD96B
            HasRequired(a => a.IngresosTraslado3).WithOptional(b => b.IngresosTraslado4).WillCascadeOnDelete(false); // FK__TBL_INGRE__ID_TR__1CBC4616
        }
    }

}
// </auto-generated>
