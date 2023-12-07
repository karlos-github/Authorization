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

		[HttpGet("get/{id}")]
		public IActionResult GetById(int id) => Ok(_roleAuthorizationActionService.GetRoleAuthorizationActionById(id));

		[HttpPost("new")]
		public void Create([FromBody] RoleAuthorizationAction roleAuthorizationAction) => _roleAuthorizationActionService.AddRoleAuthorizationAction(roleAuthorizationAction);

		[HttpPut("update")]
		public void Update([FromBody] RoleAuthorizationAction roleAuthorizationAction) => _roleAuthorizationActionService.UpdateRoleAuthorizationAction(roleAuthorizationAction);

		[HttpDelete("delete/{id}")]
		public void Delete(int id) => _roleAuthorizationActionService.DeleteRoleAuthorizationAction(id);
	}
}
