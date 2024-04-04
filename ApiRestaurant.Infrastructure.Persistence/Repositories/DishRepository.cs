using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Domain.Entities;
using ApiRestaurant.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Infrastructure.Persistence.Repositories
{
    
    public class DishRepository:GenericRepository<Dish>, IDishRepository
    {
        private readonly ApplicationContext _context;
        public DishRepository(ApplicationContext context) :base(context)
        {
            _context = context;
        }

        public async Task AddWithIngredient(int dishId, int ingredientId)
        {
            DishIngredient dishIngredient = new()
            {
                DishId = dishId,
                IngredientId = ingredientId
            };
            await _context.Set<DishIngredient>().AddAsync(dishIngredient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dish>> GetAllInclude()
        {
            return await _context.Set<Dish>().Include(d => d.DishIngredients).ThenInclude(d => d.Ingredient).ToListAsync();
        }

        public async Task<Dish> GetByIdIncludeAsync(int id)
        {
            return await _context.Set<Dish>().Include(d => d.DishIngredients).ThenInclude(d => d.Ingredient)
                .FirstOrDefaultAsync(d=>d.Id == id);
        }
    }
}
