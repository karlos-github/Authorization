using System.ComponentModel.DataAnnotations;

namespace AuthorizationStudio9.Model
{
	public class UserAuthorizationAction
	{
		[Key]
		public int UserAuthorizationActionId { get; set; }
		public int UserId { get; set; }
		public int AuthorizationActionId { get; set; }
		public bool IsAllowed { get; set; }

		public UserAuthorizationAction()
		{

		}

		public UserAuthorizationAction(int userAuthorizationActionId, int userId, int authorizationActionId, bool isAllowed)
		{
			UserAuthorizationActionId = userAuthorizationActionId;
			UserId = userId;
			AuthorizationActionId = authorizationActionId;
			IsAllowed = isAllowed;
		}
	}
}
