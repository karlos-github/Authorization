using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public class RoleAuthorizationActionRepository : BaseRepository<RoleAuthorizationAction>, IRoleAuthorizationActionRepository
	{
		public RoleAuthorizationActionRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}

		public void DeleteRoleAuthorizationAction(int id) => Delete("spDeleteAction", id);

		public IEnumerable<RoleAuthorizationAction> GetAllRoleAuthorizationActions() => GetAll("exec spGetRoleAuthorizationActions");

		public void AddRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction) => Add("spAddNewRoleAuthorizationAction", roleAuthorizationAction);

		public RoleAuthorizationAction? GetRoleAuthorizationActionById(int id) => GetById("spGetRoleAuthorizationActionById", id);

		public void UpdateRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction) => Update("spUpdateRoleAuthorizationAction", roleAuthorizationAction);
	}
}
