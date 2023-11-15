using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public class UserAuthorizationActionRepository : BaseRepository<UserAuthorizationAction>, IUserAuthorizationActionRepository
	{
		public UserAuthorizationActionRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}
		public void DeleteUserAuthorizationAction(int id) => Delete("spDeleteUserAuthorizationAction", id);

		public IEnumerable<UserAuthorizationAction> GetAllUserAuthorizationActions() => GetAll("exec spGetUserAuthorizationActions");

		public void AddUserAuthorizationAction(UserAuthorizationAction userAuthorizationAction) => Add("spAddNewUserAuthorizationAction", userAuthorizationAction);

		public UserAuthorizationAction? GetUserAuthorizationActionById(int id) => GetById("spGetUserAuthorizationActionById", id);

		public void UpdateUserAuthorizationAction(UserAuthorizationAction userAuthorizationAction) => Update("spUpdateUserAuthorizationAction", userAuthorizationAction);
	}
}
