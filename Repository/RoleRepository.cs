using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class RoleRepository : IRoleRepository
	{
		SqlConnection _con;
		public RoleRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}

		public void DeleteRole(int id)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spDeleteRole", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RoleId", id);
				cmd.ExecuteNonQuery();
			}
		}

		public IEnumerable<Role> GetAllRoles()
		{
			List<Role> roles = new List<Role>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("exec spGetRoles", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					roles.Add(new Role()
					{
						RoleId = Convert.ToInt32(rdr["RoleId"]),
						RoleName = rdr["RoleName"].ToString(),
						Note = rdr["Note"].ToString(),
					});
				}
				return (roles);
			}
		}

		public void InsertNewRole(Role role)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spAddNewRole", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
				cmd.Parameters.AddWithValue("@Note", role.Note);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateRole(Role role)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spUpdateRole", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RoleId", role.RoleId);
				cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
				cmd.Parameters.AddWithValue("@Note", role.Note);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
