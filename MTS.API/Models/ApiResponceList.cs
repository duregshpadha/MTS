using System.Collections.Generic;

namespace MTS.API.Models
{
    public class ApiResponceList<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}
