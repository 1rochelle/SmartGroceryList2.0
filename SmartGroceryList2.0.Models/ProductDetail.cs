using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class ProductDetail
    {
        
        public int Id { get; set; }

        public string ItemName { get; set; }

        public int ItemCount { get; set; }     

        public string DepartmentType { get; set; }

        public string ItemType { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        // Terry, I could have more than one StoreId here, right? How do I address this?
        // Also, why doesn't the GUID belong hee in Detail?
        public int StoreId { get; set; }

        [DefaultValue(false)]
        public bool PurchasedAtMultipleStores { get; set; }

    }
}
