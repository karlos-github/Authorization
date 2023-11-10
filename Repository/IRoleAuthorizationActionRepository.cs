using AuthorizationStudio9.Controllers;
using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IRoleAuthorizationActionRepository
	{
		IEnumerable<RoleAuthorizationAction> GetAllRoleAuthorizationActions();
		void InsertNewRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction);
		void UpdateRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction);
		void DeleteRoleAuthorizationAction(int id);
	}
}
