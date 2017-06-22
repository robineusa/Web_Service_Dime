using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class ViewModelSkillsUsuariosBlending
    {
        public int Id { get; set; } // ID (Primary key)
        public int Cedula { get; set; } // Fecha de la publicaion
        public string Nombre { get; set; }
        public string Operacion { get; set; }// Usuario de publicacion (varchar 30)
        public string Campaña { get; set; }// Nombre Imgen
        public System.DateTime? Fecha_Actualizacion { get; set; }// Link Direccionamiento
        public int Id_Usuario_Actualizacion { get; set; }
    }
}
