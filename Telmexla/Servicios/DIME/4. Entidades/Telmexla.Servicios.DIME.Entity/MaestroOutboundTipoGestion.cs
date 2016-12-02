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

namespace Telmexla.Servicios.DIME.Entity
{

    // MAESTRO_OUTBOUND_TIPO_GESTION
    public class MaestroOutboundTipoGestion
    {
        public decimal IdTipoGestion { get; set; } // ID_TIPO_GESTION (Primary key)
        public string TipoGestion { get; set; } // TIPO_GESTION (length: 50)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<MaestroOutboundTipoContacto> MaestroOutboundTipoContactoes { get; set; } // MAESTRO_OUTBOUND_TIPO_CONTACTO.FK__MAESTRO_O__TIPO___3B0BC30C

        public MaestroOutboundTipoGestion()
        {
            MaestroOutboundTipoContactoes = new System.Collections.Generic.List<MaestroOutboundTipoContacto>();
        }
    }

}
