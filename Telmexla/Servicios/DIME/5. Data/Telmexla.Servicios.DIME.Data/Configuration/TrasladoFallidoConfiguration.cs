﻿
#pragma warning disable 1591    

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    //TBL_TRASLADO_FALLIDO
    public class TrasladoFallidoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TrasladoFallido>
    {
        public TrasladoFallidoConfiguration()
            : this("dbo")
        {
        }

        public TrasladoFallidoConfiguration(string schema)
        {
            ToTable("TBL_TRASLADO_FALLIDO", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTransaccion).HasColumnName(@"ID_TRANSACCION").IsOptional().HasColumnType("numeric");
            Property(x => x.UsuarioTransaccion).HasColumnName(@"USUARIO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.CanalTransaccion).HasColumnName(@"CANAL_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.FechaTransaccion).HasColumnName(@"FECHA_TRANSACCION").IsOptional().HasColumnType("date");
            Property(x => x.NombreLineaTransaccion).HasColumnName(@"NOMBRE_LINEA_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.MotivoTrasladoFallido).HasColumnName(@"MOTIVO_TRASLADO_FALLIDO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.CuentaOcupa).HasColumnName(@"CUENTA_OCUPADA").IsOptional().HasColumnType("numeric");
            Property(x => x.CuentaTraslada).HasColumnName(@"CUENTA_TRASLADA").IsOptional().HasColumnType("numeric");
            Property(x => x.CuentaMatriz).HasColumnName(@"CUENTA_MATRIZ").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreConjunto).HasColumnName(@"NOMBRE_CONJUNTO_EDIFICIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoMatriz).HasColumnName(@"ESTADO_MATRIZ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Direccion).HasColumnName(@"DIRECCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstratoOrigen).HasColumnName(@"ESTRATO_ORIGEN").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.EstratoDestino).HasColumnName(@"ESTRATO_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.TarifaActual).HasColumnName(@"TARIFA_ACTUAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.TarifaNueva).HasColumnName(@"TARIFA_NUEVA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.GestionPorTraslado).HasColumnName(@"GESTION_POR_TRASLADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(15);
            Property(x => x.TelefonoCelular).HasColumnName(@"TELEFONO_CELULAR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.TelefonoFijo).HasColumnName(@"TELEFONO_FIJO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.CorreoElectronico).HasColumnName(@"CORREO_ELECTRONICO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Observacion).HasColumnName(@"OBSERVACION").IsOptional().HasColumnType("ntext").IsMaxLength();
        }
    }
}