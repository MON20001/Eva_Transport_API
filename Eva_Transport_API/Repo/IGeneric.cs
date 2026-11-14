namespace Eva_Transport_API.Repo
{
    public interface IGeneric<T> where T : class
    {
        Task<IEnumerable<T?>> GetAll();
        Task<T?> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task<bool> Delete(int id);
    }
}
