using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class ProductCreate
    {
        [Required]
        public string ItemName { get; set; } 
        
        [Required]
        public Department DepartmentType { get; set; }

        [Required]
        public ItemType ItemType { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public int ItemCount { get; set; }
    }
}
