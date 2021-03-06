// <auto-generated>
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

namespace Telmexla.Servicios.DIME.Helpers.ReverseEngineer
{

    // TBL_CLIENTES_TODOS
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class ClientesTodoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ClientesTodo>
    {
        public ClientesTodoConfiguration()
            : this("dbo")
        {
        }

        public ClientesTodoConfiguration(string schema)
        {
            ToTable("TBL_CLIENTES_TODOS", schema);
            HasKey(x => x.Cuenta);

            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.HomePass).HasColumnName(@"HOME_PASS").IsOptional().HasColumnType("float");
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Apellido).HasColumnName(@"APELLIDO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Cedula).HasColumnName(@"CEDULA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TelefonoTelmex).HasColumnName(@"TELEFONO_TELMEX").IsOptional().HasColumnType("float");
            Property(x => x.Telefono1).HasColumnName(@"TELEFONO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Telefono2).HasColumnName(@"TELEFONO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Telefono3).HasColumnName(@"TELEFONO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Celular1).HasColumnName(@"CELULAR_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Celular2).HasColumnName(@"CELULAR_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TelefonoConv).HasColumnName(@"TELEFONO_CONV").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DirInstalacion).HasColumnName(@"DIR_INSTALACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.DirCorrespondencia).HasColumnName(@"DIR_CORRESPONDENCIA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Correo).HasColumnName(@"CORREO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Red).HasColumnName(@"RED").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Division).HasColumnName(@"DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Area).HasColumnName(@"AREA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Zona).HasColumnName(@"ZONA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Distrito).HasColumnName(@"DISTRITO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreComunidad).HasColumnName(@"NOMBRE_COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Departamento).HasColumnName(@"DEPARTAMENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estrato).HasColumnName(@"ESTRATO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoCliente).HasColumnName(@"TIPO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.GrupoSeg).HasColumnName(@"GRUPO_SEG").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Productos).HasColumnName(@"PRODUCTOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Convenio).HasColumnName(@"CONVENIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Cortesia).HasColumnName(@"CORTESIA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SrvHd).HasColumnName(@"SRV_HD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NumSrvBasicos).HasColumnName(@"NUM_SRV_BASICOS").IsOptional().HasColumnType("float");
            Property(x => x.Dth).HasColumnName(@"DTH").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Clarovideo).HasColumnName(@"CLAROVIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CategoriaRenta).HasColumnName(@"CATEGORIA_RENTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }

}
// </auto-generated>
