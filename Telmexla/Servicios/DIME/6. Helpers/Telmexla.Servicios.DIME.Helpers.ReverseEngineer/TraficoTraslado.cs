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

    // TBL_TRAFICO_TRASLADO
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class TraficoTraslado
    {
        public decimal Id { get; set; } // ID (Primary key)
        public decimal IdTransaccion { get; set; } // ID_TRANSACCION
        public string UsuarioTransaccion { get; set; } // USUARIO_TRANSACCION (length: 30)
        public System.DateTime? InicioTransaccion { get; set; } // INICIO_TRANSACCION
        public System.DateTime? FinTransaccion { get; set; } // FIN_TRANSACCION
        public string TipoTransaccion { get; set; } // TIPO_TRANSACCION (length: 100)
        public string CanalTransaccion { get; set; } // CANAL_TRANSACCION (length: 100)
        public string EstadoTransaccion { get; set; } // ESTADO_TRANSACCION (length: 100)
    }

}
// </auto-generated>
