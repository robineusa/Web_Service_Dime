using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data
{
    public class GLogRecurrenciaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GLogRecurrencia>
    {
        public GLogRecurrenciaConfiguration()
            : this("dbo")
        {
        }

        public GLogRecurrenciaConfiguration(string schema)
        {
            ToTable("TBL_GLR_RECURRENCIA", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreCliente).HasColumnName(@"NOMBRE_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ApellidoCliente).HasColumnName(@"APELLIDO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Division).HasColumnName(@"DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Area).HasColumnName(@"AREA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Zona).HasColumnName(@"ZONA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Marcaciones).HasColumnName(@"MARCACIONES").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaUltimaMarcacion).HasColumnName(@"FECHA_ULTIMA_MARCACION").IsOptional().HasColumnType("date");
            Property(x => x.FechaUltimaGestion).HasColumnName(@"FECHA_ULTIMA_GESTION").IsOptional().HasColumnType("date");
            Property(x => x.Telefono1).HasColumnName(@"TELEFONO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Telefono2).HasColumnName(@"TELEFONO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Telefono3).HasColumnName(@"TELEFONO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TelefonoTelmex).HasColumnName(@"TELEFONO_TELMEX").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IncluyeClaroVideo).HasColumnName(@"INCLUYE_CLARO_VIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.UsoClaroVideo).HasColumnName(@"USO_CLARO_VIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.ClienteNagra).HasColumnName(@"CLIENTE_NAGRA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Diferenciador).HasColumnName(@"DIFERENCIADOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().HasColumnType("numeric");
            Property(x => x.VecesGestionado).HasColumnName(@"VECES_GESTIONADO").IsOptional().HasColumnType("numeric");
            Property(x => x.MarcacionInicialAfectacion).HasColumnName(@"MARCACION_INICIAL_AFECTACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MarcacionReincidenteRecurrencia).HasColumnName(@"MARCACION_REINCIDIENTE_RECURRENCIA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ClieComunicaRealizadaGestRecu).HasColumnName(@"CLIE_COMUNICA_REALIZADA_GEST_RECU").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.PorQue).HasColumnName(@"PORQUE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Contacto).HasColumnName(@"CONTACTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.VozClienteCausaRaiz).HasColumnName(@"VOZ_CLIENTE_CAUSA_RAIZ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Solucionado).HasColumnName(@"SOLUCIONADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.AreaParticipaSolucion).HasColumnName(@"AREA_PARTICIPA_SOLUCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ClientePresentaNovedades).HasColumnName(@"CLIENTE_PRESENTA_NOVEDADES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Proceso).HasColumnName(@"PROCESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Macroproceso).HasColumnName(@"MACROPROCESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ServicioAfectado).HasColumnName(@"SERVICIO_AFECTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FallaEspecificaArbolCCAA).HasColumnName(@"FALLA_ESPECIFICA_ARBOL_CCAA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FallaCausaRaiz).HasColumnName(@"FALLA_CAUSA_RAIZ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SolucionEspecifica).HasColumnName(@"SOLUCION_ESPECIFICA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MarcaEquiposFalla).HasColumnName(@"MARCA_EQUIPOS_FALLA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UbicacionModem).HasColumnName(@"UBICACION_MODEM").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DispositivosInalambricosAlrededorModem).HasColumnName(@"DISPOSITIVOS_INALAMBRICOS_ALREDEDOR_MODEM").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CantEquiposConecInternet).HasColumnName(@"CANT_EQUIPOS_CONEC_INTERNET").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoDispConectaInternet).HasColumnName(@"TIPO_DISP_CONECTA_INTERNET").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsoBrindaInternet).HasColumnName(@"USO_BRINDA_INTERNET").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ActivacionClaroVideoNagra).HasColumnName(@"ACTIVACION_CLARO_VIDEO_NAGRA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ServicioOfrecido).HasColumnName(@"SERVICIO_OFRECIDO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AceptacionServicioOfrecido).HasColumnName(@"ACEPTACION_SERVICIO_OFRECIDO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.FechaSesguimiento).HasColumnName(@"FECHA_SEGUIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.IdGprincipal).HasColumnName(@"ID_GPRINCIPAL").IsOptional().HasColumnType("numeric");

            //HasOptional(a => a.GPrincipalRecurrencia).WithMany(b => b.GLogRecurrenciaVirtual).HasForeignKey(c => c.IdGprincipal).WillCascadeOnDelete(false);
        }
    }
}
