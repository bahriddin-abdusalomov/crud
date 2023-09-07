using CrudForDapper.Interfaces;
using CrudForDapper.Models;
using Dapper;

namespace CrudForDapper.Repositories
{
    public class CourseGradesRepository : BaseRepository, ICoursesGradesRepository
    {
        public async Task<bool> CreateAsync(Courses_Grades entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO \"Courses_Grades\"(course_id, student_id, grade) " +
                    "VALUES (@CourseId, @StudentId, @Grade);";
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


        public async Task<bool> DeleteAsync(long courseId, long studentId)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Delete From \"Courses_Grades\" Where course_id = @CourseId and student_id = @StudentId";
                var result = await _connection.ExecuteAsync(query, 
                    new { CourseId = courseId , StudentId = studentId});
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

        public async Task<IList<Courses_Grades>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Select * from \"Courses_Grades\";";
                var result = (await _connection.QueryAsync<Courses_Grades>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Courses_Grades>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<Courses_Grades> GetByIdAsync(long courseId, long studentId)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Select * from \"Courses_Grades\" Where course_id = @CourseId;";
                var result = await _connection.QuerySingleAsync<Courses_Grades>(query,
                    new { CourseId = courseId , StudentId = studentId});
                return result;
            }
            catch
            {
                return new Courses_Grades();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<bool> UpdateAsync(Courses_Grades entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE \"Courses_Grades\" SET  course_id=@CourseId, student_id=@StudentId" +
                    $" WHERE course_id = {entity.CourseId} and student_id = {entity.StudentId};";
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

        public async Task<Courses_Grades> MaxGradeStudent()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Select * from \"Courses_Grades\"  Order By greade Limit 1;";
                var result = await _connection.QuerySingleAsync<Courses_Grades>(query);

                return result;
            }
            catch
            {
                return new Courses_Grades() ;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}
