using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{

		public UserRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}
		public void DeleteUser(int id) => Delete("spDeleteUser", id);

		public IEnumerable<User> GetAllUsers() => GetAll("exec spGetUsers");

		public void AddUser(User user) => Add("spAddNewUser", user);

		public User? GetUserById(int id) => GetById("spGetUserById", id);

		public void UpdateUser(User user) => Update("spUpdateUser", user);
	}
}
