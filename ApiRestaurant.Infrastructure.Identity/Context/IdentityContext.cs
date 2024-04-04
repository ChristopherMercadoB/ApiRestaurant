using ApiRestaurant.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ApiRestaurant.Infrastructure.Identity.Context
{
    public class IdentityContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.HasDefaultSchema("Identity");

            model.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name:"User");
            });

            model.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            model.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRole");
            });

            model.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogin");
            });
        }
    }
}
