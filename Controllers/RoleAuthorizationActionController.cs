using AuthorizationStudio9.Model;
using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;
namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleAuthorizationActionController : ControllerBase
	{
		readonly IRoleAuthorizationActionService _roleAuthorizationActionService;

		public RoleAuthorizationActionController(IRoleAuthorizationActionService roleAuthorizationActionService) => _roleAuthorizationActionService = roleAuthorizationActionService;
		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_roleAuthorizationActionService.GetAllRoleAuthorizationActions());

		[HttpPost("new")]
		public void Create([FromBody] RoleAuthorizationAction roleAuthorizationAction)
		{
			_roleAuthorizationActionService.InsertNewRoleAuthorizationAction(roleAuthorizationAction);
			Ok();
		}

		[HttpPut("update")]
		public void Update([FromBody] RoleAuthorizationAction roleAuthorizationAction)
		{
			_roleAuthorizationActionService.UpdateRoleAuthorizationAction(roleAuthorizationAction);
			Ok();
		}

		[HttpDelete("delete/{id}")]
		public void Delete(int id)
		{
			_roleAuthorizationActionService.DeleteRole(id);
			Ok();
		}
	}
}
