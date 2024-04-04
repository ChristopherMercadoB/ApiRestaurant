using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Domain.Entities;
using ApiRestaurant.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace ApiRestaurant.Infrastructure.Persistence.Repositories
{
    
    public class DishIngredientRepository : IDishIngredientRepository
    {
        private readonly ApplicationContext _context;
        public DishIngredientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DishIngredient entity)
        {
            await _context.Set<DishIngredient>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ingredientId, int dishId)
        {
            var entity = await _context.Set<DishIngredient>().FirstOrDefaultAsync(d=>d.IngredientId == ingredientId && d.DishId == dishId);
            if (entity != null)
            {
                _context.Set<DishIngredient>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DishIngredient>> GetByDishIdAsync(int id)
        {
            return await _context.Set<DishIngredient>().Where(d=>d.DishId == id).ToListAsync();
        }
    }
}
