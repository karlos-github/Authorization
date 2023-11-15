using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IUserService
	{
		IEnumerable<User> GetAllUsers();
		User? GetUserById(int id);
		void InsertUser(User user);
		void UpdateUser(User user);
		void DeleteUser(int id);
	}
}
