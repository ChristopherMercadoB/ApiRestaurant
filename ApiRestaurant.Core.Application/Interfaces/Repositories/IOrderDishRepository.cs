using ApiRestaurant.Core.Domain.Entities;


namespace ApiRestaurant.Core.Application.Interfaces.Repositories
{
    public interface IOrderDishRepository
    {
        Task<List<OrderDish>> GetByOrderIdAsync(int orderId);
        Task DeleteAsync(int orderId, int dishId);
        Task CreateAsync(OrderDish entity);
        Task<List<OrderDish>> GetAllInclude(List<string> properties);

    }
}
