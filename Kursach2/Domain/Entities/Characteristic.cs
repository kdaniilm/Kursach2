using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Characteristic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string CharacteristicName { get; set; }
        public string CharacteristicValue { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
