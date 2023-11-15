using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IUserRoleService
	{
		IEnumerable<UserRole> GetAllUserRoles();
		UserRole? GetUserRoleById(int id);
		void InsertNewUserRole(UserRole userRole);
		void UpdateUserRole(UserRole userRole);
		void DeleteUserRole(int id);
	}
}
