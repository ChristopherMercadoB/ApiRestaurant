﻿using ApiRestaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Entities
{
    public class Ingredient:BaseEntity
    {
        public string Name { get; set; }
        public List<DishIngredient> DishIngredients { get; set; }
    }
}
