﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    //[TBL_INFORMACION_NODOS]
    public class  MaestroNodo
    {
        public decimal IdNodo { get; set; } 
        public string Nodo { get; set; }
        public string NombreNodo { get; set; }
        public string Div { get; set; } 
        public string Com { get; set; } 
        public string Divisional { get; set; }
        public string Area { get; set; }
        public string Zona { get; set; }
        public string Distrito { get; set; }
        public string Ugestion { get; set; }
        public string Usuario { get; set; }
        public System.DateTime? FechaCreacion { get; set; } 
        public string Estado { get; set; } 
        public string Red { get; set; } 
        public string Aliado { get; set; }
        public string NombreComunidad { get; set; }
        public string Departamento { get; set; }

    }
}
