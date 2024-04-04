using ApiRestaurant.Core.Application.ViewModels.Table;
using ApiRestaurant.Core.Domain.Entities;

namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface ITableService : IGenericService<TableViewModel, TableSaveViewModel, Table>
    {
        Task ChangeState(int id);
        Task<TableViewModel> GetTableWithOrdersById(int id);
    }
}
