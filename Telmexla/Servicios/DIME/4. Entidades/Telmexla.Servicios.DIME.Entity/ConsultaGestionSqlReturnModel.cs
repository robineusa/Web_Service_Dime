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

    public class ConsultaGestionSqlReturnModel
    {
        public System.Decimal? Id_Ingreso { get; set; }
        public System.Decimal Cuenta_cliente { get; set; }
        public System.Decimal? Ticket { get; set; }
        public System.String NOMBRE_LINEA_INGRESO { get; set; }
        public System.String NOMBRE_LINEA_ESCALADO { get; set; }
        public System.String ALIADO_APERTURA { get; set; }
        public System.DateTime? Fecha_nota { get; set; }
        public System.DateTime? FECHA_APERTURA { get; set; }
        public System.DateTime? HORA_APERTURA { get; set; }
        public System.DateTime? FECHA_CIERRE { get; set; }
        public System.Decimal? Usuario { get; set; }
        public System.Decimal? Usuario_Apertura { get; set; }
        public System.Decimal? Usuario_Cierre { get; set; }
        public System.DateTime? FECHA_ULTIMA_ACTUALIZACION { get; set; }
        public System.Decimal? Usuario_Ult_Actualizacion { get; set; }
        public System.DateTime? HORA_ULTIMA_ACTUALIZACION { get; set; }
        public System.String MACROPROCESO { get; set; }
        public System.String MARCACION { get; set; }
        public System.String NOTA { get; set; }
        public System.Int32? ID_ESTADO { get; set; }
    }

}