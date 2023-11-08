using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class UserRepository : IUserRepository
	{
		SqlConnection _con;

		public UserRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}

		public IEnumerable<User> GetAllUsers()
		{
			List<User> employees = new List<User>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("exec spGetUser", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					employees.Add(new User()
					{
						UserId = Convert.ToInt32(rdr["UserId"]),
						FirstName = rdr["FirstName"].ToString(),
						LastName = rdr["LastName"].ToString(),
						EmailAddress = rdr["EmailAddress"].ToString(),
						Note = rdr["Note"].ToString(),
						RegistrationDate = Convert.ToDateTime(rdr["RegistrationDate"]),
						ActiveUser = Convert.ToBoolean(rdr["ActiveUser"])
					});
				}
				return (employees);
			}
		}

		public void InsertNewUser(User user)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spAddNewUser", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
				cmd.Parameters.AddWithValue("@LastName", user.LastName);
				cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
				cmd.Parameters.AddWithValue("@Note", user.Note);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateUser(User user)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spUpdateUser", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserId", user.UserId);
				cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
				cmd.Parameters.AddWithValue("@LastName", user.LastName);
				cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
				cmd.Parameters.AddWithValue("@Note", user.Note);
				cmd.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
				cmd.Parameters.AddWithValue("@ActiveUser", user.ActiveUser);
				cmd.ExecuteNonQuery();
			}
		}

		public void DeleteUser(int id)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spDeleteUser", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserId", id);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
