// <auto-generated>
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

namespace Telmexla.Servicios.DIME.Helpers.ReverseEngineer
{

    using System.Linq;

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class FakeDimeContext : IDimeContext
    {
        public System.Data.Entity.DbSet<Acceso> Accesoes { get; set; }
        public System.Data.Entity.DbSet<Linea> Lineas { get; set; }
        public System.Data.Entity.DbSet<ModosLogin> ModosLogins { get; set; }
        public System.Data.Entity.DbSet<PreguntasDesbloqueo> PreguntasDesbloqueos { get; set; }
        public System.Data.Entity.DbSet<RegistroSesion> RegistroSesions { get; set; }
        public System.Data.Entity.DbSet<Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<UsuariosXAcceso> UsuariosXAccesoes { get; set; }
        public System.Data.Entity.DbSet<UsuariosXPreguntasDesb> UsuariosXPreguntasDesbs { get; set; }

        public FakeDimeContext()
        {
            Accesoes = new FakeDbSet<Acceso>("Id");
            Lineas = new FakeDbSet<Linea>("Id");
            ModosLogins = new FakeDbSet<ModosLogin>("Id");
            PreguntasDesbloqueos = new FakeDbSet<PreguntasDesbloqueo>("Id");
            RegistroSesions = new FakeDbSet<RegistroSesion>("Id");
            Usuarios = new FakeDbSet<Usuario>("Id");
            UsuariosXAccesoes = new FakeDbSet<UsuariosXAcceso>("Id", "IdAcceso", "IdUsuario");
            UsuariosXPreguntasDesbs = new FakeDbSet<UsuariosXPreguntasDesb>("Id", "IdPregunta", "IdUsuario");
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
// </auto-generated>
