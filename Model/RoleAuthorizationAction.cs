using System.ComponentModel.DataAnnotations;

namespace AuthorizationStudio9.Model
{
	public class RoleAuthorizationAction
	{
		[Key]
		public int RoleAuthorizationActionId { get; set; }
		public int RoleId { get; set; }
		public int AuthorizationActionId { get; set; }
		public bool IsAllowed { get; set; }

		public RoleAuthorizationAction()
		{

		}

		public RoleAuthorizationAction(int roleAuthorizationActionId, int roleId, int authorizationActionId, bool isAllowed)
		{
			RoleAuthorizationActionId = roleAuthorizationActionId;
			RoleId = roleId;
			AuthorizationActionId = authorizationActionId;
			IsAllowed = isAllowed;
		}
	}
}
