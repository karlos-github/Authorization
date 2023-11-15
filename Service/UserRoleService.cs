using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class UserRoleService : IUserRoleService
	{
		IUserRoleRepository _userRoleRepository;
		public UserRoleService(IUserRoleRepository userRoleRepository) => _userRoleRepository = userRoleRepository;

		public void DeleteUserRole(int id) => _userRoleRepository.DeleteUserRole(id);

		public IEnumerable<UserRole> GetAllUserRoles() => _userRoleRepository.GetAllUserRoles();

		public UserRole? GetUserRoleById(int id) => _userRoleRepository.GetUserRoleById(id);

		public void InsertNewUserRole(UserRole userRole) => _userRoleRepository.AddUserRole(userRole);

		public void UpdateUserRole(UserRole userRole) => _userRoleRepository.UpdateUserRole(userRole);
	}
}
