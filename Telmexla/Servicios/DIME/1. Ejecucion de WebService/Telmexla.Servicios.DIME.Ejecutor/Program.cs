﻿using System;
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
            //CasosAdminService adminService = new CasosAdminService();
            //DateTime inicial = Convert.ToDateTime("2017- 04-04");
            //DateTime final = Convert.ToDateTime("2017- 04-14");
            //var resultPaloteo = adminService.ListaPaloteo(inicial,final);

            //IngresoTraslado INGT = new IngresoTraslado();
            //TrasladoFallido tf = new TrasladoFallido();
            //TraficoTraslado trf = new TraficoTraslado();
            //INGT.CuentaCliente = 111;
            //trf.InicioTransaccion = DateTime.Now;
            //trf.FinTransaccion = DateTime.Now;
            //IngresoTrasladoBusiness igtb = new IngresoTrasladoBusiness();
            //igtb.InsertIngresoTrasladoFallido(INGT, tf, trf);

            //MaestrosService MS = new MaestrosService();
            //MaestroLineasBlending model = new MaestroLineasBlending();
            //model.Aliado = "ATENTO";
            //var R = MS.TraerListaLineasBlending(model.Aliado);

            //BlendingService BS = new BlendingService();
            //var Operacion = "VENTAS INBOUND";
            //var r = BS.ListaUsuariosAdminBlending(Operacion);

            BlendingService BS = new BlendingService();
            string Cedula = "7889";
            var R = BS.ConsultaUsuarioenAdminBlending(Cedula);
            var z = "";

            MaestroNodo nodo = new MaestroNodo();

            //    //nodo.NombreNodo = "ROBIN";
            //    //nodo.Div = "AAA";
            //    //nodo.Com = "AAA";
            //    //nodo.Divisional = "112";
            //    //nodo.Area = "11";
            //    //nodo.Zona = "11";
            //    //nodo.Distrito = "11";
            //    //nodo.Ugestion = "11";
            //    //nodo.Usuario = "robineusa";
            //    //nodo.Estado = "activo";
            //    //nodo.Red = "dth";
            //    //nodo.Aliado = "BRM";
            //    //MaestroNodoService servi = new MaestroNodoService();
            //    //servi.InsertarNodo(nodo);

            //UsabilidadBusquedaCuentaInbound model = new UsabilidadBusquedaCuentaInbound();
            //model.Id = 0;
            //model.IdUsuarioRevision = 78;
            //model.NombreUsuarioRevision = "Robin la FOX";
            //model.CuentaRevisoTabla = 307;

            //UsabilidadService U = new UsabilidadService();
            //U.InsertarUsabilidadCuentaInbound(model);
            //var z = "";


            //    //GraficosBusiness BUSI = new GraficosBusiness();
            //    //BUSI.GraficoTrasladosGeneralAsesor("TLEAL");



            //    //BalanceScoreCard blscd = new BalanceScoreCard();
            //    //blscd.Cedula = 1012388701;
            //    //BalanceScoreCardService BLSERVICE = new BalanceScoreCardService();
            //    //BLSERVICE.IndicadoresUsuario(blscd.Cedula);
            //    //var resultado = BLSERVICE.IndicadoresUsuario(blscd.Cedula);

            //    ////UnitOfWork unitWork = new UnitOfWork(new DimeContext());


            //    //TraficoTraslado trafico = new TraficoTraslado();
            //    //trafico.IdTransaccion = 1;
            //    //trafico.UsuarioTransaccion = "robineusa";
            //    //trafico.InicioTransaccion = DateTime.Now;
            //    //trafico.FinTransaccion = DateTime.Now;
            //    //trafico.TipoTransaccion = "solicitud inboud";
            //    //trafico.CanalTransaccion = "inbound";
            //    //trafico.EstadoTransaccion = "seguimiento";
            //    //UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            //    //unitWork.traficoTraslados.Add(trafico);
            //    //unitWork.Complete();

            //    //SiguienteMejorOferta model = new SiguienteMejorOferta();
            //    //model.UsuarioGestion = "robineusa";
            //    //model.AliadoGestion = "BRM";
            //    //model.CuentaCliente = 141;
            //    //model.Ofrecimiento1 = 1;
            //    //model.Ofrecimiento2 = 0;
            //    //model.Ofrecimiento3 = 0;
            //    //model.TipoContacto = "1234";
            //    //model.Gestion = "1234";
            //    //model.Cierre = "1234";
            //    //model.Razon = "1234";
            //    //model.Observaciones = "sdfsdfwwwwww";
            //    //ActivacionSiembraHDService SS = new ActivacionSiembraHDService();
            //    //SS.InsertarSMOInbound(model);


            //    //ActivacionSiembraHDService CuentasService = new ActivacionSiembraHDService();
            //    //var result454 = CuentasService.BuscarCuentaSMO(141);

            //    //NotificaionesBuenServicioService NotiService = new NotificaionesBuenServicioService();
            //    //var result454 = NotiService.ImagenporId(6);

            //    ////prueba julio

            //    ////CuentasSiembraHD shd = new CuentasSiembraHD();
            //    ////shd.CuentaCliente =307;
            //    ////ActivacionSiembraHDService activacionshdservice = new ActivacionSiembraHDService();
            //    ////var result84841848 = activacionshdservice.BuscarCuentaSiembraHD(shd.CuentaCliente);

            //    LoginService loginService = new LoginService();

            //    var result789456=  loginService.LineaDeUsuarioPorId(3);
            //    string vacio = "";
            //    //SiembraHD entidad = new SiembraHD();
            //    //entidad.UsuarioGestion = "ROBINEUSA";
            //    //entidad.NombreUsuarioGestion = "ROBINSON NEUSA";
            //    //entidad.AliadoGestion = "BRM";
            //    //entidad.CuentaCliente = 307;
            //    //entidad.Ofrecimiento = "Acepta todo el paquete HD";
            //    //entidad.AceptacionSiembraHD = "SI";
            //    //ActivacionSiembraHDService actHDservice = new ActivacionSiembraHDService();
            //    //actHDservice.InsertarSiembraHDInbound(entidad);

            //    ////ActivacionClaroVideo entidad = new ActivacionClaroVideo();
            //    ////entidad.UsuarioGestion = "ROBINEUSA";
            //    ////entidad.NombreUsuario = "ROBINSON NEUSA";
            //    ////entidad.AliadoGestion = "BRM";
            //    ////entidad.CuentaCliente = 307;
            //    ////entidad.AceptacionClaroVideo = "SI";


            //    //ActivacionClaroVideoService actclarovideoservice = new ActivacionClaroVideoService();
            //    //actclarovideoservice.InsertarClaroVideoInbound(entidad);


            //    //NotasTraslado nota = new NotasTraslado();
            //    //int id = 2;
            //    //string Usuario = "ALEXOSPINA";
            //    //TrasladosService trasladoservice = new TrasladosService();
            //    //var result84841848 = trasladoservice.ListaSeguimientosDireccionesOutbound(Usuario);




            //    ////nodo.NombreNodo = "ROBIN";
            //    ////nodo.Div = "AAA";
            //    ////nodo.Com = "AAA";
            //    ////nodo.Divisional =11;
            //    ////nodo.Area = 11;
            //    ////nodo.Distrito = 11;
            //    ////nodo.Ugestion = 11;
            //    ////nodo.Usuario = "robineusa";
            //    ////nodo.Estado = "activo";
            //    ////nodo.Red = "dth";
            //    ////nodo.Aliado = "BRM";

            //    //servicenodo.ExisteNodo(dato);

            //    //IngresoTraslado ingresotraslado = new IngresoTraslado();
            //    //TrasladosService traslados = new TrasladosService();
            //    //ingresotraslado.CuentaCliente = 307;
            //    //ingresotraslado.Direccion = "ESTE CAMPO DE DIRECCION";
            //    //ingresotraslado.Estrato = "NR";
            //    //ingresotraslado.Nodo = "AAAADSA";
            //    //ingresotraslado.TelefonoCelular = "3228451001";
            //    //ingresotraslado.TelefonoFijo="9005668";
            //    //ingresotraslado.FechaApertura = DateTime.Now;
            //    //ingresotraslado.HoraApertura = DateTime.Now;
            //    //ingresotraslado.UsuarioApertura = "ROBINEUSA";
            //    //ingresotraslado.FechaUltimaActualizacion = DateTime.Now;
            //    //ingresotraslado.UsuarioUltimaActualizacion = "ROBINEUSA";
            //    //ingresotraslado.HoraUltimaActualizacion = DateTime.Now;
            //    //ingresotraslado.AliadoApertura = "BRM";
            //    //ingresotraslado.NombreLineaIngreso = "GESTION DE LA INFORMACION";

            //    //var observacion = "SE GENERA LA CREACION DE UN CASO DE PRUEBA";
            //    //traslados.RegistrarIngresoTraslado(ingresotraslado, observacion);





            //    DateTime fechaInicial = Convert.ToDateTime("2016-11-01");
            //        DateTime fechaFinal = Convert.ToDateTime("2017-01-01");
            //    BlendingService blendService = new BlendingService();

            //    var result783 = blendService.ListaCierresCicloGestionados(fechaInicial, fechaFinal);




            //    Debug.Print(new GeneralEncriptor().GetEncriptedData("Clarop2017") )  ;
            //    Console.WriteLine(new GeneralEncriptor().GetEncriptedData("Clarop2017"));

            //    ClientesTodo DatosCliente = new ClientesTodo();

            //    DatosCliente.Apellido = "CUARTAS";
            //    DatosCliente.Cuenta = 430;
            //    DatosCliente.DirInstalacion = "CR 5Este 14-87 casa 74";
            //    DatosCliente.Estrato = "3";
            //    DatosCliente.Nombre = "JEANETH";
            //    DatosCliente.NombreComunidad = "VILLAVICENCIO";
            //    DatosCliente.Telefono1 = "3115244589";
            //    DatosCliente.Telefono2 = "0";
            //    DatosCliente.Telefono3 = "0";

            //    ClaroVideo claroVideoGestionado = new ClaroVideo();
            //    claroVideoGestionado.AliadoGestion = "OUTSOURCING PEREIRA";
            //    claroVideoGestionado.Attributo1 = 1;
            //    claroVideoGestionado.Attributo2 = 1;
            //    claroVideoGestionado.Cierre = "76";
            //    claroVideoGestionado.Id = 0;
            //    claroVideoGestionado.Observaciones = "marca pocas";
            //    claroVideoGestionado.Razon = "20";
            //    claroVideoGestionado.TipoDeContacto = "20";
            //    claroVideoGestionado.TipoDeGestion = "21";

            // //   blendingService.GuardarGestionClaroVideo(1,DatosCliente, claroVideoGestionado );


            //    ConvenioElectronicoCollection HistoricoConvenioElectronico = new ConvenioElectronicoCollection();
            //    ConvenioElectronico ConvenioElecGestionado = new ConvenioElectronico();
            //    BlendingService blendingServices = new BlendingService();
            //    var resultado50 = blendingServices.ListaClaroVideosGestionados(fechaInicial, fechaFinal);

            //    ConvenioElecGestionado.AliadoGestion = "OUTSOURCING PEREIRA";
            //    ConvenioElecGestionado.LineaGestion = "OUTBOUND";
            //    ConvenioElecGestionado.Cierre = "3";
            //    ConvenioElecGestionado.Razon = "12";
            //    ConvenioElecGestionado.TipoContacto = "5";

            //    blendingServices.GuardarGestionConvenioElectronico(1, DatosCliente, ConvenioElecGestionado);



            //    //var result2 =  blendingServices.TraerMisDatosClienteAutomaticos(1, "CONVENIO_ELECTRONICO");

            //    //var result3 = blendingServices.TraerHistorialConvenioElectroDeAsesor(1);













            //    LoginService login = new LoginService();


            //    IInboundService inbound = new InboundService();

            //    IMaestrosService maestros = new MaestrosService();

            //    var tiposContactos = maestros.ObtenerTiposDeMotivoDeCausas(115);

            //    Usuario usuario = new Usuario();
            //    usuario.Cedula = 1032000456;
            //    usuario.Contrasena = "Claro2016";
            //    usuario.Id = (int)login.RecibirIdUsuario(usuario.Cedula);
            //    var result = login.AutenticarUsuarioEnSesion(usuario);






            //    int i = 0;



            //    #region inbound tests
            //    /*
            //    DatosAdicionalesCliente datosAdicionales = new DatosAdicionalesCliente();
            //    datosAdicionales.Cuenta = 23682065;
            //    datosAdicionales.CorreoElectronico = null;
            //    datosAdicionales.Hobbie = null;
            //    datosAdicionales.NivelEstudios = "TÉCNICO";

            //    Debug.Print(inbound.RegistrarActualizarDatosAdicionalesCliente(datosAdicionales) + "actualizar datos adicionales", inbound.RegistrarActualizarDatosAdicionalesCliente(datosAdicionales) + " actualizar datos adicionales");
            //    */
            //    #endregion
            //    /*
            //       //    try { 
            //       Usuario usuario = new Usuario();
            //              usuario.Cedula = 1032000123;
            //              usuario.Contrasena = "Claro2016";
            //               usuario.Id = (int)login.RecibirIdUsuario(usuario.Cedula);
            //       usuario.Correo = "alejanda@asdasd.com";
            //       string fecha = "2016-10-04";
            //       usuario.FechaNacimiento = Convert.ToDateTime(fecha);
            //       usuario.Telefono = 123123;
            //      Debug.Print(login.AutenticarUsuarioEnSesion(usuario)+" autenticar", login.AutenticarUsuarioEnSesion(usuario)+ " autenticar");
            //       int cuenta = 2500064;
            //       ClientesTodo cliente = inbound.TraerClienteCompletoPorCuenta(cuenta);
            //       List<ClientesTodo> clientes = inbound.ConsultarCuentasPorcedula("21228586");
            //       Debug.Print(inbound.ConsultarCuentasPorcedula("51865550") + " autenticar", inbound.ConsultarCuentasPorcedula("72270961") + " autenticar");
            //       List<PreguntasDesbloqueo> preguntasDesb = new List<PreguntasDesbloqueo>();
            //           List<String> respuestas = new List<String>();
            //           for (int i = 0; i< 5;i++)
            //           {   PreguntasDesbloqueo pdesb = new PreguntasDesbloqueo();
            //               pdesb.Id = i + 1;
            //               preguntasDesb.Add(pdesb);
            //               String respuesta = "resputa tercera" + i;
            //               respuestas.Add(respuesta);
            //           }
            //       usuario.Genero = "M";
            //       usuario.Id = 3;
            //       Debug.Print(login.RestablecerContraseña("456",1) + " reg preguntas desb", login.RestablecerContraseña("456", 1) + " reg preguntas desb");
            //       usuario.Id = 1;
            //       Console.ReadLine();
            //       */
            //    using (ServiceHost host = new ServiceHost(typeof(WebService)))
            //    {
            //        //  Debug.Print(login.RegistrarActualizarPreguntas(preguntasDesb,respuestas, usuario, 5) + " reg preguntas desb", login.RegistrarActualizarPreguntas(preguntasDesb, respuestas, usuario, 5) + " reg preguntas desb");


            //        host.Open();
            //        Console.WriteLine("Host started at " + DateTime.Now.ToString());
            //        Console.ReadLine();
            //    }

            //        //     Debug.Print(login.BloquearUsuario(1, 2, "172.16.248.81") + "  desb", login.BloquearUsuario(1,2,"172.16.248.81") + " desb");
            //        //    Console.WriteLine("Host started at " + DateTime.Now.ToString());
            //        //  Console.ReadLine();
            //        // }
            //        /*  catch(Exception e)
            //          {   Debug.Print("Comienzo error "+e+"error sacado", "Comienzo error " + e +" error sacado");
            //              Console.ReadLine();
            //          }  */
            //        //}

        }
    }
}
