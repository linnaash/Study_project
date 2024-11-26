using Cultura.Contracts.Employee;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cultura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }
        /// <summary>
        /// Возвращает список всех пользователей.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
        /// <summary>
        /// Возвращает данные пользователя по его уникальному идентификатору (ID).
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result=await _userService.GetById(id);
            var response = result.Adapt<GetUserResponse>();
 
            return Ok(response);
        }
        /// <summary>
        ///Создает нового пользователя на основе предоставленных данных.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///         "FirstName" : "Natalia",
        ///         "LastName" : "Smirnova",
        ///         "DepartmentId" : "1"
        ///     }
        /// 
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateOrUpdateUserRequest request)
        {
            var userDto = request.Adapt<Employee>();
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Обновляет данные существующего пользователя.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(CreateOrUpdateUserRequest request)
        {
            var userDto = request.Adapt<Employee>();
            await _userService.Update(userDto);
            return Ok();
        }
        /// <summary>
        /// Удаляет пользователя по его ID.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
