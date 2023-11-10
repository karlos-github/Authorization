using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace AuthorizationStudio9.Model
{
	public class UserAuthorizationAction
	{
		public int UserAuthorizationActionId { get; set; }
		public int UserId { get; set; }
		public int AuthorizationActionId { get; set; }
		public bool IsAllowed { get; set; }
	}
}
