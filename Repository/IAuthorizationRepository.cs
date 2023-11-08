using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IAuthorizationRepository
	{
		IEnumerable<Authorization> GetAllAuthorizations();
		void InsertNewAuthorization(Authorization authorization);
		void UpdateAuthorization(Authorization authorization);
		void DeleteAuthorization(int id);
	}
}
