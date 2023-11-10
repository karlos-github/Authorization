using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class RoleAuthorizationActionRepository : IRoleAuthorizationActionRepository
	{
		SqlConnection _con;

		public RoleAuthorizationActionRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}

		public void DeleteRoleAuthorizationAction(int id)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spDeleteRoleAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RoleAuthorizationActionId", id);
				cmd.ExecuteNonQuery();
			}
		}

		public IEnumerable<RoleAuthorizationAction> GetAllRoleAuthorizationActions()
		{
			List<RoleAuthorizationAction> roleAuthorizationActions = new List<RoleAuthorizationAction>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("exec spGetRoleAuthorizationAction", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					roleAuthorizationActions.Add(new RoleAuthorizationAction()
					{
						RoleAuthorizationActionId = Convert.ToInt32(rdr["RoleAuthorizationActionId"]),
						RoleId = Convert.ToInt32(rdr["RoleId"]),
						AuthorizationActionId = Convert.ToInt32(rdr["AuthorizationActionId"]),
						IsAllowed = Convert.ToBoolean(rdr["IsAllowed"])
					});
				}
				return (roleAuthorizationActions);
			}
		}

		public void InsertNewRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spAddNewRoleAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RoleId", roleAuthorizationAction.RoleId);
				cmd.Parameters.AddWithValue("@AuthorizationActionId", roleAuthorizationAction.AuthorizationActionId);
				cmd.Parameters.AddWithValue("@IsAllowed", roleAuthorizationAction.IsAllowed);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateRoleAuthorizationAction(RoleAuthorizationAction roleAuthorizationAction)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spUpdateRoleAuthorizationAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RoleAuthorizationActionId", roleAuthorizationAction.RoleAuthorizationActionId);
				cmd.Parameters.AddWithValue("@RoleId", roleAuthorizationAction.RoleId);
				cmd.Parameters.AddWithValue("@AuthorizationActionId", roleAuthorizationAction.AuthorizationActionId);
				cmd.Parameters.AddWithValue("@IsAllowed", roleAuthorizationAction.IsAllowed);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
