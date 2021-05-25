using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class ShoppingListDetail
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

    }
}
