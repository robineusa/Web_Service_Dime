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
        System.Data.Entity.DbSet<Linea> Lineas { get; set; } // TBL_LINEA
        System.Data.Entity.DbSet<ModosLogin> ModosLogins { get; set; } // TBL_MODOS_LOGINS
        System.Data.Entity.DbSet<PreguntasDesbloqueo> PreguntasDesbloqueos { get; set; } // TBL_PREGUNTAS_DESBLOQUEO
        System.Data.Entity.DbSet<RegistroSesion> RegistroSesions { get; set; } // TBL_REGISTRO_SESION
        System.Data.Entity.DbSet<Usuario> Usuarios { get; set; } // TBL_USUARIOS
        System.Data.Entity.DbSet<UsuariosXAcceso> UsuariosXAccesoes { get; set; } // TBL_USUARIOS_X_ACCESOS
        System.Data.Entity.DbSet<UsuariosXPreguntasDesb> UsuariosXPreguntasDesbs { get; set; } // TBL_USUARIOS_X_PREGUNTAS_DESB

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
    }

}


