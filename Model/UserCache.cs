namespace AuthorizationStudio9.Model
{
	public class UserCache
	{
		public int UserId { get; set; }
		public int AuthorizationId { get; set; }
		public int ActionId { get; set; }

		public UserCache()
		{

		}

		public UserCache(int userId, int authorizationId, int actionId)
		{
			UserId = userId;
			AuthorizationId = authorizationId;
			ActionId = actionId;
		}
	}
}
