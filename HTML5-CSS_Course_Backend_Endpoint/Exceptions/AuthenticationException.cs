using System.Runtime.Serialization;

namespace HTML5_CSS_Course_Backend_Endpoint
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string? message) : base(message)
        {
        }

        public AuthenticationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
