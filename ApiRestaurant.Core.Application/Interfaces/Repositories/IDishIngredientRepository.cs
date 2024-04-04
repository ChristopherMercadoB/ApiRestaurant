using ApiRestaurant.Core.Domain.Entities;


namespace ApiRestaurant.Core.Application.Interfaces.Repositories
{
    public interface IDishIngredientRepository
    {
        Task<List<DishIngredient>> GetByDishIdAsync(int dishId);
        Task DeleteAsync(int ingredientId, int dishId);
        Task CreateAsync(DishIngredient entity);

    }
}
