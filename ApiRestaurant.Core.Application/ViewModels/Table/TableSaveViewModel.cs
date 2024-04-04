

using ApiRestaurant.Core.Application.ViewModels.Order;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiRestaurant.Core.Application.ViewModels.Table
{
    public class TableSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field required")]
        public int PeopleQuantity { get; set; }
        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.Text, ErrorMessage = "Insert a text")]
        public string Description { get; set; }
    }
}
