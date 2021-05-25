using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class CartEdit
    {
        public int Id { get; set;}

        public int CustomerId { get; set; }

        //Might not need this
        public ICollection<ShoppingList> CartItems { get; set; }
    }
}
