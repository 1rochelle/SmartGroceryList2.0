using SmartGroceryList2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Models
{
    public class StoreEdit
    {
        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public int StoreAddressNumber { get; set; }

        public string StoreStreetName { get; set; }

        public string StoreTownOrCity { get; set; }

        public StoreState StoreState { get; set; }

        public int StoreZIP { get; set; }
    }
}
