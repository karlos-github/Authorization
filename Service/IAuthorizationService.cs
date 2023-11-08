﻿using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Service
{
	public interface IAuthorizationService
	{
		IEnumerable<Authorization> GetAllAuthorizations();
		void InsertAuthorization(Authorization authorization);
		void UpdateAuthorization(Authorization authorization);
		void DeleteAuthorization(int id);
	}
}
