using System.ComponentModel.DataAnnotations;

namespace AuthorizationStudio9.Model
{
	public class Role
	{
		[Key]
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public string Note { get; set; }

		public Role()
		{

		}

		public Role(int roleId, string roleName, string note)
		{
			RoleId = roleId;
			RoleName = roleName;
			Note = note;
		}
	}
}
