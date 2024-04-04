using ApiRestaurant.Core.Domain.Common;


namespace ApiRestaurant.Core.Domain.Entities
{
    public class Dish:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PeopleQuantity { get; set; }
        public string Category { get; set; }
        public List<DishIngredient> DishIngredients { get; set; }
        public List<OrderDish> OrderDishes { get; set; }
    }
}
