using ApiRestaurant.Core.Application.ViewModels.Order;
using ApiRestaurant.Core.Domain.Entities;


namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<OrderViewModel, OrderSaveViewModel, Order>
    {
        Task CreateWithDish(OrderSaveViewModel vm);
        Task UpdateWithDish(OrderSaveViewModel vm, int id);
        Task<OrderViewModel> GetByIdWithDishes(int id);
        Task<List<OrderViewModel>> GetAllInclude();
    }
}
