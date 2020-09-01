using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MST.UI.Models
{
    public class MedicineViewModel
    {
        
        public string Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public string Notes { get; set; }
    }

}
