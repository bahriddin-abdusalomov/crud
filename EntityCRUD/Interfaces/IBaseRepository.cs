namespace EntityCRUD.Interfaces;
public interface IBaseRepository<T>
{
    public Task<bool> CreateAsync (T entity);
    public Task<bool> UpdateAsync (T entity);
    public Task<bool> DeleteAsync (int Id);
    public Task<T> GetByIdAsync (int id);
    public Task<IList<T>> GetAllAsync ();
}
