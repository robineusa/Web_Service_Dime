﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Business
{
    public class UsuariosMasivoData
    {
        public decimal Cedula { get; set; } // CEDULA (Primary key)
        public string Nombre { get; set; } // NOMBRE (length: 100)
        public string Aliado { get; set; } // ALIADO (length: 100)
        public string Canal { get; set; } // CANAL (length: 100)
        public string Operacion { get; set; } // OPERACION (length: 100)
        public string Grupo { get; set; } // GRUPO (length: 100)
        public string Cargo { get; set; } // CARGO (length: 100)
        public string UsuarioRr { get; set; } // USUARIO_RR (length: 100)
        public string UsuarioAgendamiento { get; set; } // USUARIO_AGENDAMIENTO (length: 100)
        public string UsuarioGerencia { get; set; } // USUARIO_GERENCIA (length: 100)
        public string Estado { get; set; } // ESTADO (length: 100)
        public string NombreLinea { get; set; } // NOMBRE_LINEA (length: 70)
        public string Nombre1 { get; set; } // NOMBRE_1 (length: 100)
        public string Nombre2 { get; set; } // NOMBRE_2 (length: 100)
        public string Apellido1 { get; set; } // APELLIDO_1 (length: 100)
        public string Apellido2 { get; set; } // APELLIDO_2 (length: 100)
        public string Segmento { get; set; } // SEGMENTO (length: 100)
        public string  InfoRegistro { get; set; }
    }
}
