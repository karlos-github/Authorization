using AuthorizationStudio9.Service;
using Microsoft.AspNetCore.Mvc;
namespace AuthorizationStudio9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserCacheController : ControllerBase
	{
		readonly IUserCacheService _userCacheService;

		public UserCacheController(IUserCacheService userCacheService) => _userCacheService = userCacheService;

		[HttpGet("get/{forceUpdate}")]
		public IActionResult GetCache(bool forceUpdate) => Ok(_userCacheService.GetCache(forceUpdate));
	}
}
