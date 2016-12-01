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
using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.IData.IContext
{

    public interface IDimeContext : System.IDisposable
    {
        System.Data.Entity.DbSet<Acceso> Accesoes { get; set; } // TBL_ACCESOS
        System.Data.Entity.DbSet<ClientesTodo> ClientesTodoes { get; set; } // TBL_CLIENTES_TODOS
        System.Data.Entity.DbSet<DatosAdicionalesCliente> DatosAdicionalesClientes { get; set; } // TBL_DATOS_ADICIONALES_CLIENTES
        System.Data.Entity.DbSet<GestionOutbound> GestionOutbounds { get; set; } // TBL_GESTION_OUTBOUND
        System.Data.Entity.DbSet<Linea> Lineas { get; set; } // TBL_LINEA
        System.Data.Entity.DbSet<ModosLogin> ModosLogins { get; set; } // TBL_MODOS_LOGINS
        System.Data.Entity.DbSet<PreguntasDesbloqueo> PreguntasDesbloqueos { get; set; } // TBL_PREGUNTAS_DESBLOQUEO
        System.Data.Entity.DbSet<RegistroSesion> RegistroSesions { get; set; } // TBL_REGISTRO_SESION
        System.Data.Entity.DbSet<Usuario> Usuarios { get; set; } // TBL_USUARIOS
        System.Data.Entity.DbSet<UsuariosXAcceso> UsuariosXAccesoes { get; set; } // TBL_USUARIOS_X_ACCESOS
        System.Data.Entity.DbSet<UsuariosXPreguntasDesb> UsuariosXPreguntasDesbs { get; set; } // TBL_USUARIOS_X_PREGUNTAS_DESB
        System.Data.Entity.DbSet<TmpMaestroHobbiesCliente> TmpMaestroHobbiesClientes { get; set; } // TMP_MAESTRO_HOBBIES_CLIENTE
        System.Data.Entity.DbSet<ConvenioElectronico> ConvenioElectronicoes { get; set; } // TBL_CONVENIO_ELECTRONICO
        System.Data.Entity.DbSet<CierreCiclo> CierreCicloes { get; set; } // TBL_CIERRE_CICLO
        System.Data.Entity.DbSet<ClaroVideo> ClaroVideos { get; set; } // TBL_CLARO_VIDEO
        System.Data.Entity.DbSet<DocsisOverlap> DocsisOverlaps { get; set; } // TBL_DOCSIS_OVERLAP
        System.Data.Entity.DbSet<Ingreso> Ingresoes { get; set; } // TBL_INGRESOS
        System.Data.Entity.DbSet<NotasIngreso> NotasIngresoes { get; set; } // TBL_NOTAS_INGRESO
        System.Data.Entity.DbSet<MaestroMarcacione> MaestroMarcaciones { get; set; } //TMP_MAESTRO_MARCACION
        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);

        // Stored Procedures
        int ApartarCuentaGestionOutboundAsesor(int? idAsesor, string gestion);
        // ApartarCuentaGestionOutboundAsesorAsync cannot be created due to having out parameters, or is relying on the procedure result (int)

        int Consultas(decimal? nombreCab, System.Data.DataTable detalles);
        // ConsultasAsync cannot be created due to having out parameters, or is relying on the procedure result (int)

    }

}


