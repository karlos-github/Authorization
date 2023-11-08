using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class ActionRepository : IActionRepository
	{
		SqlConnection _con;

		public ActionRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}
		public void DeleteAction(int id)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spDeleteAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ActionId", id);
				cmd.ExecuteNonQuery();
			}
		}

		public IEnumerable<Model.Action> GetAllActions()
		{
			List<Model.Action> employees = new List<Model.Action>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("exec spGetActions", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					employees.Add(new Model.Action()
					{
						ActionId = Convert.ToInt32(rdr["ActionId"]),
						ActionName = rdr["ActionName"].ToString(),
						Note = rdr["Note"].ToString(),
					});
				}
				return (employees);
			}
		}

		public void InsertNewAction(Model.Action action)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spAddNewAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ActionName", action.ActionName);
				cmd.Parameters.AddWithValue("@Note", action.Note);
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateAction(Model.Action action)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand("spUpdateAction", _con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ActionId", action.ActionId);
				cmd.Parameters.AddWithValue("@ActionName", action.ActionName);
				cmd.Parameters.AddWithValue("@Note", action.Note);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
