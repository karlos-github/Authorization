using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IRoleAuthorizationActionService
	{
		IEnumerable<RoleAuthorizationAction> GetAllRoleAuthorizationActions();
		void InsertNewRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction);
		void UpdateRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction);
		void DeleteRole(int id);
	}
}
