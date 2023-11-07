
BEGIN --- AuthorizationStudio9 database

drop database AuthorizationStudio9;
create database AuthorizationStudio9;

END
--------------------------------------------------------------------------------------------
Begin --- User table (uživatel)

use AuthorizationStudio9;
drop table [User];

CREATE TABLE [User] (
    UserId int primary key identity(1,1),
    FirstName varchar(255),
    LastName varchar(255),
    EmailAddress varchar(255),
    Note varchar(255),
    RegistrationDate datetime default CURRENT_TIMESTAMP,
    ActiveUser Bit default 1
);

Insert into [User] (FirstName, LastName, EmailAddress, Note)
values 
('Karel', 'Škrabal', 'biglebowskij@seznam.cz', 'some note'),
('Karlos', 'Škrabalos', 'biglebowskij@emil.cz', 'some note about Karlos'),
('Kadlik', 'Škrabalik', 'biglebowskij@gmail.cz', 'some note about Kadlik');

Select * from [User];

update [User]
set ActiveUser = 0
where UserId = 1;

End
--------------------------------------------------------------------------------------------
Begin --- Role table (role)

use AuthorizationStudio9;
drop table [Role];

use AuthorizationStudio9;
CREATE TABLE [Role] (
    RoleId int primary key identity(1,1),
    RoleName varchar(255),
    Note varchar(255),
);

use AuthorizationStudio9;
Insert into [Role] (RoleName, Note)
values 
('Admin', 'Admin role note'),
('Viewer', 'Viewer role note'),
('User', 'User role note');

Select * from [Role];

end
--------------------------------------------------------------------------------------------
Begin --- Authorization table (oprávnìní)

use AuthorizationStudio9;
drop table [Authorization];

use AuthorizationStudio9;
CREATE TABLE [Authorization](
    AuthorizationId int primary key identity(1,1),
    AuthorizationName varchar(255),
    Note varchar(255),
);

use AuthorizationStudio9;
Insert into [Authorization] (AuthorizationName, Note)
values 
('Customers', 'Customers module authorization note'),
('Invoices', 'Invoice module authorization note'),
('Orders', 'Orders module authorization note');

Select * from [Authorization];

update [Authorization]
set AuthorizationName = 'Customers'
where AuthorizationId = 1;

end
--------------------------------------------------------------------------------------------
Begin --- Action table (akce)

use AuthorizationStudio9;
drop table Action;

use AuthorizationStudio9;
CREATE TABLE Action (
    ActionId int primary key identity(1,1),
    ACtionName varchar(255),
    Note varchar(255)
);

use AuthorizationStudio9;
Insert into Action (ACtionName, Note)
values 
('View', 'Action View note'),
('Edit', 'Action Edit note'),
('Add', 'Action Add note'),
('Delete', 'Action Delete note');

Select * from Action;

end
----------------------------------------------------------------------------------
Begin --- UserRole table (uživatel - role)
use AuthorizationStudio9;
drop table User_Role;

use AuthorizationStudio9;
CREATE TABLE User_Role(
	UserRoleId int primary key identity(1,1),
	UserId int,
    RoleId int ,
	constraint FK_User1 foreign key (UserId) references [User] (UserId),
	constraint FK_Role1 foreign key (RoleId) references Role (RoleId),
);

use AuthorizationStudio9;
Insert into User_Role(UserId, RoleId)
values 
(1, 1),
(1, 2),
(2, 3),
(3, 1);

Select * from User_Role;

delete from User_Role;
update User_Role set RoleId = 2 where UserRoleId = 11
Select * from User_Role;

end
----------------------------------------------------------------------------------
Begin --- AuthorizationAction table (oprávnìní - akce)

use AuthorizationStudio9;
drop table Authorization_Action;

use AuthorizationStudio9;
CREATE TABLE Authorization_Action (
	AuthorizationActionId int primary key identity(1,1),
	AuthorizationId int,
    ActionId int ,
	constraint FK_Authorization foreign key (AuthorizationId) references [Authorization] (AuthorizationId),
	constraint FK_Action foreign key (ActionId) references Action (ActionId),
);

use AuthorizationStudio9;
Insert into Authorization_Action (AuthorizationId, ActionId)
values 
(1, 1),
(1, 2),
(3, 3),
(1, 4),
(2, 1),
(2, 4);

Select * from Authorization_Action;

end
----------------------------------------------------------------------------------
Begin --- Role_AuthorizationAction table (role - (oprávnìní - akce))

use AuthorizationStudio9;
drop table Role_AuthorizationAction;

use AuthorizationStudio9;
CREATE TABLE Role_AuthorizationAction (
	RoleAuthorizationActionId int primary key identity(1,1),
	RoleId int,
    AuthorizationActionId int,
	IsAllowed bit,
	constraint  FK_Role foreign key (RoleId) references Role (RoleId),
	constraint FK_AuthorizationAction foreign key (AuthorizationActionId) references Authorization_Action (AuthorizationActionId)
);

use AuthorizationStudio9;
Insert into Role_AuthorizationAction (RoleId, AuthorizationActionId, IsAllowed)
values 
(1, 1, 1),
(1, 2, 1),
(2, 3, 1),
(2, 1, 0),
(3, 2, 1);

delete from Role_AuthorizationAction where RoleAuthorizationActionId = 5
Select * from Role_AuthorizationAction;

end
----------------------------------------------------------------------------------
Begin --- User_AuthorizationAction table (uživatel - (oprávnìní - akce))

use AuthorizationStudio9;
drop table User_AuthorizationAction;

use AuthorizationStudio9;
CREATE TABLE User_AuthorizationAction (
    UserAuthorizationActionId int primary key identity(1,1),
	UserId int,
    AuthorizationActionId int,
	IsAllowed bit,
	constraint  FK_User foreign key (UserId) references [User] (UserId),
	constraint FK_AuthorizationAction1 foreign key (AuthorizationActionId) references Authorization_Action (AuthorizationActionId)
);

use AuthorizationStudio9;
Insert into User_AuthorizationAction (UserId, AuthorizationActionId, IsAllowed)
values 
(1, 1, 1),
(1, 2, 1),
(2, 3, 1),
(2, 1, 0),
(3, 2, 1);

Select * from User_AuthorizationAction;

end
----------------------------------------------------------------------------------
Begin --- Cache table (uživatel - oprávnìní - akce)

use AuthorizationStudio9;
drop table UserCache;
CREATE TABLE UserCache(
	UserId int,
	AuthorizationId int,
	ActionId int
);

use AuthorizationStudio9;
select uaa.UserId, aa.AuthorizationId, aa.ActionId from User_AuthorizationAction as uaa
inner join Authorization_Action as aa
on uaa.AuthorizationActionId = aa.AuthorizationActionId
union
select ur.UserId,  aa.AuthorizationId, aa.ActionId from User_Role as ur
inner join Role_AuthorizationAction as raa
on ur.RoleId = raa.RoleId
inner join Authorization_Action as aa
on aa.AuthorizationActionId = raa.AuthorizationActionId


select * from UserCache;
end
----------------------------------------------------------------------------------
Begin --- Tests

--- User x Role = all roles for some User
Select u.LastName, r.RoleName from User_Role as ur
inner join [User] as u
on u.UserId = ur.UserId
inner join Role as r
on r.RoleId = ur.RoleId
where u.ActiveUser = 1;

--- Authorization x Action = all actions defined on modules
Select AuthorizationActionId, 
auth.AuthorizationName as [Module Authorized], 
act.ACtionName as [Action Name] 
from Authorization_Action as auth_act
inner join Action as act
on auth_act.ActionId = act.ActionId
inner join [Authorization] as auth
on auth_act.AuthorizationId = auth.AuthorizationId;

--- Roles - (Authorization x Action) = roles with existing actions defined on modules
Select rol_auth_act.RoleAuthorizationActionId, 
rol.RoleName [Role Name], 
--rol_auth_act.AuthorizationActionId, 
--auth_act.ActionId, 
(select ACtionName from Action where auth_act.ActionId = ActionId ) as [Action Name], 
--auth_act.AuthorizationId, 
(select [Authorization].AuthorizationName from [Authorization] where auth_act.AuthorizationId = AuthorizationId ) as [Module],
case 
	when rol_auth_act.IsAllowed = 1 then 'Allowed'
	else 'Not Allowed'
end as Allowed
from Role_AuthorizationAction as rol_auth_act
inner join Role as rol
on rol_auth_act.RoleId = rol.RoleId
inner join Authorization_Action as auth_act
on auth_act.AuthorizationActionId = rol_auth_act.RoleAuthorizationActionId
--where rol_auth_act.IsAllowed = 1;

--- Users - (Authorization x Action) = users with existing actions defined on modules
Select usr_auth_act.UserAuthorizationActionId, 
usr.LastName [User Name], 
(select ACtionName from Action where auth_act.ActionId = ActionId ) as [Action Name], 
(select [Authorization].AuthorizationName from [Authorization] where auth_act.AuthorizationId = AuthorizationId ) as [Module],
case 
	when usr_auth_act.IsAllowed = 1 then 'Allowed'
	else 'Not Allowed'
end as Allowed
from User_AuthorizationAction as usr_auth_act
inner join [User] as usr
on usr_auth_act.UserId = usr.UserId
inner join Authorization_Action as auth_act
on auth_act.AuthorizationActionId = usr_auth_act.UserAuthorizationActionId
--where usr_auth_act.IsAllowed = 1;

end