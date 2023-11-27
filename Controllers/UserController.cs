using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Services;
using System;
using MusicLibrary.Services;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("User/Index")]
        public ActionResult Index()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("User/Get-User-By-Email")]
        public ActionResult GetUserByEmail(string email)
        {
            try
            {
                var user = _userService.GetUserByEmail(email);
                return Ok(user);
            }catch(InvalidOperationException ex)
            {
                return BadRequest("User not found" + ex);
            }
        }

        [HttpPost("User/Add")]
        public ActionResult AddUser(string email, string name, string password)
        {
            try
            {
                _userService.AddUser(email, name, password);
                var users = _userService.GetAll();
                return Ok(users);
            }catch(Exception ex) {
                return BadRequest("Error on adding user controller" + ex  );
            }

        }

        [HttpDelete("User/Delete")] 
        public ActionResult DeleteUser(string email)
        {
            try
            {
                _userService.DeleteUser(email);
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest("Error on deleting user controller" + ex);
            }
        }

        [HttpPut("User/Update")]
        public ActionResult EditUser(string email, string newName, string newPassword)
        {
            try
            {
                _userService.UpdateUserName(email, newName);
                _userService.UpdateUserPassword(email, newPassword);
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest("Error on editing user controller" + ex);
            }
        } 
    }
}
