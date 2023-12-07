using AuthorizationStudio9.Model;
using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorizationActionController : ControllerBase
	{

		readonly IAuthorizationActionService _authorizationActionService;

		public AuthorizationActionController(IAuthorizationActionService authorizationActionService) => _authorizationActionService = authorizationActionService;

		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_authorizationActionService.GetAllAuthorizationActions());

		[HttpGet("get/{id}")]
		public IActionResult GetById(int id) => Ok(_authorizationActionService.GetAuthorizationActionById(id));

		[HttpPost("new")]
		public void Create([FromBody] AuthorizationAction authorizationAction) => _authorizationActionService.AddAuthorizationAction(authorizationAction);

		[HttpPut("update")]
		public void Update([FromBody] AuthorizationAction authorizationAction) => _authorizationActionService.UpdateAuthorizationAction(authorizationAction);

		[HttpDelete("delete/{id}")]
		public void Delete(int id) => _authorizationActionService.DeleteAuthorizationAction(id);
	}
}
