using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.Dish;
using ApiRestaurant.Core.Application.ViewModels.Order;
using ApiRestaurant.Core.Domain.Entities;
using AutoMapper;

namespace ApiRestaurant.Core.Application.Services
{
    public class OrderService : GenericService<OrderViewModel, OrderSaveViewModel, Order>, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _reposttory;
        private readonly IOrderDishRepository _orderDishRepository;
        public OrderService(IMapper mapper, IOrderRepository repository, IOrderDishRepository orderDishRepository) : base(mapper, repository)
        {
            _mapper = mapper;
            _reposttory = repository;
            _orderDishRepository = orderDishRepository;

        }

        public async Task CreateWithDish(OrderSaveViewModel vm)
        {
            var order = _mapper.Map<Order>(vm);

            order = await _reposttory.AddAsync(order);

            if (vm.DishesIds != null)
            {
                foreach (var dishId in vm.DishesIds)
                {
                    var orderDish = new OrderDish
                    {
                        DishId = dishId,
                        OrderId = order.Id
                    };

                    await _orderDishRepository.CreateAsync(orderDish);
                }
            }
        }

        public async Task<List<OrderViewModel>> GetAllInclude()
        {
            var orders = await _reposttory.GetAllInclude();
            return orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                TableId = x.TableId,
                State = x.State,
                Total = x.Total,
                Dishes = x.OrderDishes.Select(y => new DishViewModel
                {
                    Id = y.Dish.Id,
                    Name = y.Dish.Name,
                    Category = y.Dish.Category,
                    PeopleQuantity = y.Dish.PeopleQuantity,
                    Price = y.Dish.Price,
                }).ToList()
            }).ToList();
        }

        public async Task<OrderViewModel> GetByIdWithDishes(int id)
        {
            var order = await _reposttory.GetByIdIncludeAsync(id);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            OrderViewModel vm = new();
            vm.Id = order.Id;
            vm.TableId = order.TableId;
            vm.State = order.State;
            vm.Total = order.Total;
            vm.Dishes = order.OrderDishes == null || order.OrderDishes.Count == 0 ? null : order.OrderDishes.Select(x => new DishViewModel
            {
                Id = x.Dish.Id,
                Category = x.Dish.Category,
                Name = x.Dish.Name,
                PeopleQuantity = x.Dish.PeopleQuantity,
                Price = x.Dish.Price,
            }).ToList();

            return vm;
        }

        public async Task UpdateWithDish(OrderSaveViewModel vm, int id)
        {
            var order = await _reposttory.GetByIdAsync(id);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            var updatedOrder = _mapper.Map<Order>(vm);
            updatedOrder.Id = order.Id;

            await _reposttory.UpdateAsync(updatedOrder, id);
            var currentDish = await _orderDishRepository.GetByOrderIdAsync(order.Id);
            var currentDishesIds = currentDish.Select(pi => pi.DishId).ToList();
            var newDishesIds = vm.DishesIds;

            if (vm.DishesIds != null || vm.DishesIds.Count != 0)
            {
                foreach (var dishId in currentDishesIds.Except(newDishesIds))
                {
                    var orderDish = currentDishesIds.FirstOrDefault(pi => pi == dishId);
                    await _orderDishRepository.DeleteAsync(orderDish, id);
                }

                foreach (var dishId in newDishesIds.Except(currentDishesIds))
                {
                    var orderDish = new OrderDish
                    {

                        DishId = dishId,
                        OrderId = order.Id
                    };

                    await _orderDishRepository.CreateAsync(orderDish);

                }
            }

            foreach (var dishId in currentDishesIds.Except(newDishesIds))
            {
                var orderDish = currentDishesIds.FirstOrDefault(pi => pi == dishId);
                await _orderDishRepository.DeleteAsync(orderDish, id);
            }

        }
    }
}
