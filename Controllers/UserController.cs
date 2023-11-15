using AuthorizationStudio9.Model;
using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;
namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		readonly IUserService _userService;

		public UserController(IUserService userService) => _userService = userService;

		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_userService.GetAllUsers());

		[HttpGet("get/{id}")]
		public IActionResult GetById(int id) => Ok(_userService.GetUserById(id));

		[HttpPost("new")]
		public void Create([FromBody] User user) => _userService.InsertUser(user);

		[HttpPut("update")]
		public void Update([FromBody] User user) => _userService.UpdateUser(user);

		[HttpDelete("delete/{id}")]
		public void Delete(int id) => _userService.DeleteUser(id);
	}
}
