using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class CustomerListItem
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CustomerName { get { return $"{FirstName} {LastName}"; } }

        public Guid OwnerId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual List<ShoppingList> Lists { get; set; } = new List<ShoppingList>();
    }
}
