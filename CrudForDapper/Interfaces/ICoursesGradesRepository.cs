using CrudForDapper.Models;

namespace CrudForDapper.Interfaces
{
    public interface ICoursesGradesRepository 
    {
        public Task<bool> CreateAsync(Courses_Grades entity);
        public Task<bool> UpdateAsync(Courses_Grades entity);
        public Task<bool> DeleteAsync(long courseId, long studentId);
        public Task<Courses_Grades> GetByIdAsync(long courseId, long studentId);
        public Task<IList<Courses_Grades>> GetAllAsync();
        public Task<Courses_Grades> MaxGradeStudent();
    }
}
