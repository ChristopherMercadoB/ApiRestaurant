using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.Dish;
using ApiRestaurant.Core.Application.ViewModels.Ingredient;
using ApiRestaurant.Core.Domain.Entities;
using AutoMapper;
using System.Xml.Linq;

namespace ApiRestaurant.Core.Application.Services
{
    public class DishService : GenericService<DishViewModel, DishSaveViewModel, Dish>, IDishService
    {
        private readonly IMapper _mapper;
        private readonly IDishRepository _reposttory;
        private readonly IDishIngredientRepository _dishIngredientreposttory;
        public DishService(IMapper mapper, IDishRepository repository, IDishIngredientRepository dishIngredientRepository) : base(mapper, repository)
        {
            _mapper = mapper;
            _reposttory = repository;
            _dishIngredientreposttory = dishIngredientRepository;
        }

        public async Task CreateWithIngredients(DishSaveViewModel vm)
        {
            var dish = _mapper.Map<Dish>(vm);

            dish = await _reposttory.AddAsync(dish);

            foreach (var ingredientId in vm.IngredientsIds)
            {
                var dishIngredient = new DishIngredient
                {
                    DishId = dish.Id,
                    IngredientId = ingredientId
                };

                await _dishIngredientreposttory.CreateAsync(dishIngredient);
            }
        }

        public async Task<List<DishViewModel>> GetAllInclude()
        {
            var dishes = await _reposttory.GetAllInclude();
            return dishes.Select(x => new DishViewModel
            {
                Id = x.Id,
                Name = x.Name,
                PeopleQuantity = x.PeopleQuantity,
                Price = x.Price,
                Category = x.Category,
                Ingredients = x.DishIngredients.Select(y => new IngredientViewModel
                {
                    Id = y.Ingredient.Id,
                    Name = y.Ingredient.Name
                }).ToList()
            }).ToList();
        }

        public async Task<DishViewModel> GetByIdWithIngredients(int id)
        {
            var dish = await _reposttory.GetByIdIncludeAsync(id);
            if (dish == null)
            {
                throw new Exception("Dish not found");
            }
            DishViewModel vm = new();
            vm.Id = dish.Id;
            vm.Name = dish.Name;
            vm.PeopleQuantity = dish.PeopleQuantity;
            vm.Price = dish.Price;
            vm.Category = dish.Category;
            vm.Ingredients = dish.DishIngredients == null || dish.DishIngredients.Count == 0 ? null : dish.DishIngredients.Select(x => new IngredientViewModel
            {
                Id = x.Ingredient.Id,
                Name = x.Ingredient.Name
            }).ToList();

            return vm;
        }

        public async Task UpdateWithIngredients(DishSaveViewModel vm, int id)
        {
            var dish = await _reposttory.GetByIdAsync(id);

            if (dish == null)
            {
                throw new Exception("Dish not found");
            }

            var updatedDish = _mapper.Map<Dish>(vm);
            updatedDish.Id = dish.Id;

            await _reposttory.UpdateAsync(updatedDish, id);
            var currentIngredients = await _dishIngredientreposttory.GetByDishIdAsync(dish.Id);
            var currentIngredientsIds = currentIngredients.Select(pi => pi.IngredientId).ToList();
            var newIngredientsIds = vm.IngredientsIds;

            if (vm.IngredientsIds != null || vm.IngredientsIds.Count != 0)
            {


                foreach (var ingredientId in currentIngredientsIds.Except(newIngredientsIds))
                {
                    var dishIngredient = currentIngredientsIds.FirstOrDefault(pi => pi == ingredientId);
                    await _dishIngredientreposttory.DeleteAsync(dishIngredient, id);
                }

                foreach (var ingredientId in newIngredientsIds.Except(currentIngredientsIds))
                {
                    var dishIngredient = new DishIngredient
                    {
                        DishId = dish.Id,
                        IngredientId = ingredientId
                    };

                    await _dishIngredientreposttory.CreateAsync(dishIngredient);

                }
            }

            foreach (var ingredientId in currentIngredientsIds.Except(newIngredientsIds))
            {
                var dishIngredient = currentIngredientsIds.FirstOrDefault(pi => pi == ingredientId);
                await _dishIngredientreposttory.DeleteAsync(dishIngredient, id);
            }

        }
    }
}
