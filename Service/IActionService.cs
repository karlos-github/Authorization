using AuthorizationStudio9.Model;
using Action = AuthorizationStudio9.Model.Action;

namespace AuthorizationStudio9.Service
{
	public interface IActionService
	{
		IEnumerable<Action> GetAllActions();
		Action? GetActionById(int id);
		void AddAction(Action action);
		void UpdateAction(Action action);
		void DeleteAction(int id);
	}
}
