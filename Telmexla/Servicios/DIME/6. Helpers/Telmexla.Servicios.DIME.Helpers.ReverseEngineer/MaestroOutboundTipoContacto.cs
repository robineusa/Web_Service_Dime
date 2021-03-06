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

    // MAESTRO_OUTBOUND_TIPO_CONTACTO
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class MaestroOutboundTipoContacto
    {
        public decimal IdTipoContacto { get; set; } // ID_TIPO_CONTACTO (Primary key)
        public decimal IdTipoGestion { get; set; } // ID_TIPO_GESTION
        public string TipoContacto { get; set; } // TIPO_CONTACTO (length: 50)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<MaestroOutboundCierre> MaestroOutboundCierres { get; set; } // MAESTRO_OUTBOUND_CIERRE.FK__MAESTRO_O__CIERR__3DE82FB7

        // Foreign keys
        public virtual MaestroOutboundTipoGestion MaestroOutboundTipoGestion { get; set; } // FK__MAESTRO_O__TIPO___3B0BC30C

        public MaestroOutboundTipoContacto()
        {
            MaestroOutboundCierres = new System.Collections.Generic.List<MaestroOutboundCierre>();
        }
    }

}
// </auto-generated>
