using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IAuthorizationActionRepository
	{
		IEnumerable<AuthorizationAction> GetAllAuthorizationActions();
		AuthorizationAction GetAuthorizationActionById(int id);
		void AddAuthorizationAction(AuthorizationAction authorizationAction);
		void UpdateAuthorizationAction(AuthorizationAction authorizationAction);
		void DeleteAuthorizationAction(int id);
	}
}
