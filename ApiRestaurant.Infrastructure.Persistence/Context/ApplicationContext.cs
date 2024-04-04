using ApiRestaurant.Core.Domain.Common;
using ApiRestaurant.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ApiRestaurant.Infrastructure.Persistence.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedBy = "Chris";
                        item.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        item.Entity.CreatedBy = "Chris";
                        item.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            #region Tables
            model.Entity<Dish>().ToTable("Plato");
            model.Entity<Ingredient>().ToTable("Ingrediente");
            model.Entity<Order>().ToTable("Orden");
            model.Entity<Table>().ToTable("Mesa");
            #endregion

            #region Primary Keys
            model.Entity<Dish>().HasKey(d=>d.Id);
            model.Entity<Ingredient>().HasKey(d=>d.Id);
            model.Entity<Order>().HasKey(d=>d.Id);
            model.Entity<Table>().HasKey(d=>d.Id);
            model.Entity<DishIngredient>().HasKey(k => new {k.DishId, k.IngredientId});
            model.Entity<OrderDish>().HasKey(k => new {k.DishId, k.OrderId});
            #endregion

            #region Foreign Keys
            model.Entity<Dish>()
                .HasMany<DishIngredient>(d=>d.DishIngredients)
                .WithOne(d=>d.Dish)
                .HasForeignKey(d=>d.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            model.Entity<Ingredient>()
               .HasMany<DishIngredient>(d=>d.DishIngredients)
               .WithOne(d => d.Ingredient)
               .HasForeignKey(d => d.IngredientId)
               .OnDelete(DeleteBehavior.Cascade);

            model.Entity<Order>()
               .HasMany<OrderDish>(o=>o.OrderDishes)
               .WithOne(d => d.Order)
               .HasForeignKey(d => d.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

            model.Entity<Dish>()
               .HasMany<OrderDish>(d=>d.OrderDishes)
               .WithOne(d => d.Dish)
               .HasForeignKey(d => d.DishId)
               .OnDelete(DeleteBehavior.Cascade);

            model.Entity<Table>()
                .HasMany<Order>(t => t.Orders)
                .WithOne(o => o.Table)
                .HasForeignKey(o=>o.TableId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Properties

            #region Dish
            model.Entity<Dish>()
                .Property(d => d.PeopleQuantity)
                .IsRequired();

            model.Entity<Dish>()
                .Property(d => d.Price)
                .HasColumnType("decimal(5, 0)")
                .IsRequired();


            #endregion

            #region Order
            model.Entity<Order>()
                .Property(d => d.State)
                .IsRequired();

            model.Entity<Order>()
                .Property(d => d.Total)
                .HasColumnType("decimal(5, 0)")
                .IsRequired();

            #endregion

            #region Table
            model.Entity<Table>()
              .Property(d => d.State)
              .IsRequired();

            model.Entity<Table>()
             .Property(d => d.PeopleQuantity)
             .IsRequired();

            model.Entity<Table>()
             .Property(d => d.Description)
             .IsRequired();
            #endregion

            #region Ingredient

            model.Entity<Ingredient>()
             .Property(d => d.Name)
             .IsRequired();

            #endregion
            #endregion
        }
    }
}
