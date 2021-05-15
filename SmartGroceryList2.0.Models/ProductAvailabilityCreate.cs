using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class ProductAvailabilityCreate
    {

        [Required]
        public string ItemName { get; set; }

        public bool ItemIsCarriedByStore { get; set; }

        public bool ItemIsOutOfStock { get; set; }

        public enum Quality { Damaged, Overpriced, Poor }
    }
}
