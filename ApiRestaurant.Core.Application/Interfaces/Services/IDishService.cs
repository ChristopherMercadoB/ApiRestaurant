using ApiRestaurant.Core.Application.ViewModels.Dish;
using ApiRestaurant.Core.Domain.Entities;


namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface IDishService:IGenericService<DishViewModel, DishSaveViewModel, Dish>
    {
        Task CreateWithIngredients(DishSaveViewModel vm);
        Task UpdateWithIngredients(DishSaveViewModel vm, int id); 
        Task<DishViewModel> GetByIdWithIngredients(int id);
        Task<List<DishViewModel>> GetAllInclude();
    }
}
