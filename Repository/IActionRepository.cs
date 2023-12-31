﻿using Action = AuthorizationStudio9.Model.Action;

namespace AuthorizationStudio9.Repository
{
	public interface IActionRepository
	{
		IEnumerable<Action> GetAllActions();
		Action? GetActionById(int id);
		void AddAction(Action action);
		void UpdateAction(Action action);
		void DeleteAction(int id);
	}
}
