using System.Runtime.Serialization;

namespace HTML5_CSS_Course_Backend_Endpoint
{
    public class ExpiredTokenException : AuthenticationException
    {
        public ExpiredTokenException()
        {
        }

        public ExpiredTokenException(string? message) : base(message)
        {
        }

        public ExpiredTokenException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExpiredTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        
        
    }
}