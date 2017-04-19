


using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
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
            ToTable("TBL_TRANSACCIONES_TRASLADOS", schema);
            HasKey(x => x.IdTransaccion);

            Property(x => x.IdTransaccion).HasColumnName(@"ID_TRANSACCION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoGestion).HasColumnName(@"TIPO_DE_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.FechaApertura).HasColumnName(@"FECHA_APERTURA").IsOptional().HasColumnType("date");
            Property(x => x.HoraApertura).HasColumnName(@"HORA_APERTURA").IsOptional().HasColumnType("date");
            Property(x => x.FechaCierre).HasColumnName(@"FECHA_CIERRE").IsOptional().HasColumnType("date");
            Property(x => x.HoraCierre).HasColumnName(@"HORA_CIERRE").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioApertura).HasColumnName(@"USUARIO_APERTURA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.UsuarioCierre).HasColumnName(@"USUARIO_CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaUltimaActualizacion).HasColumnName(@"FECHA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("date");
            Property(x => x.HoraUltimaActualizacion).HasColumnName(@"HORA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioUltimaActualizacion).HasColumnName(@"USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.EstadoTransaccion).HasColumnName(@"ESTADO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.AliadoApertura).HasColumnName(@"ALIADO_APERTURA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreLineaIngreso).HasColumnName(@"NOMBRE_LINEA_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreLineaEscalado).HasColumnName(@"NOMBRE_LINEA_ESCALADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            }

    }
}
