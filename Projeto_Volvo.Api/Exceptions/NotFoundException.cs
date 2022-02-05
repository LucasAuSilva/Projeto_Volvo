
namespace Projeto_Volvo.Api.Exceptions
{
    public class NotFoundException : Exception
    {
        public int StatusCode { get; }
        public NotFoundException() : base()
        { }
        public NotFoundException(string message) : base(message)
        {
            this.StatusCode = 404;
        }
    }
}