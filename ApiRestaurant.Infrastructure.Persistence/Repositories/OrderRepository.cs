using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Domain.Entities;
using ApiRestaurant.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurant.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _context;
        public OrderRepository(ApplicationContext context) :base(context)
        {
            _context = context;
        }

        public async Task AddWithDish(int orderId, int dishId)
        {
            OrderDish orderDish = new()
            {
                DishId = dishId,
                OrderId = orderId
            };
            await _context.Set<OrderDish>().AddAsync(orderDish);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllInclude()
        {
            return await _context
                .Set<Order>().Include(o => o.OrderDishes).ThenInclude(o => o.Dish).ToListAsync();
        }

        public async Task<Order> GetByIdIncludeAsync(int id)
        {
            var order = await _context.Set<Order>().FindAsync(id);
            if (order==null)
            {
                return null;
            }

            return await _context.Set<Order>()
                .Include(o => o.OrderDishes)
                .ThenInclude(o => o.Dish)
                .FirstOrDefaultAsync(e=>e.Id == id);

        }

       
    }
}
