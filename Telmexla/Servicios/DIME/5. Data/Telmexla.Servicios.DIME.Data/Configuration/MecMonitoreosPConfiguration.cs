#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MecMonitoreosPConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MecMonitoreosP>
    {
        public MecMonitoreosPConfiguration()
            : this("dbo")
        { }
        public MecMonitoreosPConfiguration(string schema)
        {
            ToTable("TBL_MEC_MONITOREOS", schema);
            HasKey(x => new { x.IdMonitoreo });

            Property(x => x.IdMonitoreo).HasColumnName(@"ID_MONITOREO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CedulaUsuarioGestion).HasColumnName(@"CEDULA_USUARIO_GESTION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdProceso).HasColumnName(@"ID_PROCESO").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreProceso).HasColumnName(@"NOMBRE_PROCESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdLinea).HasColumnName(@"ID_LINEA").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreLinea).HasColumnName(@"NOMBRE_LINEA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsuarioMonitoreado).HasColumnName(@"USUARIO_MONITOREADO").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioMonitoreado).HasColumnName(@"NOMBRE_USUARIO_MONITOREADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperacionUsuarioMonitoreado).HasColumnName(@"OPERACION_USURIO_MONITOREADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoUsuarioMonitoreado).HasColumnName(@"ALIADO_USUARIO_MONITOREADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.Division).HasColumnName(@"DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Area).HasColumnName(@"AREA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Zona).HasColumnName(@"ZONA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Comunidad).HasColumnName(@"COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoCliente).HasColumnName(@"TIPO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DescripcionTipoCliente).HasColumnName(@"DESCRIPCION_TIPO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MarcacionRegistradaRR).HasColumnName(@"MARCACION_REGISTRADA_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MarcacionCorrectaRR).HasColumnName(@"MARCACION_CORRECTA_RR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CampoOpcional1).HasColumnName(@"CAMPO_OPCIONAL_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CampoOpcional2).HasColumnName(@"CAMPO_OPCIONAL_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CampoOpcional3).HasColumnName(@"CAMPO_OPCIONAL_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CampoOpcional4).HasColumnName(@"CAMPO_OPCIONAL_4").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CampoOpcional5).HasColumnName(@"CAMPO_OPCIONAL_5").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NotaObtenida).HasColumnName(@"NOTA_OBTENIDA").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoDeAlarma).HasColumnName(@"TIPO_DE_ALARMA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.RegistroMonitoreo).HasColumnName(@"REGISTRO_MONITOREO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MotivoAlarma).HasColumnName(@"MOTIVO_DE_ALARMA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AnalisisDeGestion).HasColumnName(@"ANALISIS_DE_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AccionEmprender).HasColumnName(@"ACCION_A_EMPRENDER").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EtiquetaDeLlamada).HasColumnName(@"ETIQUETA_DE_LLAMADA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IdListaDistribucion).HasColumnName(@"ID_LISTA_DISTRIBUCION").IsOptional().HasColumnType("numeric");
            Property(x => x.EstadoMonitoreo).HasColumnName(@"ESTADO_MONITOREO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
