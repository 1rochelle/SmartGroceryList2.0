using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class ProductListItem
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
