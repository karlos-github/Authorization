namespace AuthorizationStudio9.Repository
{
	public class ActionRepository : BaseRepository<Model.Action>, IActionRepository
	{
		public ActionRepository() : base("Server=KSKRABAL\\ECSQLEXPRESS;Database=AuthorizationStudio9;Trusted_Connection=True;TrustServerCertificate=True;")
		{
		}
		public void DeleteAction(int id) => Delete("spDeleteAction", id);

		public IEnumerable<Model.Action> GetAllActions() => GetAll("exec spGetActions");

		public void AddAction(Model.Action action) => Add("spAddNewAction", action);

		public Model.Action? GetActionById(int id) => GetById("spGetActionById", id);

		public void UpdateAction(Model.Action action) => Update("spUpdateAction", action);
	}
}
