using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Data
{
    public enum StoreState { AL, AK, AS, AZ, AR, CA, CO, CT, DE, DC, FL, GA, GU, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, MP, OH, OK, OR, PA, PR, RI, SC, SD, TN, TX, UT, VT, VA, VI, WA, WV, WI, WY }
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "There are not enough characters in this field.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string StoreName { get; set; }

        [Required]
        public int StoreAddressNumber { get; set; }

        [Required]
        public string StoreStreetName { get; set; }

        [Required]
        public string StoreTownOrCity { get; set; }

        [Required]
        public StoreState StoreState { get; set; }

        [Required]
        public int StoreZIP { get; set; }

        public List<Store> StoreNames { get; set; } = new List<Store>();
    }
}
