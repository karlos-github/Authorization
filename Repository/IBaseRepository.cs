namespace AuthorizationStudio9.Repository
{
	interface IBaseRepository<T>
	{
		T GetById(string storedProcedureName, int id);
		IEnumerable<T> GetAll(string storedProcedureName);
		bool Add(string storedProcedureName, T entity);
		bool Update(string storedProcedureName, T entity);
		bool Delete(string storedProcedureName, int id);
	}
}
