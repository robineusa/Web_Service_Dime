

namespace Telmexla.Servicios.DIME.Entity
{
    public class MaestroMarcacione
    {

        public int Id { get; set; } // ID (Primary key)
        public string Razon { get; set; } // MOTIVO (length: 100)
        public string Subrazon { get; set; } // MOTIVO (length: 100)
        public string Submarcacion { get; set; } // MOTIVO (length: 100)
        public string EstadoMarcacion { get; set; } // MOTIVO (length: 100)
        public string Descripcion { get; set; } // MOTIVO (length: 100)
        public string Spc { get; set; } // MOTIVO (length: 100)
        public string Qmf { get; set; } // MOTIVO (length: 100)
        public string Responsable { get; set; } // MOTIVO (length: 100)
        public string AreaResponsable { get; set; } // MOTIVO (length: 100)
        public string Macroproceso { get; set; } // MOTIVO (length: 100)
        public string Clase { get; set; } // MOTIVO (length: 100)
        public string ReporteTrimestral { get; set; } // MOTIVO (length: 100)
        public string Servicios { get; set; } // MOTIVO (length: 100)
        public string CanalHabilitado { get; set; } // MOTIVO (length: 100)
        public string QueHacer { get; set; } // MOTIVO (length: 100)
        public string QueHacerHtml { get; set; } // MOTIVO (length: 100)
        public string AreayUsuarioEscala { get; set; } // MOTIVO (length: 100)
        public string QuienFinaliza { get; set; } // MOTIVO (length: 100)
        public string TipologiasCun { get; set; } // MOTIVO (length: 100)
        public int CantidadDias { get; set; } // MOTIVO (length: 100)
        public string Canal { get; set; } // MOTIVO (length: 100)
        public string TipoMarcacion { get; set; } // MOTIVO (length: 100)
        public System.DateTime? FechaCreacion { get; set; } // MOTIVO (length: 100)
        public string UsuarioCreacion { get; set; } // MOTIVO (length: 100)
        public System.DateTime? FechaActualizacion { get; set; } // MOTIVO (length: 100)
        public string UsuarioActualizacion { get; set; } // MOTIVO (length: 100)

        }
}
