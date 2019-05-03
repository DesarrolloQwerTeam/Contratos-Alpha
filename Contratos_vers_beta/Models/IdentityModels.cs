using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Contratos_vers_beta.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<Organizacion> Organizacion { get; set; }
        DbSet<Contrato> Contrato { get; set; }
        DbSet<Usuario> Usuario{ get; set; }
        DbSet<PDFContratos> PDFContrato{ get; set; }
        DbSet<ManageAccount> RegistrosUsuario { get; set; }
        DbSet<ModifiedContratos> RegistroModificacion { get; set; }
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Un usuario necesita una organización, una organización tiene muchos usuarios
            modelBuilder.Entity<Usuario>().HasRequired(x => x.Organizacion).WithMany(t => t.Usuarios);
            //Un usuario tiene muchos registros, cada registro pertenece a un usuario
            modelBuilder.Entity<Usuario>().HasMany(x => x.Registros).WithRequired(t => t.Usuario);
            //Un contrato necesita una organización, una organización tiene muchos contratos
            modelBuilder.Entity<Contrato>().HasRequired(x => x.Organizacion).WithMany(t => t.Contratos);
            //Un contrato puede o no tener un PDFContrato, un PDFContrato pertenece a un Contrato
            modelBuilder.Entity<Contrato>().HasOptional(x => x.PDFContrato).WithRequired(t => t.Contrato);
            //Un contrato tiene muchas modificaciones de Contrato, cada modificación pertenece a un contrato
            modelBuilder.Entity<Contrato>().HasMany(x => x.ModificacionContrato).WithRequired(t => t.Contrato);
            //Una modificación de Contrato pertenece a un usuario
            modelBuilder.Entity<ModifiedContratos>().HasRequired(x => x.Usuario);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}