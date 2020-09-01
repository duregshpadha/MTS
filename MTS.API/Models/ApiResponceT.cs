namespace MTS.API.Models
{
    public class ApiResponceT<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
