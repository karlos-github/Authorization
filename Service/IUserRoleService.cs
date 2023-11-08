using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IUserRoleService
	{
		IEnumerable<UserRole> GetAllUserRoles();
		void InsertNewUserRole(UserRole userRole);
		void UpdateUserRole(UserRole userRole);
		void DeleteUserRole(int id);
	}
}
