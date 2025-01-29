using System.Collections;
using MBIN.Data.Contracts;
using MBIN.Entity.DTOs;
using MBIN.Entity.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MBIN.Entity.User;

namespace MBIN.API.Controllers
{
    [ApiController]
    [Route("MBIN/API/User/")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository) => _repository = repository;

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetAllAsync().Result);
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult InsertUser([FromBody] UserDTO userDto)
        {
            User user = new()
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                Gender = userDto.Gender,
                Password = userDto.Password,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
            var Query = _repository.InsertAsync(user).Result;

            if (Query)
            {
                return Created();
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete(nameof(id))]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var Result = _repository.DeleteAsync(id);

            return Ok();

        }

        [HttpPatch(nameof(id))]
        [Route("UpdateUser/{id}")]
        public IActionResult UpdateUser(UserDTO user, int id)
        {
            var Query = _repository.GetByIdAsync(id);

            if (Query.Result == null)
            {
                return NotFound();
            }
            else
            {
                Query.Result.UserName = user.UserName;
                Query.Result.Email = user.Email;
                Query.Result.Password = user.Password;
                Query.Result.Gender = user.Gender;
                Query.Result.LastUpdateDate = DateTime.Now;
                _repository.UpdateAsync(Query.Result);
                return Ok();
            }
        }
    }
}
