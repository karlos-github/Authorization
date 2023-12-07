using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IRoleAuthorizationActionService
	{
		IEnumerable<RoleAuthorizationAction> GetAllRoleAuthorizationActions();
		RoleAuthorizationAction? GetRoleAuthorizationActionById(int id);
		void AddRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction);
		void UpdateRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction);
		void DeleteRoleAuthorizationAction(int id);
	}
}
