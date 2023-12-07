using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace AuthorizationStudio9.Helper
{
	public static class RepositoryHelper
	{
		public static string _conStr;

		public static string? GetTableName(Type type) => type.GetCustomAttribute<TableAttribute>() != null ? type.GetCustomAttribute<TableAttribute>()?.Name : type.Name;

		public static string? GetKeyColumnName(Type type) => type.GetProperties().FirstOrDefault(_ => _.GetCustomAttribute(typeof(KeyAttribute), true) != null)?.Name;

		public static SqlConnection GetConnection()
		{
			try
			{
				SqlConnection connection = new SqlConnection(_conStr);
				return connection;
			}
			catch (Exception e) { throw; }
		}
	}
}
