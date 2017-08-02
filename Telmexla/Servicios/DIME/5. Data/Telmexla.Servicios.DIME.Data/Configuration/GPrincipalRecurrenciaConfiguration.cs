using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class GPrincipalRecurrenciaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GPrincipalRecurrencia>
    {
        public GPrincipalRecurrenciaConfiguration()
            : this("dbo")
        {
        }

        public GPrincipalRecurrenciaConfiguration(string schema)
        {
            //ToTable("TBL_GPR_RECURRENCIA", schema);
            //HasKey(x => x.Id);

            //Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            //Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("datetime");
            //Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            //Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            //Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            //Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("int");
            //Property(x => x.NombreCliente).HasColumnName(@"NOMBRE_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.ApellidoCliente).HasColumnName(@"APELLIDO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.Division).HasColumnName(@"DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.Area).HasColumnName(@"AREA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            //Property(x => x.Zona).HasColumnName(@"ZONA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            //Property(x => x.Marcaciones).HasColumnName(@"MARCACIONES").IsOptional().HasColumnType("int");
            //Property(x => x.FechaUltimaMarcacion).HasColumnName(@"FECHA_ULTIMA_MARCACION").IsOptional().HasColumnType("datetime");
            //Property(x => x.FechaUltimaGestion).HasColumnName(@"FECHA_ULTIMA_GESTION").IsOptional().HasColumnType("datetime");
            //Property(x => x.Telefono1).HasColumnName(@"TELEFONO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.Telefono2).HasColumnName(@"TELEFONO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.Telefono3).HasColumnName(@"TELEFONO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.TelefonoTelmex).HasColumnName(@"TELEFONO_TELMEX").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.IncluyeClaroVideo).HasColumnName(@"INCLUYE_CLARO_VIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            //Property(x => x.UsoClaroVideo).HasColumnName(@"USO_CLARO_VIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            //Property(x => x.ClienteNagra).HasColumnName(@"CLIENTE_NAGRA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            //Property(x => x.Ofrecimiento1).HasColumnName(@"OFRECIMIENTO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            //Property(x => x.Ofrecimiento2).HasColumnName(@"OFRECIMIENTO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            //Property(x => x.Ofrecimiento3).HasColumnName(@"OFRECIMIENTO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            //Property(x => x.Diferenciador).HasColumnName(@"DIFERENCIADOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            //Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().HasColumnType("int");
            //Property(x => x.VecesGestionado).HasColumnName(@"VECES_GESTIONADO").IsOptional().HasColumnType("int");
            //Property(x => x.MacroProcesoRecurrencia1).HasColumnName(@"MACROPROCESO_RECURRENCIA_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.MacroProcesoRecurrencia2).HasColumnName(@"MACROPROCESO_RECURRENCIA_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.MacroProcesoRecurrencia3).HasColumnName(@"MACROPROCESO_RECURRENCIA_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.MarcacionRecurrente1).HasColumnName(@"MARCACION_RECURRENTE_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.MarcacionRecurrente2).HasColumnName(@"MARCACION_RECURRENTE_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.MarcacionRecurrente3).HasColumnName(@"MARCACION_RECURRENTE_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.VolvioLlamar).HasColumnName(@"VOLVIO_A_LLAMAR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.Proceso).HasColumnName(@"OPERACION_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            //Property(x => x.Macroproceso).HasColumnName(@"FECHA_CARGUE").IsOptional().HasColumnType("datetime");
            //Property(x => x.).HasColumnName(@"RANGO_GENERACIONAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            //Property(x => x.UsuarioGestionando).HasColumnName(@"USUARIO_GESTIONANDO").IsOptional().HasColumnType("int");
            //Property(x => x.Aliado).HasColumnName(@"ALIADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            //Property(x => x.Campaña).HasColumnName(@"CAMPAÑA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
