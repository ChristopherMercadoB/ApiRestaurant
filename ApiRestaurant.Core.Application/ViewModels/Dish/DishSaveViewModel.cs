using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.Dish
{
    public class DishSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Field required")]
        public int PeopleQuantity { get; set; }
        [Required(ErrorMessage = "Field required")]
        public string Category { get; set; }
        [NotMapped]
        public List<int>? IngredientsIds { get; set; }
    }
}
