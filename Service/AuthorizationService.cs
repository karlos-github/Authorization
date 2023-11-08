using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class AuthorizationService : IAuthorizationService
	{
		IUserRepository _userRepository;
		public AuthorizationService(IUserRepository userRepository) => _userRepository = userRepository;
		public IEnumerable<User> GetAllUsers() => _userRepository.GetAllUsers();
		public void InsertUser(User user) => _userRepository.InsertNewUser(user);
		public void UpdateUser(User user) => _userRepository.UpdateUser(user);
		public void DeleteUser(int id) => _userRepository.DeleteUser(id);
	}
}
