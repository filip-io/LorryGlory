namespace LorryGlory_Frontend_MVC.Models
{
    internal class ResponseModel<T>
    {
        public bool Success { get; set; }

        public T? Data { get; set; }

        public string? Message { get; set; }

        public IEnumerable<string>? Errors { get; set; }
    }
}
