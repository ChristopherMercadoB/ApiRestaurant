
using ApiRestaurant.Core.Domain.Common;

namespace ApiRestaurant.Core.Domain.Entities
{
    public class Order:BaseEntity
    {
        public int TableId { get; set; }
        public Table Table { get; set; }
        public decimal Total { get; set; }
        public bool State { get; set; }
        public List<OrderDish> OrderDishes { get; set; }
    }
}
