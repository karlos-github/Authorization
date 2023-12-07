using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class RoleAuthorizationActionService : IRoleAuthorizationActionService
	{
		IRoleAuthorizationActionRepository _roleAuthorizationActionRepository;

		public RoleAuthorizationActionService(IRoleAuthorizationActionRepository roleAuthorizationActionRepository) => _roleAuthorizationActionRepository = roleAuthorizationActionRepository;

		public void AddRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction) => _roleAuthorizationActionRepository.AddRoleAuthorizationAction(roleAuthorizationAction);

		public void DeleteRole(int id) => _roleAuthorizationActionRepository.DeleteRoleAuthorizationAction(id);

		public void DeleteRoleAuthorizationAction(int id) => _roleAuthorizationActionRepository.DeleteRoleAuthorizationAction(id);

		public IEnumerable<RoleAuthorizationAction> GetAllRoleAuthorizationActions() => _roleAuthorizationActionRepository.GetAllRoleAuthorizationActions();

		public RoleAuthorizationAction? GetRoleAuthorizationActionById(int id) => _roleAuthorizationActionRepository.GetRoleAuthorizationActionById(id);

		public void UpdateRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction) => _roleAuthorizationActionRepository.UpdateRoleAuthorizationAction(roleAuthorizationAction);
	}
}
