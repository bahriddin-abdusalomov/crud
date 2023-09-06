using CrudForDapper.Models;

namespace CrudForDapper.Interfaces
{
    public interface ICoursesGradesRepository : IBaseRepository<Courses_Grades>
    {
        public Task<Courses_Grades> MaxGradeStudent();
    }
}
