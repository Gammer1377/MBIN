using System.Collections;
using MBIN.Data.Contracts;
using MBIN.Entity.DTOs;
using MBIN.Entity.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MBIN.Entity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Win32;

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

        [HttpDelete(nameof(id))]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_repository.DeleteAsync(id).Result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch(nameof(id))]
        [Route("UpdateUser/{id}")]
        public IActionResult UpdateUser(EditUserDTO user, int id)
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
        [HttpPost(nameof(register))]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(CreateUserDTO register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_repository.EmailExist(register.Email.Trim()).Result)
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده از قبل موجود است");
                return BadRequest(ModelState);
            }

            User regUser = new User()
            {
                CreateDate = DateTime.Now,
                Email = register.Email.Trim(),
                Password = register.Password,
                Gender = register.Gender,
                UserName = register.UserName,
                Mobile = register.Mobile,
                //JWTSecret = "Test",
                LastUpdateDate = DateTime.Now
            };
            if (_repository.InsertAsync(regUser).Result)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", "خطای سیستمی رخ داده لطفا مجددا سعی کنید");
                return StatusCode(500, ModelState);
            }

        }
        [HttpPost(nameof(login))]
        [Route("LoginUser")]
        public IActionResult LoginUser(LoginUserDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_repository.ExistByAsync(u => u.Email == login.Email && u.Password == login.Password).Result)
            {
                ModelState.AddModelError("", "کاربری یافت نشد");
                return NotFound(ModelState);
            }

            var user = _repository.Login(login.Email, login.Password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
