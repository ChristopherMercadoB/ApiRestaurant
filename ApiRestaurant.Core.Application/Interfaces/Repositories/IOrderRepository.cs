using ApiRestaurant.Core.Domain.Entities;


namespace ApiRestaurant.Core.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task AddWithDish(int orderId, int dishId);
        Task<Order> GetByIdIncludeAsync(int id);
        Task<List<Order>> GetAllInclude();
    }
}
