using CrudForDapper.Interfaces;
using CrudForDapper.Models;
using Dapper;

namespace CrudForDapper.Repositories
{
    public class CoursesRepository : BaseRepository, ICoursesRepository
    {
        public async Task<bool> CreateAsync(Courses entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO \"Courses\"(id, course_name, student_id) " +
                    "VALUES (@Id, @CourseName, @StudentId);";
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

                string query = "Delete From \"Courses\" Where id = @id";
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

        public async Task<IList<Courses>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Select * from \"Courses\";";
                var result = (await _connection.QueryAsync<Courses>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Courses>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<Courses> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Select * from \"Courses\" Where id = @Id;";
                var result = await _connection.QuerySingleAsync<Courses>(query, new { Id = id });
                return result;
            }
            catch
            {
                return new Courses();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<bool> UpdateAsync(Courses entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE \"Courses\" SET  course_name=@CourseName, student_id=@StudentId" +
                    $" WHERE id = {entity.Id};";
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
    }
}
