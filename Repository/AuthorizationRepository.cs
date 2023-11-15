namespace AuthorizationStudio9.Repository
{
	public class AuthorizationRepository : BaseRepository<Model.Authorization>, IAuthorizationRepository
	{
		public AuthorizationRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}
		public void DeleteAuthorization(int id) => Delete("spDeleteAthorization", id);

		public IEnumerable<Model.Authorization> GetAllAuthorizations() => GetAll("exec spGetAuthorizations");

		public void AddAuthorization(Model.Authorization authorization) => Add("spAddNewAuthorization", authorization);

		public Model.Authorization? GetAuthorizationById(int id) => GetById("spGetAuthorizationById", id);

		public void UpdateAuthorization(Model.Authorization authorization) => Update("spUpdateAuthorization", authorization);
	}
}
