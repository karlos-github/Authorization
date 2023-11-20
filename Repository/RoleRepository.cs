using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}
		public void DeleteRole(int id) => Delete("spDeleteRole", id);

		public IEnumerable<Role> GetAllRoles() => GetAll("exec spGetRoles");

		public void AddRole(Role role) => Add("spAddNewRole", role);

		public Role? GetRoleById(int id) => GetById("spGetRoleById", id);

		public void UpdateRole(Role role) => Update("spUpdateRole", role);
	}
}
