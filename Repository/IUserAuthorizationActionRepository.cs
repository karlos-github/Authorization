using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IUserAuthorizationActionRepository
	{
		IEnumerable<UserAuthorizationAction> GetAllUserAuthorizationActions();
		UserAuthorizationAction? GetUserAuthorizationActionById(int id);
		void AddUserAuthorizationAction(UserAuthorizationAction role);
		void UpdateUserAuthorizationAction(UserAuthorizationAction role);
		void DeleteUserAuthorizationAction(int id);
	}
}
