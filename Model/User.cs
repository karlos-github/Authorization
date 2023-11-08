namespace AuthorizationStudio9.Model
{
	public class User
	{
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Note { get; set; }
		public DateTime RegistrationDate { get; set; }
		public bool ActiveUser { get; set; }
	}
}
