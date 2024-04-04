using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiRestaurant.Core.Application.ViewModels.Ingredient
{
    public class IngredientSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.Text, ErrorMessage = "Debe introducir un campo de texto")]
        public string Name { get; set; }
    }
}
