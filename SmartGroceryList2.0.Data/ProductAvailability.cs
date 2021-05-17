using SmartGroceryList2._0.Data.Enums;
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
        public bool ItemIsCarriedByStore { get; set; }

        public bool ItemIsOutOfStock { get; set; }

        public Quality QualityType { get; set; }
    }
}
