using CrudForDapper.Interfaces;
using CrudForDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudForDapper.Controllers
{
    [Route("api/courseGrades")]
    [ApiController]
    public class CourseGradesController : ControllerBase
    {
        private readonly ICoursesGradesRepository _service;

        public CourseGradesController(ICoursesGradesRepository coursesGradesRepository)
        {
            this._service = coursesGradesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]  Courses_Grades model) 
            => Ok(await _service.CreateAsync(model));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long courseId, long studentId)
            => Ok(await _service.DeleteAsync(courseId, studentId));
    }
}
