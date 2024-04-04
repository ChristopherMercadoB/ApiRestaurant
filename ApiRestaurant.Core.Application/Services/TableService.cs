using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.Dish;
using ApiRestaurant.Core.Application.ViewModels.Order;
using ApiRestaurant.Core.Application.ViewModels.Table;
using ApiRestaurant.Core.Domain.Entities;
using AutoMapper;

namespace ApiRestaurant.Core.Application.Services
{
    public class TableService : GenericService<TableViewModel, TableSaveViewModel, Table>, ITableService
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _reposttory;
        private readonly IOrderRepository _orderRepository;
        public TableService(IMapper mapper, ITableRepository repository, IOrderRepository orderRepository) : base(mapper, repository)
        {
            _mapper = mapper;
            _reposttory = repository;
            _orderRepository = orderRepository;

        }

        public async Task<TableViewModel> GetTableWithOrdersById(int id)
        {
            var table = await _reposttory.GetByIdAsync(id);
            var orders = await _orderRepository.GetAllAsync();
            orders = orders.Where(o => o.TableId == id && o.State == false).ToList();
            var order = _mapper.Map<List<OrderViewModel>>(orders);
            var tableWithOrder = _mapper.Map<TableViewModel>(table);
            tableWithOrder.Orders = order != null ? order : null;

            return tableWithOrder;
        }

        public async Task ChangeState(int id)
        {
            var entity = await _reposttory.GetByIdAsync(id);
            entity.State = true;
            await _reposttory.UpdateAsync(entity, id);
        }
    }
}
