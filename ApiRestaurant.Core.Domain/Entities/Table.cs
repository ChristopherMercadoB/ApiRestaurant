using ApiRestaurant.Core.Domain.Common;


namespace ApiRestaurant.Core.Domain.Entities
{
    public class Table:BaseEntity
    {
        public int PeopleQuantity { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public List<Order> Orders { get; set; }
    }
}
