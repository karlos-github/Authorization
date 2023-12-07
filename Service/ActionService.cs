using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class ActionService : IActionService
	{
		IActionRepository _actionRepository;
		
		public ActionService(IActionRepository actionRepository) => _actionRepository = actionRepository;
        
		public void DeleteAction(int id) => _actionRepository.DeleteAction(id);

		public IEnumerable<Model.Action> GetAllActions() => _actionRepository.GetAllActions();

		public Model.Action? GetActionById(int id) => _actionRepository.GetActionById(id);

		public void AddAction(Model.Action action) => _actionRepository.AddAction(action);

		public void UpdateAction(Model.Action action) => _actionRepository.UpdateAction(action);
	}
}
