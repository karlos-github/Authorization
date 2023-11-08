using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IRoleRepository
	{
		IEnumerable<Role> GetAllRoles();
		void InsertNewRole(Role role);
		void UpdateRole(Role role);
		void DeleteRole(int id);
	}
}
