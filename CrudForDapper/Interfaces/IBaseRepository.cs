namespace CrudForDapper.Interfaces
{
    public interface IBaseRepository<TModel>
    {
        public Task<bool> CreateAsync(TModel entity);
        public Task<bool> UpdateAsync(TModel entity);
        public Task<bool> DeleteAsync(long Id);
        public Task<TModel> GetByIdAsync(long id);
        public Task<IList<TModel>> GetAllAsync();
    }
}
