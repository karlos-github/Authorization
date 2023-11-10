using AuthorizationStudio9.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationStudio9.Repository
{
	public class UserCacheRepository : IUserCacheRepository
	{
		SqlConnection _con;

		public UserCacheRepository()
		{
			_con = new SqlConnection("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;");
			_con.Open();
		}

		public IEnumerable<UserCache> GetCache(bool forceUpdate)
		{
			List<UserCache> userCache = new List<UserCache>();
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new SqlCommand($"{(forceUpdate ? "exec spRefreshUserCache" : "exec spGetUserCache")}", _con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					userCache.Add(new UserCache()
					{
						UserId = Convert.ToInt32(rdr["UserId"]),
						AuthorizationId = Convert.ToInt32(rdr["AuthorizationId"]),
						ActionId = Convert.ToInt32(rdr["ActionId"])
					});
				}
				return (userCache);
			}
		}
	}
}
