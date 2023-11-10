using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class UserAuthorizationActionRepository : IUserAuthorizationActionRepository
	{
		SqlConnection _con;

		public UserAuthorizationActionRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}

		public void DeleteUserAuthorizationAction(int id)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spDeleteUserAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserAuthorizationActionId", id);
				cmd.ExecuteNonQuery();
			}
		}

		public IEnumerable<UserAuthorizationAction> GetAllUserAuthorizationActions()
		{
			List<UserAuthorizationAction> userAuthorizationActions = new List<UserAuthorizationAction>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("exec spGetUserAuthorizationAction", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					userAuthorizationActions.Add(new UserAuthorizationAction()
					{
						UserAuthorizationActionId = Convert.ToInt32(rdr["UserAuthorizationActionId"]),
						UserId = Convert.ToInt32(rdr["UserId"]),
						AuthorizationActionId = Convert.ToInt32(rdr["AuthorizationActionId"]),
						IsAllowed = Convert.ToBoolean(rdr["IsAllowed"])
					});
				}
				return (userAuthorizationActions);
			}
		}

		public void InsertNewUserAuthorizationAction(UserAuthorizationAction userAuthorizationAction)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spAddNewUserAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserId", userAuthorizationAction.UserId);
				cmd.Parameters.AddWithValue("@AuthorizationActionId", userAuthorizationAction.AuthorizationActionId);
				cmd.Parameters.AddWithValue("@IsAllowed", userAuthorizationAction.IsAllowed);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateUserAuthorizationAction(UserAuthorizationAction userAuthorizationAction)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spUpdateUserAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserAuthorizationActionId", userAuthorizationAction.UserAuthorizationActionId);
				cmd.Parameters.AddWithValue("@UserId", userAuthorizationAction.UserId);
				cmd.Parameters.AddWithValue("@AuthorizationActionId", userAuthorizationAction.AuthorizationActionId);
				cmd.Parameters.AddWithValue("@IsAllowed", userAuthorizationAction.IsAllowed);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
