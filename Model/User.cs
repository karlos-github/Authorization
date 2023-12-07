using System.ComponentModel.DataAnnotations;

namespace AuthorizationStudio9.Model
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Note { get; set; }
		public DateTime RegistrationDate { get; set; }
		public bool ActiveUser { get; set; }

		public User()
		{

		}

		public User(int userId, string firstName, string lastName, string emailAddress, string note, DateTime registrationDate, bool activeUser)
		{
			UserId = userId;
			FirstName = firstName;
			LastName = lastName;
			EmailAddress = emailAddress;
			Note = note;
			RegistrationDate = registrationDate;
			ActiveUser = activeUser;
		}
	}
}
