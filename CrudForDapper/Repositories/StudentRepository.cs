using CrudForDapper.Interfaces;
using CrudForDapper.Models;
using CrudForDapper.Repositories;
using Dapper;
using static Dapper.SqlMapper;

namespace CrudForDapper.Repository
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public async Task<bool> CreateAsync(Students entity)
        {
            try
            {
              await  _connection.OpenAsync();
               
                string query = "INSERT INTO public.Students(id, first_name, last_name) " +
                    "VALUES (@Id, @FirstName, @LastName);";
                var result = await _connection.ExecuteAsync(query, entity);
                return result > 0;
            }
            catch 
            { 
                return false;
            }
            finally 
            {
               await _connection.CloseAsync();
            }
        }

  
        public async Task<bool> DeleteAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Delete From Students Where id = @id";
                var result = await _connection.ExecuteAsync(query, new { id = Id });
                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<IList<Students>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Select * from Students;";
                var result = (await _connection.QueryAsync<Students>(query)).ToList();
                return result ;
            }
            catch
            {
                return new List<Students>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<Students> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Students entity)
        {
            throw new NotImplementedException();
        }
    }
}
