using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public class AuthorizationActionRepository : BaseRepository<AuthorizationAction>, IAuthorizationActionRepository
	{
		public AuthorizationActionRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}
		public void DeleteAuthorizationAction(int id) => Delete("spDeleteAuthorizationAction", id);

		public IEnumerable<AuthorizationAction> GetAllAuthorizationActions() => GetAll("exec spGetAuthorizationActions");

		public void AddAuthorizationAction(AuthorizationAction authorizationAction) => Add("spAddAuthorizationAction", authorizationAction);

		public AuthorizationAction? GetAuthorizationActionById(int id) => GetById("spGetAuthorizationActionById", id);

		public void UpdateAuthorizationAction(AuthorizationAction authorizationAction) => Update("spUpdateAuthorizationAction", authorizationAction);
	}
}
