﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTO_S.Account
{
    public class JWTResponse
    {
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
