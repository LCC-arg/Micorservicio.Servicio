namespace Application.Exceptions
{
    public class ExceptionNotFound : Exception
    {
        public ExceptionNotFound()
        {
        }

        public ExceptionNotFound(string message) : base(message)
        {
        }

        public ExceptionNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
