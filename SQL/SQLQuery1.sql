
--- User table (uživatel)
--------------------------------
--- Get
--create procedure spGetUser    
--as    
--begin     
--select * from dbo.[User]
--end 

--- Insert
--drop procedure spAddNewUser;
--create procedure spAddNewUser    
--(    
--@FirstName nvarchar(255),    
--@LastName nvarchar(255),    
--@EmailAddress nvarchar(255),    
--@Note nvarchar(255)  
--)    
--as    
--begin    
--    Insert into [User] (FirstName, LastName, EmailAddress, Note)
--values 
--(@FirstName,@LastName, @EmailAddress, @Note);   
--end   

--- Update
--create procedure spUpdateUser    
--(    
--@UserId int,    
--@FirstName nvarchar(255),    
--@LastName nvarchar(255),    
--@EmailAddress nvarchar(255),    
--@Note nvarchar(255),
--@RegistrationDate datetime,
--@ActiveUser bit
--)    
--as    
--begin    
--    update [User]     
--    set     
--	FirstName = @FirstName,    
--	LastName = @LastName,    
--	EmailAddress = @EmailAddress,    
--	Note = @Note,
--	RegistrationDate = @RegistrationDate,
--	ActiveUser = @ActiveUser    
--    where UserId=@UserId    
--end  

--- Delete
--create procedure spDeleteUser    
--(    
--@UserId int    
--)    
--as    
--begin    
--    delete from [User] where UserId=@UserId    
--end 

--- Role table (role)
--------------------------------
--- Get
--create procedure spGetRoles    
--as    
--begin     
--select * from dbo.[Role]
--end 

--- Insert
--drop procedure spAddNewUser;
--create procedure spAddNewRole    
--(    
--@RoleName nvarchar(255),    
--@Note nvarchar(255)
--)    
--as    
--begin    
--    Insert into [Role] (RoleName, Note)
--values 
--(@RoleName,@Note);   
--end 

--- Update
--create procedure spUpdateRole    
--(    
--@RoleId int,    
--@RoleName nvarchar(255),    
--@Note nvarchar(255)
--)    
--as    
--begin    
--    update [Role]     
--    set     
--	RoleName = @RoleName,    
--	Note = @Note
--    where RoleId=@RoleId    
--end 

--create procedure spDeleteRole    
--(    
--@RoleId int    
--)    
--as    
--begin    
--    delete from [Role] where RoleId=@RoleId    
--end 


--- Authorization table
------------------------------------------------
--- Get
--create procedure spGetActions
--as    
--begin     
--select * from Action
--end 

--- Insert
--create procedure spAddNewAction    
--(    
--@ACtionName nvarchar(255),    
--@Note nvarchar(255)  
--)    
--as    
--begin    
--    Insert into Action (ACtionName, Note)
--values 
--(@ActionName, @Note);   
--end    

--- Update
--create procedure spUpdateAction    
--(    
--@ActionId int,    
--@ActionName nvarchar(255),    
--@Note nvarchar(255)
--)    
--as    
--begin    
--    update Action     
--    set     
--	ActionName = @ActionName,    
--	Note = @Note
--    where ActionId=@ActionId    
--end  

--create procedure spDeleteAction    
--(    
--@ActionId int    
--)    
--as    
--begin    
--    delete from Action where ActionId=@ActionId    
--end 


--- AuthorizationAction table (oprávnění - akce)
------------------------------------------------
--- Get
--create procedure spGetAuthorizations
--as    
--begin     
--select * from [Authorization]
--end 

--- Insert
--create procedure spAddNewAuthorization    
--(    
--@AuthorizationName nvarchar(255),     
--@Note nvarchar(255)  
--)    
--as    
--begin    
--    Insert into [Authorization] (AuthorizationName, Note)
--values 
--(@AuthorizationName, @Note);   
--end    

--- Update
--create procedure spUpdateAuthorization    
--(    
--@AuthorizationId int,    
--@AuthorizationName nvarchar(255),    
--@Note nvarchar(255)
--)    
--as    
--begin    
--    update [Authorization]     
--    set     
--	AuthorizationName = @AuthorizationName,    
--	Note = @Note
--    where AuthorizationId=@AuthorizationId    
--end  

--- Delete
--create procedure spDeleteAuthorization    
--(    
--@AuthorizationId int    
--)    
--as    
--begin    
--    delete from [Authorization] where AuthorizationId=@AuthorizationId    
--end 

--- UserRole table (uživatel - role)
------------------------------------------------
--- Get
--drop procedure spGetUserRoles      
--create procedure spGetUserRoles
--as    
--begin     
--select * from User_Role
--end 

--- Insert
--create procedure spAddNewUserRole    
--(    
--@UserId int,     
--@RoleId int
--)    
--as    
--begin    
--    Insert into User_Role (UserId, RoleId)
--values 
--(@UserId, @RoleId);   
--end    

--- Update
--create procedure spUpdateUserRole    
--(    
--@UserRoleId int,     
--@UserId int,     
--@RoleId int
--)    
--as    
--begin    
--    update User_Role     
--    set     
--	UserId = @UserId,    
--	RoleId = @RoleId
--    where UserRoleId=@UserRoleId
--end  

--- Delete
--create procedure spDeleteUserRole  
--(    
--@UserRoleId int    
--)    
--as    
--begin    
--    delete from User_Role where UserRoleId=@UserRoleId
--end 

--- AuthorizationAction table (oprávnění - akce)
------------------------------------------------
--- Get
--use AuthorizationStudio9;
--drop procedure spGetAuthorizationAction      
--create procedure spGetAuthorizationAction
--as    
--begin     
--select * from Authorization_Action
--end 

--- Insert
--create procedure spAddNewAuthorizationAction    
--(    
--@AuthorizationId int,     
--@ActionId int
--)    
--as    
--begin    
--    Insert into Authorization_Action (AuthorizationId, ActionId)
--values 
--(@AuthorizationId, @ActionId);   
--end    

--- Update
--create procedure spUpdateAuthorizationAction    
--(    
--@AuthorizationActionId int,     
--@AuthorizationId int,     
--@ActionId int
--)    
--as    
--begin    
--    update Authorization_Action     
--    set     
--	AuthorizationId = @AuthorizationId,    
--	ActionId = @ActionId
--    where AuthorizationActionId=@AuthorizationActionId
--end  

--- Delete
--create procedure spDeleteAuthorizationAction  
--(    
--@AuthorizationActionId int    
--)    
--as    
--begin    
--    delete from Authorization_Action where AuthorizationActionId=@AuthorizationActionId
--end 


--- Role_AuthorizationAction table (role - (oprávnění - akce))
------------------------------------------------
--- Get
--use AuthorizationStudio9;
--drop procedure spGetRoleAuthorizationAction      
--create procedure spGetRoleAuthorizationAction
--as    
--begin     
--select * from Role_AuthorizationAction
--end 

--- Insert
--create procedure spAddNewRoleAuthorizationAction
--(    
--@RoleId int,     
--@AuthorizationActionId int,     
--@IsAllowed bit
--)    
--as    
--begin    
--    Insert into Role_AuthorizationAction (RoleId, AuthorizationActionId, IsAllowed)
--values 
--(@RoleId, @AuthorizationActionId, @IsAllowed);   
--end    

--- Update
--create procedure spUpdateRoleAuthorizationAction
--(    
--@RoleAuthorizationActionId int,
--@RoleId int,     
--@AuthorizationActionId int,     
--@IsAllowed bit
--)    
--as    
--begin    
--  update Role_AuthorizationAction     
--  set     
--	AuthorizationActionId = @AuthorizationActionId,    
--	RoleId = @RoleId,
--  IsAllowed = @IsAllowed
--  where RoleAuthorizationActionId=@RoleAuthorizationActionId
--end  

--- Delete
--create procedure spDeleteRoleAuthorizationAction
--(    
--@RoleAuthorizationActionId int    
--)    
--as    
--begin    
--delete from Role_AuthorizationAction where RoleAuthorizationActionId=@RoleAuthorizationActionId
--end 

--- User_AuthorizationAction table (uživatel - (oprávnění - akce))
------------------------------------------------
--- Get
--use AuthorizationStudio9;
--drop procedure spGetUserAuthorizationAction      
--create procedure spGetUserAuthorizationAction
--as    
--begin     
--select * from User_AuthorizationAction
--end 

--- Insert
--create procedure spAddNewUserAuthorizationAction
--(    
--@UserId int,     
--@AuthorizationActionId int,     
--@IsAllowed bit
--)    
--as    
--begin    
--    Insert into User_AuthorizationAction (UserId, AuthorizationActionId, IsAllowed)
--values 
--(@UserId, @AuthorizationActionId, @IsAllowed);   
--end    

--- Update
--create procedure spUpdateUserAuthorizationAction
--(    
--@UserAuthorizationActionId int,
--@UserId int,     
--@AuthorizationActionId int,     
--@IsAllowed bit
--)    
--as    
--begin    
--  update User_AuthorizationAction     
--  set     
--	AuthorizationActionId = @AuthorizationActionId,    
--	UserId = @UserId,
--  IsAllowed = @IsAllowed
--  where UserAuthorizationActionId=@UserAuthorizationActionId
--end  

--- Delete
--create procedure spDeleteUserAuthorizationAction
--(    
--@UserAuthorizationActionId int    
--)    
--as    
--begin    
--delete from User_AuthorizationAction where UserAuthorizationActionId=@UserAuthorizationActionId
--end 


--- Cache table (uživatel - oprávnění - akce)
--------------------------------------------------------------------
--- Get
--use AuthorizationStudio9;   
--create procedure spGetUserCache
--as    
--begin     
--select * from UserCache
--end 

--- Update
--create procedure spRefreshUserCache    
--as    
--begin    
--delete from UserCache;
--insert into UserCache
--select uaa.UserId, aa.AuthorizationId, aa.ActionId from User_AuthorizationAction as uaa
--inner join Authorization_Action as aa
--on uaa.AuthorizationActionId = aa.AuthorizationActionId
--union
--select ur.UserId,  aa.AuthorizationId, aa.ActionId from User_Role as ur
--inner join Role_AuthorizationAction as raa
--on ur.RoleId = raa.RoleId
--inner join Authorization_Action as aa
--on aa.AuthorizationActionId = raa.AuthorizationActionId;
--end  


