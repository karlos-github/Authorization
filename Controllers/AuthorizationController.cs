using AuthorizationStudio9.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		readonly Service.IAuthorizationService _authorizationService;

		public AuthorizationController(Service.IAuthorizationService authorizationService) => _authorizationService = authorizationService;
		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_authorizationService.GetAllAuthorizations());

		[HttpGet("get/{id}")]
		public IActionResult GetById(int id) => Ok(_authorizationService.GetAuthorizationById(id));

		[HttpPost("new")]
		public void Create([FromBody] Authorization authorization) => _authorizationService.InsertAuthorization(authorization);

		[HttpPut("update")]
		public void Update([FromBody] Authorization authorization) => _authorizationService.UpdateAuthorization(authorization);

		[HttpDelete("delete/{id}")]
		public void Delete(int id) => _authorizationService.DeleteAuthorization(id);
	}
}
