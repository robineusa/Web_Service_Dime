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
    public class FakeMaestrosContext : IMaestrosContext
    {
        public System.Data.Entity.DbSet<Deakloclpalo> Deakloclpaloes { get; set; }
        public System.Data.Entity.DbSet<Departamento> Departamentoes { get; set; }
        public System.Data.Entity.DbSet<Estado> Estadoes { get; set; }
        public System.Data.Entity.DbSet<Macroproceso> Macroprocesoes { get; set; }
        public System.Data.Entity.DbSet<MaestroAtributo> MaestroAtributoes { get; set; }
        public System.Data.Entity.DbSet<MaestroCausa> MaestroCausas { get; set; }
        public System.Data.Entity.DbSet<MaestroCierre> MaestroCierres { get; set; }
        public System.Data.Entity.DbSet<MaestroEstadoMarcacion> MaestroEstadoMarcacions { get; set; }
        public System.Data.Entity.DbSet<MaestroGestion> MaestroGestions { get; set; }
        public System.Data.Entity.DbSet<MaestroHipotesi> MaestroHipotesis { get; set; }
        public System.Data.Entity.DbSet<MaestroOutboundCausa> MaestroOutboundCausas { get; set; }
        public System.Data.Entity.DbSet<MaestroOutboundCierre> MaestroOutboundCierres { get; set; }
        public System.Data.Entity.DbSet<MaestroOutboundCierre2> MaestroOutboundCierre2 { get; set; }
        public System.Data.Entity.DbSet<MaestroOutboundMotivo> MaestroOutboundMotivoes { get; set; }
        public System.Data.Entity.DbSet<MaestroOutboundRazon> MaestroOutboundRazons { get; set; }
        public System.Data.Entity.DbSet<MaestroOutboundTipoContacto> MaestroOutboundTipoContactoes { get; set; }
        public System.Data.Entity.DbSet<MaestroOutboundTipoGestion> MaestroOutboundTipoGestions { get; set; }
        public System.Data.Entity.DbSet<MaestroRazon> MaestroRazons { get; set; }
        public System.Data.Entity.DbSet<MaestroTiemposEsca> MaestroTiemposEscas { get; set; }
        public System.Data.Entity.DbSet<MaestroTipoContacto> MaestroTipoContactoes { get; set; }
        public System.Data.Entity.DbSet<MarcacionesCall> MarcacionesCalls { get; set; }
        public System.Data.Entity.DbSet<Municipio> Municipios { get; set; }
        public System.Data.Entity.DbSet<NombreLinea> NombreLineas { get; set; }
        public System.Data.Entity.DbSet<Proceso> Procesoes { get; set; }
        public System.Data.Entity.DbSet<RolUsuario> RolUsuarios { get; set; }
        public System.Data.Entity.DbSet<Servicio> Servicios { get; set; }
        public System.Data.Entity.DbSet<SubProceso> SubProcesoes { get; set; }
        public System.Data.Entity.DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public System.Data.Entity.DbSet<UsuariosGenerico> UsuariosGenericoes { get; set; }
        public System.Data.Entity.DbSet<VActualizarSemaforo> VActualizarSemaforoes { get; set; }

        public FakeMaestrosContext()
        {
            Deakloclpaloes = new FakeDbSet<Deakloclpalo>("RowNumber");
            Departamentoes = new FakeDbSet<Departamento>("IdDepartamento");
            Estadoes = new FakeDbSet<Estado>("IdEstado");
            Macroprocesoes = new FakeDbSet<Macroproceso>("IdMacroProceso", "Descripcion");
            MaestroAtributoes = new FakeDbSet<MaestroAtributo>("IdAtributo", "Servicio");
            MaestroCausas = new FakeDbSet<MaestroCausa>("IdCausa", "Causa");
            MaestroCierres = new FakeDbSet<MaestroCierre>("IdCierre", "Cierre");
            MaestroEstadoMarcacions = new FakeDbSet<MaestroEstadoMarcacion>("IdEstado");
            MaestroGestions = new FakeDbSet<MaestroGestion>("IdTipoGestion");
            MaestroHipotesis = new FakeDbSet<MaestroHipotesi>("IdHipotesis", "Hipotesis");
            MaestroOutboundCausas = new FakeDbSet<MaestroOutboundCausa>("IdCausa");
            MaestroOutboundCierres = new FakeDbSet<MaestroOutboundCierre>("IdCierre");
            MaestroOutboundCierre2 = new FakeDbSet<MaestroOutboundCierre2>("IdCierre", "IdTipoContacto", "Cierre");
            MaestroOutboundMotivoes = new FakeDbSet<MaestroOutboundMotivo>("IdMotivo");
            MaestroOutboundRazons = new FakeDbSet<MaestroOutboundRazon>("IdRazon");
            MaestroOutboundTipoContactoes = new FakeDbSet<MaestroOutboundTipoContacto>("IdTipoContacto");
            MaestroOutboundTipoGestions = new FakeDbSet<MaestroOutboundTipoGestion>("IdTipoGestion");
            MaestroRazons = new FakeDbSet<MaestroRazon>("IdRazon");
            MaestroTiemposEscas = new FakeDbSet<MaestroTiemposEsca>("IdMarcacion");
            MaestroTipoContactoes = new FakeDbSet<MaestroTipoContacto>("IdTipoContacto");
            MarcacionesCalls = new FakeDbSet<MarcacionesCall>("Id");
            Municipios = new FakeDbSet<Municipio>("IdMunicipio");
            NombreLineas = new FakeDbSet<NombreLinea>("IdNombreLinea", "NombreLinea_");
            Procesoes = new FakeDbSet<Proceso>("IdProceso", "Descripcion", "IdMacroProceso");
            RolUsuarios = new FakeDbSet<RolUsuario>("IdRol", "Descripcion");
            Servicios = new FakeDbSet<Servicio>("IdServicio");
            SubProcesoes = new FakeDbSet<SubProceso>("IdSubProceso", "Descripcion");
            Sysdiagrams = new FakeDbSet<Sysdiagram>("DiagramId");
            UsuariosGenericoes = new FakeDbSet<UsuariosGenerico>("Cedula");
            VActualizarSemaforoes = new FakeDbSet<VActualizarSemaforo>("IdIngreso");
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

        // Stored Procedures
        public int ReporteMRazonCe()
        {
 
            return 0;
        }

        public System.Collections.Generic.List<SeleccionLineaPAsesorReturnModel> SeleccionLineaPAsesor()
        {
            int procResult;
            return SeleccionLineaPAsesor(out procResult);
        }

        public System.Collections.Generic.List<SeleccionLineaPAsesorReturnModel> SeleccionLineaPAsesor(out int procResult)
        {

            procResult = 0;
            return new System.Collections.Generic.List<SeleccionLineaPAsesorReturnModel>();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<SeleccionLineaPAsesorReturnModel>> SeleccionLineaPAsesorAsync()
        {
            int procResult;
            return System.Threading.Tasks.Task.FromResult(SeleccionLineaPAsesor(out procResult));
        }

        public System.Collections.Generic.List<SeleccionaPerfilesReturnModel> SeleccionaPerfiles()
        {
            int procResult;
            return SeleccionaPerfiles(out procResult);
        }

        public System.Collections.Generic.List<SeleccionaPerfilesReturnModel> SeleccionaPerfiles(out int procResult)
        {

            procResult = 0;
            return new System.Collections.Generic.List<SeleccionaPerfilesReturnModel>();
        }

        public System.Threading.Tasks.Task<System.Collections.Generic.List<SeleccionaPerfilesReturnModel>> SeleccionaPerfilesAsync()
        {
            int procResult;
            return System.Threading.Tasks.Task.FromResult(SeleccionaPerfiles(out procResult));
        }

    }
}
// </auto-generated>