using System.ComponentModel.DataAnnotations;

namespace AuthorizationStudio9.Model
{
	public class AuthorizationAction
	{
		[Key]
		public int AuthorizationActionId { get; set; }
		public int AuthorizationId { get; set; }
		public int ActionId { get; set; }

		public AuthorizationAction()
		{

		}

		public AuthorizationAction(int authorizationActionId, int authorizationId, int actionId)
		{
			AuthorizationActionId = authorizationActionId;
			AuthorizationId = authorizationId;
			ActionId = actionId;
		}
	}
}
