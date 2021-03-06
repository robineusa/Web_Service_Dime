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

    // MAESTRO_OUTBOUND_CIERRE
    public class MaestroOutboundCierre
    {
        public decimal IdCierre { get; set; } // ID_CIERRE (Primary key)
        public decimal IdTipoContacto { get; set; } // ID_TIPO_CONTACTO
        public string Cierre { get; set; } // CIERRE (length: 100)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<MaestroOutboundRazon> MaestroOutboundRazons { get; set; } // MAESTRO_OUTBOUND_RAZON.FK__MAESTRO_O__RAZON__40C49C62

        // Foreign keys
        public virtual MaestroOutboundTipoContacto MaestroOutboundTipoContacto { get; set; } // FK__MAESTRO_O__CIERR__3DE82FB7

        public MaestroOutboundCierre()
        {
            MaestroOutboundRazons = new System.Collections.Generic.List<MaestroOutboundRazon>();
        }
    }

}
