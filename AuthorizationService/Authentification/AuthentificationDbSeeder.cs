using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using AuthorizationService.Authentification.Data.Enums;

namespace AuthorizationService.Authentification
{
    public static class AuthentificationDbSeeder
    {
        public static void SeedDatabase(ModelBuilder builder)
        {
            SeedUsers(builder.Entity<IdentityUser>());
            SeedRoles(builder.Entity<IdentityRole>());
        }
        private static void SeedRoles(EntityTypeBuilder<IdentityRole> rolesBuilder)
        {
            /*foreach (var roleName in System.Enum.GetNames(typeof(UserRole)))
            {
                rolesBuilder.HasData(new IdentityRole(roleName));
            }*/
        }
        private static void SeedUsers(EntityTypeBuilder<IdentityUser> usersBuilder)
        {

        }
    }
}
