using System.ComponentModel.DataAnnotations;

namespace AuthorizationStudio9.Model
{
	public class Authorization
	{
		[Key]
		public int AuthorizationId { get; set; }
		public string AuthorizationName { get; set; }
		public string Note { get; set; }

		public Authorization()
		{

		}

		public Authorization(int authorizationId, string authorizationName, string note)
		{
			AuthorizationId = authorizationId;
			AuthorizationName = authorizationName;
			Note = note;
		}
	}
}
