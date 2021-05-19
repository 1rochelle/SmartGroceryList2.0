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

        public DateTimeOffset PurchaseDate { get; set; }
      
    }
}
