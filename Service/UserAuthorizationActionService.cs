﻿using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;

namespace AuthorizationStudio9.Service
{
	public class UserAuthorizationActionService : IUserAuthorizationActionService

	{
		IUserAuthorizationActionRepository _userAuthorizationActionRepository;

		public UserAuthorizationActionService(IUserAuthorizationActionRepository userAuthorizationActionRepository) => _userAuthorizationActionRepository = userAuthorizationActionRepository;

		public void DeleteUserAuthorizationAction(int id) => _userAuthorizationActionRepository.DeleteUserAuthorizationAction(id);

		public IEnumerable<UserAuthorizationAction> GetAllUserAuthorizationActions() => _userAuthorizationActionRepository.GetAllUserAuthorizationActions();

		public UserAuthorizationAction? GetUserAuthorizationActionById(int id) => _userAuthorizationActionRepository.GetUserAuthorizationActionById(id);

		public void InsertUserAuthorizationAction(UserAuthorizationAction userAuthorizationAction) => _userAuthorizationActionRepository.AddUserAuthorizationAction(userAuthorizationAction);

		public void UpdateUserAuthorizationAction(UserAuthorizationAction userAuthorizationAction) => _userAuthorizationActionRepository.UpdateUserAuthorizationAction(userAuthorizationAction);
	}
}
