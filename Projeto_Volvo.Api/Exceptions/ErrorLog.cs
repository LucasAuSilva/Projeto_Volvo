
namespace Projeto_Volvo.Api.Exceptions
{
    public class ErrorLog
    {
        public string ErrorName { get; set; }
        public string ErrorStackTrace { get; set; }
        public DateTime Timestamp { get; set; }
        public string ErrorMessage { get; set; }
        public string Environment { get; set; }

        public ErrorLog(string ErrorName, string ErrorStackTrace, string ErrorMessage, string Environment) {
            this.ErrorName = ErrorName;
            this.ErrorStackTrace = ErrorStackTrace;
            this.ErrorMessage = ErrorMessage;
            this.Environment = Environment;
            this.Timestamp = new DateTime().ToUniversalTime();
        }
    }
}