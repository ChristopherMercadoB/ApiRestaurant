using ApiRestaurant.Core.Application.ViewModels.Dish;


namespace ApiRestaurant.Core.Application.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public decimal Total { get; set; }
        public bool State { get; set; }
        public List<DishViewModel>? Dishes { get; set; }
    }
}
