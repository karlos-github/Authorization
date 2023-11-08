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

		public void InsertNewUserRole(UserRole userRole) => _userRoleRepository.InsertNewUserRole(userRole);

		public void UpdateUserRole(UserRole userRole) => _userRoleRepository.UpdateUserRole(userRole);
	}
}
