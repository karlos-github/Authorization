using AuthorizationStudio9.Model;
using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationStudio9.Controllers
{
	public class UserRoleController : ControllerBase
	{
		readonly IUserRoleService _userRoleService;

		public UserRoleController(IUserRoleService userRoleService) => _userRoleService = userRoleService;

		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_userRoleService.GetAllUserRoles());

		[HttpGet("get/{id}")]
		public IActionResult GetById(int id) => Ok(_userRoleService.GetUserRoleById(id));

		[HttpPost("new")]
		public void Create([FromBody] UserRole userRole) => _userRoleService.InsertNewUserRole(userRole);

		[HttpPut("update")]
		public void Update([FromBody] UserRole userRole) => _userRoleService.UpdateUserRole(userRole);

		[HttpDelete("delete/{id}")]
		public void Delete(int id) => _userRoleService.DeleteUserRole(id);
	}
}
