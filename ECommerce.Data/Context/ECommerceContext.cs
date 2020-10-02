﻿using ECommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Context
{
  public  class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

      public virtual DbSet<Product> Product { get; set; }
      public virtual DbSet<Category> Category { get; set; }
    }
}
