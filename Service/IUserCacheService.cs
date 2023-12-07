using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IUserCacheService
	{
		IEnumerable<UserCache> GetCache(bool forceUpdate);
	}
}
