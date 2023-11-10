using AuthorizationStudio9.Model;
using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserAuthorizationActionController : ControllerBase
	{
		readonly IUserAuthorizationActionService _userAuthorizationActionService;

		public UserAuthorizationActionController(IUserAuthorizationActionService userAuthorizationActionService) => _userAuthorizationActionService = userAuthorizationActionService;

		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_userAuthorizationActionService.GetAllUserAuthorizationActions());

		[HttpPost("new")]
		public void Create([FromBody] UserAuthorizationAction userAuthorizationAction)
		{
			_userAuthorizationActionService.InsertUserAuthorizationAction(userAuthorizationAction);
			//Ok();
		}

		[HttpPut("update")]
		public void Update([FromBody] UserAuthorizationAction userAuthorizationAction)
		{
			_userAuthorizationActionService.UpdateUserAuthorizationAction(userAuthorizationAction);
			//Ok();
		}

		[HttpDelete("delete/{id}")]
		public void Delete(int id)
		{
			_userAuthorizationActionService.DeleteUserAuthorizationAction(id);
			//Ok();
		}
	}
}
