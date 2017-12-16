#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;
namespace Telmexla.Servicios.DIME.Data
{
    public class CELDesconexionesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CELDesconexiones>
    {
        public CELDesconexionesConfiguration()
            : this("dbo")
        {
        }

        public CELDesconexionesConfiguration(string schema)
        {
            ToTable("TBL_CEL_DESCONEXIONES", schema);
            HasKey(x => new { x.IdTransaccion });

            Property(x => x.IdTransaccion).HasColumnName(@"ID_TRANSACCION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdGestion).HasColumnName(@"ID_GESTION").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaDeTransaccion).HasColumnName(@"FECHA_DE_TRANSACCION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioDeTransaccion).HasColumnName(@"USUARIO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreUsuarioTransaccion).HasColumnName(@"NOMBRE_USUARIO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CanalDeIngreso).HasColumnName(@"CANAL_DE_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.MotivoDeDesconexion).HasColumnName(@"MOTIVO_DESCONEXION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Codigo).HasColumnName(@"CODIGO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nota1).HasColumnName(@"NOTA_1").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota2).HasColumnName(@"NOTA_2").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota3).HasColumnName(@"NOTA_3").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota4).HasColumnName(@"NOTA_4").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota5).HasColumnName(@"NOTA_5").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Red).HasColumnName(@"RED").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Servicios).HasColumnName(@"SERVICIOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeSolicitud).HasColumnName(@"FECHA_DE_SOLICITUD").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaDeCorte).HasColumnName(@"FECHA_DE_CORTE").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaDePreaviso).HasColumnName(@"FECHA_DE_PREAVISO").IsOptional().HasColumnType("datetime");
            Property(x => x.DiaDeDesconexion).HasColumnName(@"DIA_DE_DESCONEXION").IsOptional().HasColumnType("numeric");
            Property(x => x.TarifaAnterior).HasColumnName(@"TARIFA_ANTERIOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeAsignacion).HasColumnName(@"FECHA_DE_ASIGNACION").IsOptional().HasColumnType("datetime");
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeSeguimiento).HasColumnName(@"FECHA_SEGUIMIENTO").IsOptional().HasColumnType("datetime");
            Property(x => x.MovieLetter).HasColumnName(@"MOVIE_LETTER").IsOptional().HasColumnType("numeric");
            Property(x => x.Ajuste).HasColumnName(@"AJUSTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CantidadServicio).HasColumnName(@"CANTIDAD_DE_SERVICIOS").IsOptional().HasColumnType("numeric");
            Property(x => x.ErrorSolicitud).HasColumnName(@"ERROR_DE_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsuarioSolicitud).HasColumnName(@"USUARIO_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoDeError).HasColumnName(@"TIPO_DE_ERROR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().HasColumnType("varchar");
        }
    }
}
