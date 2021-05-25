using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Data
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<ShoppingList> CartItems { get; set; } = new List<ShoppingList>();

        public Guid OwnerId { get; set; }


        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
