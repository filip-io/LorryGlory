namespace LorryGlory.Api.Models
{
    /// <summary>
    /// Represents a standardized API response wrapper
    /// </summary>
    /// <typeparam name="T">The type of data being returned</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indicates if the operation was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The data returned by the API
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// A message describing the result of the operation
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Collection of error messages if the operation wasn't successful
        /// </summary>
        public IEnumerable<string>? Errors { get; set; }
    }
}
