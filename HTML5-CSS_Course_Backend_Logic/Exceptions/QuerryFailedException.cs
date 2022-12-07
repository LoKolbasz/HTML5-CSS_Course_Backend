using System.Runtime.Serialization;

namespace HTML5_CSS_Course_Backend_Logic
{
    public class QuerryFailedException : Exception
    {
        public QuerryFailedException()
        {
        }

        public QuerryFailedException(string? message) : base(message)
        {
        }

        public QuerryFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected QuerryFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public QuerryFailedException(Exception? innerException) : base("A problem occured while executing the querry", innerException)
        {

        }
    }
}