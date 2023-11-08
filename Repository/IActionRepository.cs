using AuthorizationStudio9.Model;
using Action = AuthorizationStudio9.Model.Action;

namespace AuthorizationStudio9.Repository
{
	public interface IActionRepository
	{
		IEnumerable<Action> GetAllActions();
		void InsertNewAction(Action action);
		void UpdateAction(Action action);
		void DeleteAction(int id);
	}
}
