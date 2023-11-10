using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IUserAuthorizationActionRepository
	{
		IEnumerable<UserAuthorizationAction> GetAllUserAuthorizationActions();
		void InsertNewUserAuthorizationAction(UserAuthorizationAction role);
		void UpdateUserAuthorizationAction(UserAuthorizationAction role);
		void DeleteUserAuthorizationAction(int id);
	}
}
