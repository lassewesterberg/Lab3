﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Abstract
{
    interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
