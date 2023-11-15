using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class UserService : IUserService
	{
		IUserRepository _userRepository;
		public UserService(IUserRepository userRepository) => _userRepository = userRepository;
		public IEnumerable<User> GetAllUsers() => _userRepository.GetAllUsers();
		public User? GetUserById(int id) => _userRepository.GetUserById(id);
		public void InsertUser(User user) => _userRepository.AddUser(user);
		public void UpdateUser(User user) => _userRepository.UpdateUser(user);
		public void DeleteUser(int id) => _userRepository.DeleteUser(id);
	}
}
