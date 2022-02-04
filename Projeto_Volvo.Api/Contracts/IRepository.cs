
namespace Projeto_Volvo.Api.Contracts
{
    public interface IRepository<T>
    {
        ICollection<T> GetAllEntity();
        T GetOneEntity(int id);
        T AddEntity(T entity);
        T UpdateEntity(int id, T entity);
        void DeleteEntity(int id);
    }
}