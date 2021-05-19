﻿using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CustomerName { get { return $"{FirstName} {LastName}"; } }

        public Guid OwnerId { get; set; }

        //public int ProductId { get; set; }
        public virtual List<Cart> CartItems { get; set; } = new List<Cart>();

    }
}