using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CustomerName { get { return $"{FirstName} {LastName}"; } }

        public Guid OwnerId { get; set; }

        public virtual List<ShoppingList> Lists { get; set; } = new List<ShoppingList>();

        public virtual List<Cart> CartItems { get; set; } = new List<Cart>();

        public DateTimeOffset PurchaseDate { get; set; }

    }
}
