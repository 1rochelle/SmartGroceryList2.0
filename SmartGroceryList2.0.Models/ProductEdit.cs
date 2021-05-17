using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class ProductEdit
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public Department DepartmentType { get; set; }

        public ItemType ItemType { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
