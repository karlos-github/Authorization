using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IAuthorizationActionRepository
	{
		IEnumerable<AuthorizationAction> GetAllAuthorizationActions();
		void InsertNewAuthorizationAction(AuthorizationAction authorizationAction);
		void UpdateAuthorizationAction(AuthorizationAction authorizationAction);
		void DeleteAuthorizationAction(int id);
	}
}
