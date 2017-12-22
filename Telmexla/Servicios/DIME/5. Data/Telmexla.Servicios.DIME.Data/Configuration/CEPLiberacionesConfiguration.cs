using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class CEPLiberacionesConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CEPLiberaciones>
    {
        public CEPLiberacionesConfiguration()
            : this("dbo")
        {
        }

        public CEPLiberacionesConfiguration(string schema)
        {
            ToTable("TBL_CEP_LIBERACIONES", schema);
            HasKey(x => x.IdGestion);

            Property(x => x.IdGestion).HasColumnName(@"ID_GESTION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_DE_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioDeGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.RegistroModulo).HasColumnName(@"REGISTRO_MODULO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CanalDeIngreso).HasColumnName(@"CANAL_DE_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsarioEscala).HasColumnName(@"USUARIO_ESCALA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NumeroServicios).HasColumnName(@"NUMERO_SERVICIOS").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaSolicitud).HasColumnName(@"FECHA_SOLICITUD").IsOptional().HasColumnType("datetime");
            Property(x => x.SolicitudModulo).HasColumnName(@"SOLICITUD_MODULO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.MotivoDesconexion).HasColumnName(@"MOTIVO_DESCONEXION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Vendedor).HasColumnName(@"VENDEDOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Grupo).HasColumnName(@"GRUPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MotivoLiberacion).HasColumnName(@"MOTIVO_LIBERACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsuarioQueLibero).HasColumnName(@"USUARIO_QUE_LIBERO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaSeguimiento).HasColumnName(@"FECHA_SEGUIMIENTO").IsOptional().HasColumnType("datetime");
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().HasColumnType("varchar");

        }
    }
}
