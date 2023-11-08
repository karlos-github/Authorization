using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class AuthorizationService : IAuthorizationService
	{
		IAuthorizationRepository _authorizationRepository;
		public AuthorizationService(IAuthorizationRepository authorizationRepository) => _authorizationRepository = authorizationRepository;

		public void DeleteAuthorization(int id) => _authorizationRepository.DeleteAuthorization(id);

		public IEnumerable<Authorization> GetAllAuthorizations() => _authorizationRepository.GetAllAuthorizations();

		public void InsertAuthorization(Authorization authorization) => _authorizationRepository.InsertNewAuthorization(authorization);

		public void UpdateAuthorization(Authorization authorization) => _authorizationRepository.UpdateAuthorization(authorization);
	}
}
