using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.WebServices;
using Telmexla.Servicios.DIME.WebServices.MainWebService;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.Entity;
using System.Diagnostics;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Helpers.Encription;

namespace Telmexla.Servicios.DIME.Ejecutor
{
    class Program
    {
        static void Main()
        {


            ProcesosBusiness por = new ProcesosBusiness();
            Nodo nodo = new Nodo();
            nodo = por.ConsultarNodoCreado(1);

            var dddd = "";
            //FidelizacionService fidelizacion = new FidelizacionService(); 
            //var r = fidelizacion.getMaestroServiciosAll();



            //FidelizacionService fideliza = new FidelizacionService();
            //var x = fideliza.getMaestroServiciosById("00100");

            //FidelizacionMotivosCancelacion fidelizacion = new FidelizacionMotivosCancelacion();
            //fidelizacion.Motivo = "Esto es una prueba";
            //fidelizacion.Registro = DateTime.Now;
            //FidelizacionService fidelizacion2 = new FidelizacionService();
            //fidelizacion2.setMotivosCancelacion(fidelizacion);


            //FidelizacionService fidelizacion = new FidelizacionService();
            //var motivo = fidelizacion.getMotivosCancelacionById(3);

            //FidelizacionService fidelizacion = new FidelizacionService();
            //var test = fidelizacion.getSubmotivosCancelacionAll();

            //FidelizacionService Fidelizacion = new FidelizacionService();
            //var rta = Fidelizacion.getSubmotivosCancelacionById(9);

            //FidelizacionSubmotivosCancelacion Fidelizacionsubmotivos = new fidelizacionsubmotivoscancelacion();
            //fidelizacionsubmotivos.registro = datetime.now;
            //fidelizacionsubmotivos.submotivo = "otro submotivo";
            //fidelizacionsubmotivos.fidmotivoid = 3;

            //FidelizacionService Fidelizacion = new FidelizacionService();
            //Fidelizacion.setSubmotivoCancelacion(FidelizacionSubmotivos);

            //FidelizacionTipificacion Tipificacion = new FidelizacionTipificacion();
            //Tipificacion.Registro = DateTime.Now;
            //Tipificacion.Nota = "Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta).";
            //Tipificacion.Nombre = "Recuperado";
            //Tipificacion.UsuarioId = 4940;

            //FidelizacionService Fidelizacion = new FidelizacionService();
            //Fidelizacion.setTipificacion(Tipificacion);

            //FidelizacionRecursiva Recursiva = new FidelizacionRecursiva();
            //Recursiva.Nombre = "Campaña Retencion";
            //Recursiva.Nivel = 1;
            //Recursiva.ParentId = 6;
            //Recursiva.VerNivel = "111";
            //Recursiva.Label = "Texto Prueba";

            //FidelizacionService Fidelizacion = new FidelizacionService();
            //Fidelizacion.setRecursiva(Recursiva);

            //FidelizacionService Fidelizacion = new FidelizacionService();
            //var xz = Fidelizacion.getRecursivaAll();

            //FidelizacionRegistro Registro = new FidelizacionRegistro();
            //Registro.Cuenta = 760;
            //Registro.DiaCorte = 2;
            //Registro.FechaCorte = DateTime.Now;
            //Registro.FechaRegistro = DateTime.Now;
            //Registro.Notas = "texto de prueba";
            //Registro.OtrosOfrecimientosId = 7;
            //Registro.Permanencia = "No";
            //Registro.RecursivaId = 301;
            //Registro.ServiciosId = "101";
            //Registro.ServiciosRetenidosId = "100";
            //Registro.SubmotivoId = 11;
            //Registro.TipificacionId = 3;
            //Registro.UsuarioId = 4940;

            //FidelizacionService Fidelizacion = new FidelizacionService();
            //Fidelizacion.setRegistro(Registro);
        }
    }
}
