using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;
using Action = AuthorizationStudio9.Model.Action;

namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActionController : ControllerBase
	{
		readonly IActionService _actionService;

		public ActionController(IActionService actionService) => _actionService = actionService;

		[HttpGet("get")]
		public IActionResult GetAll() => Ok(_actionService.GetAllActions());

		[HttpPost("new")]
		public void Create([FromBody] Action role) => _actionService.InsertNewAction(role);

		[HttpPut("update")]
		public void Update([FromBody] Action role) => _actionService.UpdateAction(role);

		[HttpDelete("delete/{id}")]
		public void Delete(int id) => _actionService.DeleteAction(id);
	}
}
