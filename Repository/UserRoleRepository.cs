using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
	{

		public UserRoleRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}

		public void DeleteUserRole(int id) => Delete("spDeleteUserRole", id);

		public IEnumerable<UserRole> GetAllUserRoles() => GetAll("exec spGetUserRoles");

		public void AddUserRole(UserRole userRole) => Add("spAddNewUserRole", userRole);

		public UserRole? GetUserRoleById(int id) => GetById("spGetUserRoleById", id);

		public void UpdateUserRole(UserRole userRole) => Update("spUpdateUserRole", userRole);
	}
}
