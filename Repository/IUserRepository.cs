using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
	public interface IUserRepository
	{
		IEnumerable<User> GetAllUsers();
		void InsertNewUser(User user);
		void UpdateUser(User user);
		void DeleteUser(int id);
		//IList<User> GetUsers();
	}
}
