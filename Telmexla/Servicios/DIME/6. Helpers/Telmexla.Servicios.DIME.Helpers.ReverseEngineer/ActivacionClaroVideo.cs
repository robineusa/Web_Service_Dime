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

    // TBL_ACTIVACION_CLARO_VIDEO
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class ActivacionClaroVideo
    {
        public decimal IdActivacion { get; set; } // ID_ACTIVACION (Primary key)
        public System.DateTime? FechaDeGestion { get; set; } // FECHA_DE_GESTION
        public string UsuarioDeGestion { get; set; } // USUARIO_DE_GESTION (length: 30)
        public string NombreUsuarioGestion { get; set; } // NOMBRE_USUARIO_GESTION (length: 50)
        public string AliadoGestion { get; set; } // ALIADO_GESTION (length: 30)
        public decimal? CuentaCliente { get; set; } // CUENTA_CLIENTE
        public string AceptacionClaroVideo { get; set; } // ACEPTACION_CLARO_VIDEO (length: 2)
    }

}
// </auto-generated>
