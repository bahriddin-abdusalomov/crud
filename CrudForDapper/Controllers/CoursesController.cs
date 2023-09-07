using CrudForDapper.Interfaces;
using CrudForDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudForDapper.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _service;

        public CoursesController(ICoursesRepository coursesRepository)
        {
            this._service = coursesRepository;           
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Courses course)
            => Ok(await _service.CreateAsync(course));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _service.DeleteAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetByIdAsync(long courseId)
            => Ok(await _service.GetByIdAsync(courseId));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] Courses course)
            => Ok(await _service.UpdateAsync(course));
    }
}
