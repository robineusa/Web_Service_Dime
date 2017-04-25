﻿// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
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
    public class MaestroLineasBlendingConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroLineasBlending>
    {
        public MaestroLineasBlendingConfiguration()
            : this("dbo")
        {
        }

        public MaestroLineasBlendingConfiguration(string schema)
        {
            ToTable("MAESTRO_LINEAS_BLENDING", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Aliado).HasColumnName(@"ALIADO").IsRequired().HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.NombreLinea).HasColumnName(@"NOMBRE_LINEA").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}