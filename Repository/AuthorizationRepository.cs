using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class AuthorizationRepository : IAuthorizationRepository
	{
		SqlConnection _con;

		public AuthorizationRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}
		public void DeleteAuthorization(int id)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spDeleteAuthorization", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@AuthorizationId", id);
				cmd.ExecuteNonQuery();
			}
		}

		public IEnumerable<Authorization> GetAllAuthorizations()
		{
			List<Authorization> authorizations = new List<Authorization>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("exec spGetAuthorizations", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					authorizations.Add(new Authorization()
					{
						AuthorizationId = Convert.ToInt32(rdr["AuthorizationId"]),
						AuthorizationName = rdr["AuthorizationName"].ToString(),
						Note = rdr["Note"].ToString(),
					});
				}
				return (authorizations);
			}
		}

		public void InsertNewAuthorization(Authorization authorization)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spAddNewAuthorization", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@AuthorizationName", authorization.AuthorizationName);
				cmd.Parameters.AddWithValue("@Note", authorization.Note);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateAuthorization(Authorization authorization)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spUpdateAuthorization", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@AuthorizationId", authorization.AuthorizationId);
				cmd.Parameters.AddWithValue("@AuthorizationName", authorization.AuthorizationName);
				cmd.Parameters.AddWithValue("@Note", authorization.Note);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
