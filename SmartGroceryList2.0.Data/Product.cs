using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Data
{
    public enum ItemType { Refrigerated, Frozen, Produce, DryGoods, Household, PersonalCare }
    public enum Department { Grocery, Household, PersonalCare, Other }
    public class Product : ProductAvailability
    {
        
        public Department DepartmentType { get; set; }
        

        [Key]
        public int Id { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "There are not enough characters in this field.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string ItemName { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        // Terry, I added this:
        public DateTimeOffset ModifiedUtc { get; set; }

        //public List<Product> MultiplePurchasesOfItem = new List<Product>();

        public int ItemCount { get; set; }

        [DefaultValue(false)]
        public bool PurchasedAtMultipleStores { get; set; }

        public ItemType ItemType { get; set; }
        

        // Foreign Keys here

        [Required]
        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public  Store Store { get; set; }

        public virtual List<Customer> Customers { get; set; } = new List<Customer>();

        public virtual List<ShoppingList> Carts { get; set; } = new List<ShoppingList>();
    }
}
