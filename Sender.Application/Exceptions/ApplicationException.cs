namespace Sender.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public const string DefaultErrorCode = "ApplicationError";

        public string Code { get; private set; }
        public string Details { get; private set; }

        public ApplicationException(string message, string code = null, string details = null) : base(message)
        {
            Code = code ?? DefaultErrorCode;
            Details = details;
        }
    }
}
