using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Data
{
    public class ProductAvailability
    {
        
        [Key, ForeignKey(nameof(ItemName))]
        public Guid ItemId { get; set; }
        public virtual Product ItemName { get; set; }

        public bool ItemIsCarriedByStore { get; set; }

        public bool ItemIsOutOfStock { get; set; }

        public enum Quality { Damaged, Overpriced, Poor }
    }
}
