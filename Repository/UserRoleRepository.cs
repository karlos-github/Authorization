using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class UserRoleRepository : IUserRoleRepository
	{
		SqlConnection _con;

		public UserRoleRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}

		public void DeleteUserRole(int id)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spDeleteUserRole", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserRoleId", id);
				cmd.ExecuteNonQuery();
			}
		}

		public IEnumerable<UserRole> GetAllUserRoles()
		{
			List<UserRole> employees = new List<UserRole>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("exec spGetUserRoles", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					employees.Add(new UserRole()
					{ 
						UserRoleId = Convert.ToInt32(rdr["UserRoleId"]),
						UserId = Convert.ToInt32(rdr["UserId"]),
						RoleId = Convert.ToInt32(rdr["RoleId"]),
					});
				}
				return (employees);
			}
		}

		public void InsertNewUserRole(UserRole userRole)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spAddNewUserRole", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserId", userRole.UserId);
				cmd.Parameters.AddWithValue("@RoleId", userRole.RoleId);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateUserRole(UserRole userRole)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spUpdateUserRole", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@UserRoleId", userRole.UserRoleId);
				cmd.Parameters.AddWithValue("@UserId", userRole.UserId);
				cmd.Parameters.AddWithValue("@RoleId", userRole.RoleId);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
