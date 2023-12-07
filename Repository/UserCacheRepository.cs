using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;

namespace AuthorizationStudio9.Repository
{
	public class UserCacheRepository : BaseRepository<UserCache>, IUserCacheRepository
	{
		SqlConnection _con;

		public UserCacheRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}

		public IEnumerable<UserCache> GetCache(bool forceUpdate) => GetAll($"{(forceUpdate ? "exec spRefreshUserCache" : "exec spGetUserCache")}");
	}
}
