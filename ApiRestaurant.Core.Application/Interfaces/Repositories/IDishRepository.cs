using ApiRestaurant.Core.Domain.Entities;


namespace ApiRestaurant.Core.Application.Interfaces.Repositories
{
    public interface IDishRepository:IGenericRepository<Dish>
    {
        Task AddWithIngredient(int dishId, int ingredientId);
        Task<Dish> GetByIdIncludeAsync(int id);
        Task<List<Dish>> GetAllInclude();
    }
}
