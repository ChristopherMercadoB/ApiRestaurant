using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.Ingredient;
using ApiRestaurant.Core.Domain.Entities;
using AutoMapper;


namespace ApiRestaurant.Core.Application.Services
{
    public class IngredientService : GenericService<IngredientViewModel, IngredientSaveViewModel, Ingredient>, IIngredientService
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _reposttory;
        public IngredientService(IMapper mapper, IIngredientRepository repository):base(mapper, repository)
        {
            _mapper = mapper;
            _reposttory = repository;
        }
    }
}
