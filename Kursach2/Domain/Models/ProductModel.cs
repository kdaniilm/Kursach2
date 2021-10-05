using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public float ProductPrice { get; set; }
    }
}
