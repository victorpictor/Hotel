namespace Inventory.Services.Repositories
{
    public interface ISessionRepository<T>
    {
        void Store(T t);
        T Get(string key);
    }
}