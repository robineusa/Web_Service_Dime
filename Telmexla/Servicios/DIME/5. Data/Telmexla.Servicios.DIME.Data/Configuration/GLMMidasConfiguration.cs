using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class GLMMidasConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GLMMidas>
    {
        public GLMMidasConfiguration()
            : this("dbo")
        {
        }

        public GLMMidasConfiguration(string schema)
        {
            ToTable("TBL_GLM_MIDAS", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdGestionPrincipal).HasColumnName(@"ID_GESTION_PRINCIPAL").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_DE_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Cierre).HasColumnName(@"CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Motivo).HasColumnName(@"MOTIVO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FallaServPrincipalesSoporte).HasColumnName(@"FALLA_SERV_PRINCIPALES_SOPORTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FallaServAdicionalesSoporte).HasColumnName(@"FALLA_SERV_ADICIONALES_SOPORTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoFallaSoporte).HasColumnName(@"TIPO_FALLA_SOPORTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SolucionEspecificaSoporte).HasColumnName(@"SOLUCION_ESPECIFICA_SOPORTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoSoporte).HasColumnName(@"ESTADO_SOPORTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaSeguimientoSoporte).HasColumnName(@"FECHA_SEGUIMIENTO_SOPORTE").IsOptional().HasColumnType("datetime");
            Property(x => x.ObservacionesSoporte).HasColumnName(@"OBSERVACIONES_SOPORTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.ProblemaFacturacion).HasColumnName(@"PROBLEMA_FACTURACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SolucionFacturacion).HasColumnName(@"SOLUCION_FACTURACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoFacturacion).HasColumnName(@"ESTADO_FACTURACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaSeguimientoFacturacion).HasColumnName(@"FECHA_SEGUIMIENTO_FACTURACION").IsOptional().HasColumnType("datetime");
            Property(x => x.ObservacionesFacturacion).HasColumnName(@"OBSERVACIONES_FACTURACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.ClienteIntencionCancelacion).HasColumnName(@"CLIENTE_INTENCION_CANCELACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MotivoCancelacion).HasColumnName(@"MOTIVO_CANCELACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.RazonCancelacion).HasColumnName(@"RAZON_CANCELACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ObservacionesCancelacion).HasColumnName(@"OBSERVACIONES_CANCELACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Ofrecimiento1).HasColumnName(@"OFRECIMIENTO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.AceptacionOfrecimiento1).HasColumnName(@"ACEPTACION_OFRECIMIENTO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Ofrecimiento2).HasColumnName(@"OFRECIMIENTO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.AceptacionOfrecimiento2).HasColumnName(@"ACEPTACION_OFRECIMIENTO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Ofrecimiento3).HasColumnName(@"OFRECIMIENTO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.AceptacionOfrecimiento3).HasColumnName(@"ACEPTACION_OFRECIMIENTO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Campaña1).HasColumnName(@"CAMPAÑA_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Campaña2).HasColumnName(@"CAMPAÑA_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Campaña3).HasColumnName(@"CAMPAÑA_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.EstadoCaso).HasColumnName(@"ESTADO_CASO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
