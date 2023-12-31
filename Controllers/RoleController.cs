﻿using AuthorizationStudio9.Model;
using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;
namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		readonly IRoleService _roleService;

		public RoleController(IRoleService roleService) => _roleService = roleService;

		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_roleService.GetAllRoles());

		[HttpGet("get/{id}")]
		public IActionResult GetById(int id) => Ok(_roleService.GetARoleById(id));

		[HttpPost("new")]
		public void Create([FromBody] Role role) => _roleService.AddRole(role);

		[HttpPut("update")]
		public void Update([FromBody] Role role) => _roleService.UpdateRole(role);

		[HttpDelete("delete/{id}")]
		public void Delete(int id) => _roleService.DeleteRole(id);
	}
}
