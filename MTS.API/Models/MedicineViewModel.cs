using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.API.Models
{
    public class MedicineViewModel
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}
