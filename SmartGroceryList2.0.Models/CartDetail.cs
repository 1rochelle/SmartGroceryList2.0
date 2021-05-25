using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class CartDetail
    {
        public int Id { get; set; }

        public Guid OwnerId { get; set; }

        public int CustomerId { get; set; }

        public ICollection<ShoppingList> CartItems { get; set; }

    }
}
