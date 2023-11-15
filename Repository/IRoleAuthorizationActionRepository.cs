using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IRoleAuthorizationActionRepository
	{
		IEnumerable<RoleAuthorizationAction> GetAllRoleAuthorizationActions();
		RoleAuthorizationAction? GetRoleAuthorizationActionById(int id);
		void AddRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction);
		void UpdateRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction);
		void DeleteRoleAuthorizationAction(int id);
	}
}
