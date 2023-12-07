using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;
using System.Data;

namespace AuthorizationStudio9.Service
{
	public class RoleService : IRoleService
	{
		IRoleRepository _roleRepository;
		public RoleService(IRoleRepository roleRepository) => _roleRepository = roleRepository;
		public void DeleteRole(int id) => _roleRepository.DeleteRole(id);

		public IEnumerable<Role> GetAllRoles() => _roleRepository.GetAllRoles();

		public void AddRole(Role role) => _roleRepository.AddRole(role);

		public void UpdateRole(Role role) => _roleRepository.UpdateRole(role);

		public Role? GetARoleById(int id) => _roleRepository.GetRoleById(id);
	}
}
