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

    // TBL_SKILLS_USUARIOS_BLENDING
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class SkillsUsuariosBlending
    {
        public int Id { get; set; } // ID (Primary key)
        public int? Cedula { get; set; } // CEDULA
        public string Operacion { get; set; } // OPERACION (length: 200)
        public string Campaña { get; set; } // CAMPAÑA (length: 200)
        public System.DateTime? FechaActualizacion { get; set; } // FECHA_ACTUALIZACION
        public int? IdUsuarioActualizacion { get; set; } // ID_USUARIO_ACTUALIZACION
    }

}
// </auto-generated>