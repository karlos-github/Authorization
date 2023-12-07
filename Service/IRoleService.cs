using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IRoleService
	{
		IEnumerable<Role> GetAllRoles();
		Role? GetARoleById(int id);
		void AddRole(Role role);
		void UpdateRole(Role role);
		void DeleteRole(int id);
	}
}
