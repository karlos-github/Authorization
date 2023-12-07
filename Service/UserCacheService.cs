using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class UserCacheService : IUserCacheService
	{
		IUserCacheRepository _userCacheRepository;
        public UserCacheService(IUserCacheRepository userCacheService) => _userCacheRepository = userCacheService;

		public IEnumerable<UserCache> GetCache(bool forceUpdate) => _userCacheRepository.GetCache(forceUpdate);
	}
}
