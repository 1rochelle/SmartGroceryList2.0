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
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string StoreName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        public string StoreAddressNumber { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string StoreStreetName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string StoreTownOrCity { get; set; }

        [Required]
        public StoreState StoreState { get; set; }

        [Required]
        [Range(5,5)]
        public int StoreZIP { get; set; }
    }
}
