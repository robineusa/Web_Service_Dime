#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class CEPTicketsConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CEPTickets>
    {
        public CEPTicketsConfiguration()
            : this("dbo")
        {
        }

        public CEPTicketsConfiguration(string schema)
        {
            ToTable("TBL_CEP_TICKETS", schema);
            HasKey(x => new { x.IdGestion });

            Property(x => x.IdGestion).HasColumnName(@"ID_GESTION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaDeGestion).HasColumnName(@"FECHA_DE_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioDeGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CanaldeIngreso).HasColumnName(@"CANAL_DE_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.NumeroDeTicket).HasColumnName(@"NUMERO_DE_TICKET").IsOptional().HasColumnType("numeric");
            Property(x => x.UsuarioDeCreacion).HasColumnName(@"USUARIO_DE_CREACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeCreacion).HasColumnName(@"FECHA_DE_CREACION").IsOptional().HasColumnType("datetime");
            Property(x => x.Srcaus).HasColumnName(@"SRCAUS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Srreas).HasColumnName(@"SRREAS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nota1).HasColumnName(@"NOTA_1").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota2).HasColumnName(@"NOTA_2").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Ajuste).HasColumnName(@"AJUSTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeCancelacion).HasColumnName(@"FECHA_DE_CANCELACION").IsOptional().HasColumnType("datetime");
            Property(x => x.MarcacionCancelacion).HasColumnName(@"MARCACION_DE_CANCELACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsuarioDeCancelacion).HasColumnName(@"USUARIO_DE_CANCELACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsuarioDeRetencion).HasColumnName(@"USUARIO_RETENCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            
        }
    }
}
