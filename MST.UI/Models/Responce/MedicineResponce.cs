using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MST.UI.Models.Responce
{
    public class MedicineResponce
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MedicineViewModel data { get; set; }
    }
}
