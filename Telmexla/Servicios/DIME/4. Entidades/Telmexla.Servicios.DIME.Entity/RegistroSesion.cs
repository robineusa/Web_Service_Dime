
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

    // TBL_REGISTRO_SESION
    public class RegistroSesion
    {
        public int Id { get; set; } // ID (Primary key)
        public bool? EsIngreso { get; set; } // ES_INGRESO
        public int? IdUsuario { get; set; } // ID_USUARIO
        public string IpCreacion { get; set; } // IP_CREACION (length: 15)
        public System.DateTime? FechaCreacion { get; set; } // FECHA_CREACION
        public System.TimeSpan? HoraCreacion { get; set; } // HORA_CREACION

        // Foreign keys
        public virtual Usuario Usuario { get; set; } // FK__TBL_REGIS__ID_US__123EB7A3
    }

}

