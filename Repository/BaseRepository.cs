using AuthorizationStudio9.Helper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace AuthorizationStudio9.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
	{
		SqlConnection _con;
		string[] _names;
		Type[] _types;

		public BaseRepository(string connectionString)
		{
			_con = new SqlConnection(connectionString);
			_con.Open();
			_names = typeof(T).GetProperties().Select(_ => _.Name).ToArray();
			_types = typeof(T).GetProperties().Select(_ => _.PropertyType).ToArray();
		}

		public bool Add(string storedProcedureName, T entity)
		{
			int rowsEffected = 0;
			try
			{
				using (_con)
				{
					if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
					rowsEffected = AssignCommand(storedProcedureName, entity).ExecuteNonQuery();
				}
			}
			catch (Exception) { throw; }
			return rowsEffected > 0;
		}

		public bool Delete(string storedProcedureName, int id)
		{
			int rowsEffected = 0;
			try
			{
				using (_con)
				{
					if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
					SqlCommand cmd = new(storedProcedureName, _con)
					{
						CommandType = CommandType.StoredProcedure
					};
					cmd.Parameters.AddWithValue(RepositoryHelper.GetKeyColumnName(typeof(T)), id);
					rowsEffected = cmd.ExecuteNonQuery();
				}
			}
			catch (Exception) { throw; }
			return rowsEffected > 0;
		}

		public IEnumerable<T> GetAll(string storedProcedureName)
		{
			using (_con)
			{
				if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
				SqlCommand cmd = new(storedProcedureName, _con);
				SqlDataReader rdr = cmd.ExecuteReader();
				return GetTable(rdr);
			}
		}

		public T? GetById(string storedProcedureName, int id)
		{
			try
			{
				using (_con)
				{
					if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
					SqlDataReader rdr = AssignCommand_(storedProcedureName, id).ExecuteReader();
					return GetRecord(rdr);
				}
			}
			catch (Exception) { throw; }
		}

		public bool Update(string storedProcedureName, T entity)
		{
			int rowsEffected = 0;
			try
			{
				using (_con)
				{
					if (_con != null && _con.State == ConnectionState.Closed) _con.Open();
					rowsEffected = AssignCommand(storedProcedureName, entity).ExecuteNonQuery();
				}
			}
			catch (Exception) { throw; }
			return rowsEffected > 0;
		}

		SqlCommand AssignCommand(string storedProcedureName, T entity)
		{
			SqlCommand cmd = new(storedProcedureName, _con)
			{
				CommandType = CommandType.StoredProcedure
			};
			for (int i = 0; i < _names.Length; i++)
				cmd.Parameters.AddWithValue($"@{_names[i]}", typeof(T).GetProperty(_names[i]).GetValue(entity));

			cmd.ExecuteNonQuery();
			return cmd;
		}

		SqlCommand AssignCommand_(string storedProcedureName, int id)
		{
			SqlCommand cmd = new(storedProcedureName, _con)
			{
				CommandType = CommandType.StoredProcedure
			};
			cmd.Parameters.AddWithValue($"@{RepositoryHelper.GetKeyColumnName(typeof(T))}", id);
			return cmd;
		}

		IEnumerable<T> GetTable(SqlDataReader rdr) => GetArguments(rdr);

		T? GetRecord(SqlDataReader rdr) => GetArgument(rdr);

		IEnumerable<T> GetArguments(SqlDataReader rdr)
		{
			var retVal = new List<T>();
			var result = new object[_types.Length];
			ObjectFactory<string, T>.Register(typeof(T).Name, _types);
			while (rdr.Read())
			{
				for (int i = 0; i < _names.Length; i++)
				{
					switch (_types[i])
					{
						case Type intType when intType == typeof(int):
							result[i] = (Convert.ToInt32(rdr[_names[i]]));
							break;
						case Type decimalType when decimalType == typeof(decimal):
							result[i] = (Convert.ToDecimal(rdr[_names[i]]));
							break;
						case Type stringType when stringType == typeof(string):
							result[i] = (rdr[_names[i].ToString()]);
							break;
						case Type dateTimeType when dateTimeType == typeof(DateTime):
							result[i] = (Convert.ToDateTime(rdr[_names[i]]));
							break;
						case Type boolType when boolType == typeof(bool):
							result[i] = (Convert.ToBoolean(rdr[_names[i]]));
							break;
					}
				}
				retVal.Add(ObjectFactory<string, T>.Create(typeof(T).Name, result));
			}
			return retVal;
		}

		T? GetArgument(SqlDataReader rdr)
		{
			T retVal = null;
			var result = new object[_types.Length];
			bool keepReading = true;
			ObjectFactory<string, T>.Register(typeof(T).Name, _types);
			while (rdr.Read() && keepReading)
			{
				for (int i = 0; i < _names.Length; i++)
				{
					switch (_types[i])
					{
						case Type intType when intType == typeof(int):
							result[i] = (Convert.ToInt32(rdr[_names[i]]));
							break;
						case Type decimalType when decimalType == typeof(decimal):
							result[i] = (Convert.ToDecimal(rdr[_names[i]]));
							break;
						case Type stringType when stringType == typeof(string):
							result[i] = (rdr[_names[i].ToString()]);
							break;
						case Type dateTimeType when dateTimeType == typeof(DateTime):
							result[i] = (Convert.ToDateTime(rdr[_names[i]]));
							break;
						case Type boolType when boolType == typeof(bool):
							result[i] = (Convert.ToBoolean(rdr[_names[i]]));
							break;
					}
				}
				keepReading = false;
				retVal = ObjectFactory<string, T>.Create(typeof(T).Name, result);
			}
			return retVal;
		}

		IEnumerable<object> GetDefaultArguments(SqlDataReader rdr)
		{
			var result = new List<object>();
			bool keepReading = true;
			while (rdr.Read() && keepReading)
			{
				for (int i = 0; i < _names.Length; i++)
				{
					switch (_types[i])
					{
						case Type intType when intType == typeof(int):
							result.Add(default(int));
							break;
						case Type decimalType when decimalType == typeof(decimal):
							result.Add(default(decimal));
							break;
						case Type stringType when stringType == typeof(string):
							result.Add(default(string));
							break;
						case Type dateTimeType when dateTimeType == typeof(DateTime):
							result.Add(default(DateTime));
							break;
						case Type boolType when boolType == typeof(bool):
							result.Add(default(bool));
							break;
					}
				}
				keepReading = false;
			}
			return result;
		}
	}
}
