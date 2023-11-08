using AuthorizationStudio9.Model;
using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;
namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		readonly IAuthorizationService _authorizationService;

		public UserController(IAuthorizationService authorizationService) => _authorizationService = authorizationService;
		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_authorizationService.GetAllUsers());

		[HttpPost("new")]
		public void Create([FromBody] User user)
		{
			_authorizationService.InsertUser(user);
			Ok();
		}

		[HttpPut("update")]
		public void Update([FromBody] User user)
		{
			_authorizationService.UpdateUser(user);
			Ok();
		}

		[HttpDelete("delete/{id}")]
		public void Delete(int id)
		{
			_authorizationService.DeleteUser(id);
			Ok();
		}
	}
}
