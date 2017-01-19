﻿// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    //TBL_NOTAS_TRASLADOS
    public class NotasTrasladoConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NotasTraslado>
    {
        public NotasTrasladoConfiguration()
            : this("dbo")
        {
        }

        public NotasTrasladoConfiguration(string schema)
        {
            ToTable("TBL_NOTAS_TRASLADOS", schema);
            HasKey(x => new { x.IdNota});

            Property(x => x.IdNota).HasColumnName(@"ID_NOTA").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTraslado).HasColumnName(@"ID_TRASLADO").IsOptional().HasColumnType("numeric");
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsRequired().HasColumnType("numeric");
            Property(x => x.Usuario).HasColumnName(@"USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.NombreLineaNota).HasColumnName(@"NOMBRE_LINEA_NOTA").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.FechaNota).HasColumnName(@"FECHA_NOTA").IsOptional().HasColumnType("date");
            Property(x => x.HoraNota).HasColumnName(@"HORA_NOTA").IsOptional().HasColumnType("datetime");
            Property(x => x.Nota).HasColumnName(@"NOTA").IsOptional().HasColumnType("ntext").IsMaxLength();
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            
        }
    }
}
