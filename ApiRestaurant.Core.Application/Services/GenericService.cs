using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Services
{
    public class GenericService<ViewModel, SaveViewModel, Entity> : IGenericService<ViewModel, SaveViewModel, Entity>
        where ViewModel : class
        where SaveViewModel : class
        where Entity : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Entity> _repository;
        public GenericService(IMapper mapper, IGenericRepository<Entity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task Create(SaveViewModel vm)
        {
            var entity = _mapper.Map<Entity>(vm);
            await _repository.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<ViewModel>> GetAll()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<ViewModel>>(list);
        }

        public async Task<SaveViewModel> GetById(int id)
        {
            return  _mapper.Map<SaveViewModel>(await _repository.GetByIdAsync(id));
        }

        public async Task Update(SaveViewModel vm, int id)
        {
            var entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(entity, id);
        }
    }
}
