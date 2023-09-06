using CrudForEntity.Dtos;
using EntityCRUD.Interfaces.Users;
using EntityCRUD.Models.Staffs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudForEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _service;

        public UserController(IUserRepository userService)
        {
            this._service = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Createasync([FromForm] User user)
            => Ok( await _service.CreateAsync(user));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] User user)
            => Ok(await _service.UpdateAsync(user));

        [HttpDelete]
        public async Task<IActionResult> Deleteasync([FromForm] int id)
            => Ok(await _service.DeleteAsync(id));

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync([FromForm] int id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());
    }
}
