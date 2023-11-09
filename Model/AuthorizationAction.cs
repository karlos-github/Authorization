using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace AuthorizationStudio9.Model
{
	public class AuthorizationAction
	{
		public int AuthorizationActionId { get; set; }
		public int AuthorizationId { get; set; }
		public int ActionId { get; set; }
	}
}
