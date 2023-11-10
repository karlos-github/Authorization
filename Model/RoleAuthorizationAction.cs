using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace AuthorizationStudio9.Model
{
	public class RoleAuthorizationAction
	{
		public int RoleAuthorizationActionId { get; set; }
		public int RoleId { get; set; }
		public int AuthorizationActionId { get; set; }
		public bool IsAllowed { get; set; }
	}
}
