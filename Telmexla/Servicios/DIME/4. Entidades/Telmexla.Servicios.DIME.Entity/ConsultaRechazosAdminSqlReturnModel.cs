// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51


namespace Telmexla.Servicios.DIME.Entity
{
    public class ConsultaRechazosAdminSqlReturnModel
    {
        public System.Decimal? ID_INGRESO { get; set; }
        public System.DateTime? FECHA_CREACION_CASO { get; set; }
        public System.String HORA_CREACION_CASO { get; set; }
        public System.Decimal? Usuario_Creacion_Caso { get; set; }
        public System.String NOTAS_RECHAZO { get; set; }
        public System.Decimal? Usuario_Rechaza { get; set; }
        public System.DateTime? FECHA_RECHAZO { get; set; }
        public System.DateTime? HORA_RECHAZO { get; set; }
        public System.String Nombre_Usuario_Creacion { get; set; }
        public System.String Nombre_Usuario_Rechaza { get; set; }
        public System.String Nombre_Linea_Usuario_Rechaza { get; set; }
        public System.String Aliado_Usuario_Rechaza { get; set; }
    }

}
// </auto-generated>
