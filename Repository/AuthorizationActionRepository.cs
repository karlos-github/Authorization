using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class AuthorizationActionRepository : IAuthorizationActionRepository
	{
		SqlConnection _con;

		public AuthorizationActionRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}

		public void DeleteAuthorizationAction(int id)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spDeleteAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@AuthorizationActionId", id);
				cmd.ExecuteNonQuery();
			}
		}

		public IEnumerable<AuthorizationAction> GetAllAuthorizationActions()
		{
			List<AuthorizationAction> authorizationActions = new List<AuthorizationAction>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("exec spGetAuthorizationAction", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					authorizationActions.Add(new AuthorizationAction()
					{
						AuthorizationActionId = Convert.ToInt32(rdr["AuthorizationActionId"]),
						AuthorizationId= Convert.ToInt32(rdr["AuthorizationId"]),
						ActionId = Convert.ToInt32(rdr["ActionId"]),
					});
				}
				return (authorizationActions);
			}
		}

		public void InsertNewAuthorizationAction(AuthorizationAction authorizationAction)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spAddNewAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@AuthorizationId", authorizationAction.AuthorizationId);
				cmd.Parameters.AddWithValue("@ActionId", authorizationAction.ActionId);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateAuthorizationAction(AuthorizationAction authorizationAction)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spUpdateAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@AuthorizationId", authorizationAction.AuthorizationId);
				cmd.Parameters.AddWithValue("@ActionId", authorizationAction.ActionId);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
