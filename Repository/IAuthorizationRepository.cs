using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IAuthorizationRepository
	{
		IEnumerable<Authorization> GetAllAuthorizations();
		Authorization? GetAuthorizationById(int id);
		void AddAuthorization(Authorization authorization);
		void UpdateAuthorization(Authorization authorization);
		void DeleteAuthorization(int id);
	}
}
