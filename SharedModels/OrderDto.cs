using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class OrderDto
    {
        [StringLength(250,ErrorMessage = "ProductName max length should be 250 chars!")]
        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = "Quantity should be greater than or eqals to 1.")]
        [Required]
        public int Quantity { get; set; }
    }
}
