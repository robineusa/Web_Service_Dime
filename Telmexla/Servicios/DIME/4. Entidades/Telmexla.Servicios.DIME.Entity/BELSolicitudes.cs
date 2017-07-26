﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Entity
{
    public class BELSolicitudes
    {
        public decimal Id { get; set; }
        public decimal IdSolicitud { get; set; }
        public decimal CuentaCliente { get; set; }
        public decimal LlsOt { get; set; }
        public string TipoDeSolicitud { get; set; }
        public string DetalleDeSolicitud { get; set; }
        public System.DateTime? FechaDeSolicitud { get; set; }
        public string UsuarioQueSolicita { get; set; }
        public string NombreUsuarioQueSolicita { get; set; }
        public string AliadoQueSolicita { get; set; }
        public string OperacionQueSolicita { get; set; }
        public System.DateTime? FechaUltimaActualizacion { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }
        public string NombreUsuarioUltimaActualizacion { get; set; }
        public System.DateTime? FechaDeFinalizacion { get; set; }
        public string UsuarioQueFinaliza { get; set; }
        public string NombreUsuarioQueFinaliza { get; set; }
        public string Nodo { get; set; }
        public string Malescalado { get; set; }
        public string DetalleMalEscalado { get; set; }
        public string Gestion { get; set; }
        public string EstadoEscalamiento { get; set; }
        public System.DateTime? FechaDeAgenda { get; set; }
        public string Observaciones { get; set; }
        
    }
}
