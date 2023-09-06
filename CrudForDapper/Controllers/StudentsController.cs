using CrudForDapper.Interfaces;
using CrudForDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudForDapper.Controllers
{
    [Route("api/[students]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _service;

        public StudentsController(IStudentRepository studentRepository) 
        { 
            this._service = studentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Students students)
            => Ok(await _service.CreateAsync(students));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromForm] long id)
            => Ok(await _service.DeleteAsync(id));
    }
}
