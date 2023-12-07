using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
    public interface IUserAuthorizationActionService
    {
		IEnumerable<UserAuthorizationAction> GetAllUserAuthorizationActions();
		UserAuthorizationAction? GetUserAuthorizationActionById(int id);
		void InsertUserAuthorizationAction(UserAuthorizationAction user);
		void UpdateUserAuthorizationAction(UserAuthorizationAction user);
		void DeleteUserAuthorizationAction(int id);
	}
}
