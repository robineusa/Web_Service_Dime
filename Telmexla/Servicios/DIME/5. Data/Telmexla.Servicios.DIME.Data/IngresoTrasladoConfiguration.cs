

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data
{
    //TBL_INGRESOS_TRASLADOS
    public class IngresoTrasladoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<IngresoTraslado>
    {
        public IngresoTrasladoConfiguration()
            : this("dbo")
        {
        }
        public IngresoTrasladoConfiguration(string schema)
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
            Property(x => x.HoraApertura).HasColumnName(@"HORA_APERTURA").IsOptional().HasColumnType("date");
            Property(x => x.FechaCierre).HasColumnName(@"FECHA_CIERRE").IsOptional().HasColumnType("date");
            Property(x => x.HoraCierre).HasColumnName(@"HORA_CIERRE").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioApertura).HasColumnName(@"USUARIO_APERTURA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.UsuarioCierre).HasColumnName(@"USUARIO_CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaUltimaActualizacion).HasColumnName(@"FECHA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioUltimaActualizacion).HasColumnName(@"USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.HoraUltimaActualizacion).HasColumnName(@"HORA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("date");
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.EstadoCaso).HasColumnName(@"ESTADO_CASO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.EstadoBackoffice).HasColumnName(@"ESTADO_BACKOFFICE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.UsuarioBackoffice).HasColumnName(@"USUARIO_BACKOFFICE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.UsuarioCierre).HasColumnName(@"USUARIO_CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaInicioGestionBackoffice).HasColumnName(@"FECHA_INICIO_GESTION_BACKOFFICE").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioGestionOutbound).HasColumnName(@"USUARIO_GESTION_OUTBOUND").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.FechaInicioGestionOutbound).HasColumnName(@"FECHA_INICIO_GESTION_OUTBOUND").IsOptional().HasColumnType("date");
            Property(x => x.AliadoApertura).HasColumnName(@"ALIADO_APERTURA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreLineaIngreso).HasColumnName(@"NOMBRE_LINEA_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreLineaEscalado).HasColumnName(@"NOMBRE_LINEA_ESCALADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            }

    }
}
