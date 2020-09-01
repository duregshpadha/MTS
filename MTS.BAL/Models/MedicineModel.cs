using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.BAL.Models
{
    public class MedicineModel
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
