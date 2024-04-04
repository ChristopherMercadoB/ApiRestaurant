using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface IGenericService<ViewModel, SaveViewModel, Entity>
        where ViewModel : class
        where SaveViewModel : class
        where Entity : class
    {
        Task<List<ViewModel>> GetAll();
        Task<SaveViewModel> GetById(int id);
        Task Create(SaveViewModel vm);
        Task Delete(int id);
        Task Update(SaveViewModel vm, int id);
    }
}
