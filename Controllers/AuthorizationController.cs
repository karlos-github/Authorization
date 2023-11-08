using AuthorizationStudio9.Model;
using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		readonly IAuthorizationService _authorizationService;

		public AuthorizationController(IAuthorizationService authorizationService) => _authorizationService = authorizationService;
		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_authorizationService.GetAllAuthorizations());

		[HttpPost("new")]
		public void Create([FromBody] Authorization authorization)
		{
			_authorizationService.InsertAuthorization(authorization);
			Ok();
		}

		[HttpPut("update")]
		public void Update([FromBody] Authorization authorization)
		{
			_authorizationService.UpdateAuthorization(authorization);
			Ok();
		}

		[HttpDelete("delete/{id}")]
		public void Delete(int id)
		{
			_authorizationService.DeleteAuthorization(id);
			Ok();
		}
	}
}
