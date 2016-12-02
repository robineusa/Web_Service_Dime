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

    // MARCACIONES_CALL
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class MarcacionesCallConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MarcacionesCall>
    {
        public MarcacionesCallConfiguration()
            : this("dbo")
        {
        }

        public MarcacionesCallConfiguration(string schema)
        {
            ToTable("MARCACIONES_CALL", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int");
            Property(x => x.TipoAtencion).HasColumnName(@"Tipo_Atencion").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Razon).HasColumnName(@"Razon").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.SubRazon).HasColumnName(@"SubRazon").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Descripcion).HasColumnName(@"Descripcion").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(800);
            Property(x => x.PosibleCausa).HasColumnName(@"Posible_Causa").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Spc).HasColumnName(@"SPC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.CanalHabilitado).HasColumnName(@"Canal_Habilitado").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.QueHacer).HasColumnName(@"Que_Hacer").IsOptional().IsUnicode(false).HasColumnType("text").HasMaxLength(2147483647);
            Property(x => x.CodigosDeCierre).HasColumnName(@"Codigos_De_Cierre").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.AsociadasAAjuste).HasColumnName(@"Asociadas_A_ajuste").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.AreaUsuarioAEscalar).HasColumnName(@"Area_Usuario_A_escalar").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2000);
            Property(x => x.QuienFinalizaTicket).HasColumnName(@"Quien_Finaliza_Ticket").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.TipologiasSujetasACun).HasColumnName(@"Tipologias_sujetas_A_cun").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.ServicioQueCreaCun).HasColumnName(@"Servicio_Que_Crea_Cun").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Responsable).HasColumnName(@"Responsable").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.AreaResponsable).HasColumnName(@"Area_Responsable").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Macroproceso).HasColumnName(@"Macroproceso").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.TipoDeNovedad).HasColumnName(@"Tipo_De_Novedad").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.TipoDeSolicitud).HasColumnName(@"Tipo_De_Solicitud").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.ServicioAfectado).HasColumnName(@"Servicio_Afectado").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
        }
    }

}
// </auto-generated>
