using System.ComponentModel.DataAnnotations;

namespace AuthorizationStudio9.Model
{
	public class UserRole
	{
		[Key]
		public int UserRoleId { get; set; }
		public int UserId { get; set; }
		public int RoleId { get; set; }

		public UserRole()
		{

		}

		public UserRole(int userRoleId, int userId, int roleId)
		{
			UserRoleId = userRoleId;
			UserId = userId;
			RoleId = roleId;
		}
	}
}
