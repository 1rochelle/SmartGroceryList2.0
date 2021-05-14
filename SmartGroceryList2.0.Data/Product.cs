using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Data
{
    public class Product
    {
        public enum Department { Grocery, Household, PersonalCare, Other }

        [Key]
        public Guid ItemId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "There are not enough characters in this field.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string ItemName { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public List<Product> MultiplePurchasesOfItem = new List<Product>();

        public int ItemCount { get; set; }

        [DefaultValue(false)]
        public bool PurchasedAtMultipleStores { get; set; }

        public enum ItemType { Refrigerated, Frozen, Produce, DryGoods, Household, PersonalCare }

        // Foreign Keys here
        [Required]
        [ForeignKey(nameof(UserName))]
        public Guid UserId { get; set; }
        public virtual User UserName { get; set; }

        [Required]
        [ForeignKey(nameof(StoreName))]
        public int StoreId { get; set; }
        public virtual Store StoreName { get; set; }
    }
}
