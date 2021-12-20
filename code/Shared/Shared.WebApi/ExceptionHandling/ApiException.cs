using System.Net;

namespace Shared.WebApi.ExceptionHandling
{
    public class ApiException : Exception
    {
        public const string InternalError = "internal_error";
        public const string ValidationError = "validation_error";
        public const string DataAccessError = "data_access_error";

        public ApiException()
        {
        }

        public ApiException(string message, HttpStatusCode statusCode, string code, object payload = null, Exception innerException = null) : base(message, innerException)
        {
            Status = statusCode;
            Code = code;
            Payload = payload;
        }

        public HttpStatusCode Status { get; private set; }
        public string Code { get; set; }
        public object Payload { get; set; }
    }
}
