
namespace Projeto_Volvo.Api.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public int StatusCode { get; }
        public EntityNotFoundException() : base()
        { }
        public EntityNotFoundException(string message) : base(message)
        {
            this.StatusCode = 404;
        }
    }
}