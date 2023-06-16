namespace Application.Exceptions
{
    public class Conflict : Exception
    {
        public Conflict()
        {
        }

        public Conflict(string message) : base(message)
        {
        }

        public Conflict(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
