using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalBodeKasse.Core.ApplicationService;
using GlobalBodeKasse.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBodeKasseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAllUsers();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _userService.FindUserById(id);
        }
        
        // POST api/User
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                return _userService.CreateUser(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if (id < 0 || id != user.Id)
            {
                return BadRequest("parameter id and user id must be a match");
            }

            return _userService.UpdateUser(user);
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {// delete virker ikke efter hensigten

            var user = _userService.DeleteUserById(id);
            if (user == null)
            {
                return StatusCode(404, "Did not found User with id: " + id);
            }
            return Ok($"User with Id: {id} is Deleted");
        }
    }
}