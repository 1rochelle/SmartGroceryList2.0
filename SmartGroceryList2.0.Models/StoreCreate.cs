using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class StoreCreate
    {

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field.")]
        public string StoreName { get; set; }

        [Required]
        public string StoreAddressNumber { get; set; }

        [Required]
        public string StoreStreetName { get; set; }

        [Required]
        public string StoreTownOrCity { get; set; }

        [Required]
        public StoreState StoreState { get; set; }

        [Required]
        public int StoreZIP { get; set; }
    }
}
