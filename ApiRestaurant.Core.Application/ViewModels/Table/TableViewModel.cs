using ApiRestaurant.Core.Application.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.Table
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public int PeopleQuantity { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public List<OrderViewModel>? Orders { get; set; }
    }
}
