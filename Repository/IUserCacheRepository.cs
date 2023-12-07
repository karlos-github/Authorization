using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IUserCacheRepository
	{
		IEnumerable<UserCache> GetCache(bool forceUpdate);
		//IEnumerable<UserCache> GetCacheByUserId(int id);
	}
}
