
using ApiRestaurant.Core.Application.ViewModels.Dish;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRestaurant.Core.Application.ViewModels.Order
{
    public class OrderSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field required")]
        public int TableId { get; set; }
        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.Currency, ErrorMessage = "Insert A currency value")]
        public decimal Total { get; set; }
        [NotMapped]
        public bool State { get; set; } = false;
        [NotMapped]
        public List<int>? DishesIds { get; set; }
    }
}
