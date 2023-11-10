using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class RoleAuthorizationActionService : IRoleAuthorizationActionService
	{
		IRoleAuthorizationActionRepository _roleAuthorizationActionRepository;
		public RoleAuthorizationActionService(IRoleAuthorizationActionRepository roleAuthorizationActionRepository) => _roleAuthorizationActionRepository = roleAuthorizationActionRepository;
        
		public void DeleteRole(int id) => _roleAuthorizationActionRepository.DeleteRoleAuthorizationAction(id);

		public IEnumerable<RoleAuthorizationAction> GetAllRoleAuthorizationActions() => _roleAuthorizationActionRepository.GetAllRoleAuthorizationActions();

		public void InsertNewRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction) => _roleAuthorizationActionRepository.InsertNewRoleAuthorizationAction(roleAuthorizationAction);

		public void UpdateRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction) => _roleAuthorizationActionRepository.UpdateRoleAuthorizationAction(roleAuthorizationAction);
	}
}
