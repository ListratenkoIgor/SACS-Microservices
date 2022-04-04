using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthorizationService.Authentification
{
    public class AuthentificationDbContext : IdentityDbContext
    {
        public AuthentificationDbContext(DbContextOptions<AuthentificationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            AuthentificationDbSeeder.SeedDatabase(builder);
        }
    }
}