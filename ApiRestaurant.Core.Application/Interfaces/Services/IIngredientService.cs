using ApiRestaurant.Core.Application.ViewModels.Ingredient;
using ApiRestaurant.Core.Application.ViewModels.Table;
using ApiRestaurant.Core.Domain.Entities;

namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface IIngredientService : IGenericService<IngredientViewModel, IngredientSaveViewModel, Ingredient>
    {
    }
}
