using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Domain.Entities;
using ApiRestaurant.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace ApiRestaurant.Infrastructure.Persistence.Repositories
{
    
    public class OrderDishRepository : IOrderDishRepository
    {
        private readonly ApplicationContext _context;
        public OrderDishRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(OrderDish entity)
        {
            await _context.Set<OrderDish>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int dishId, int orderId)
        {
            var entity = await _context.Set<OrderDish>().FirstOrDefaultAsync(d=>d.OrderId == orderId && d.DishId == dishId);
            if (entity != null)
            {
                _context.Set<OrderDish>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OrderDish>> GetAllInclude(List<string> properties)
        {
            var query = _context.Set<OrderDish>().AsQueryable();
            if (properties != null)
            {
                foreach (var item in properties)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<List<OrderDish>> GetByOrderIdAsync(int id)
        {
            return await _context.Set<OrderDish>().Where(d=>d.OrderId == id).ToListAsync();
        }
    }
}
