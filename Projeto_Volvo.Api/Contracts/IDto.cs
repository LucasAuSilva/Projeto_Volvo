namespace Projeto_Volvo.Api.Contracts
{
    public interface IDto<T> where T : class
    {
        T CreateEntity();
    }
}