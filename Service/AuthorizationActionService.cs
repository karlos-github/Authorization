using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class AuthorizationActionService : IAuthorizationActionService
	{
		IAuthorizationActionRepository _authorizationActionRepository;
		public AuthorizationActionService(IAuthorizationActionRepository authorizationActionRepository) => _authorizationActionRepository = authorizationActionRepository;
		public IEnumerable<AuthorizationAction> GetAllAuthorizationActions() => _authorizationActionRepository.GetAllAuthorizationActions();
		public void InsertAuthorizationAction(AuthorizationAction authorizationAction) => _authorizationActionRepository.InsertNewAuthorizationAction(authorizationAction);
		public void UpdateAuthorizationAction(AuthorizationAction authorizationAction) => _authorizationActionRepository.UpdateAuthorizationAction(authorizationAction);
		public void DeleteAuthorizationAction(int id) => _authorizationActionRepository.DeleteAuthorizationAction(id);
	}
}
