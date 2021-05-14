using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Data
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "There are not enough characters in this field.")]
        [MaxLength(15, ErrorMessage = "There are too many characters in this field.")]
        public string UserName { get; set; }

        [Required]
        public bool HasPurchaseHistory { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
