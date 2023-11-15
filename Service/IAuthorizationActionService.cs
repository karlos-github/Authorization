using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IAuthorizationActionService
	{
		IEnumerable<AuthorizationAction> GetAllAuthorizationActions();
		AuthorizationAction GetAuthorizationActionById(int id);
		void AddAuthorizationAction(AuthorizationAction authorizationAction);
		void UpdateAuthorizationAction(AuthorizationAction authorizationAction);
		void DeleteAuthorizationAction(int id);
	}
}
