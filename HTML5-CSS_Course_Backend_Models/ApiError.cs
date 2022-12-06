namespace HTML5_CSS_Course_Backend_Models
{
    public class ApiError
    {
        public string path { get; set; }
        public string message { get; set; }
        public Exception[] errors { get; set; }

        public ApiError(string path, string message, Exception[] errors)
        {
            this.path = path;
            this.message = message;
            this.errors = errors;
        }
    }
}