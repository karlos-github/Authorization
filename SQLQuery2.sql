--- User table (uživatel)
---------------
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

Select * from [User];

Insert into [User] (FirstName, LastName, EmailAddress, Note)
values ('Karel', 'Škrabal', 'biglebowskij@seznam.cz', 'some note');

Insert into [User] (FirstName, LastName, EmailAddress, Note)
values ('Karlos', 'Škrabalos', 'biglebowskij@emil.cz', 'some note about Karlos');

Insert into [User] (FirstName, LastName, EmailAddress, Note)
values ('Kadlik', 'Škrabalik', 'biglebowskij@gmail.cz', 'some note about Kadlik');

update [User]
set ActiveUser = 0
where UserId = 1;

--------------------------------------------------------------------------------------------

--- Role table (role)
--------------
use AuthorizationStudio9;

drop table [Role];

CREATE TABLE [Role] (
    RoleId int primary key identity(1,1),
    RoleName varchar(255),
    Note varchar(255),
);

Select * from [Role];

Insert into [Role] (RoleName, Note)
values ('Admin', 'Admin role note');

Insert into [Role] (RoleName, Note)
values ('User', 'User role note');


--------------------------------------------------------------------------------------------

--- Authorization table (oprávnìní)
------------------------
use AuthorizationStudio9;

drop table [Authorization];

CREATE TABLE [Authorization](
    AuthorizationId int primary key identity(1,1),
    AuthorizationName varchar(255),
    Note varchar(255),
);

Select * from [Authorization];

Insert into [Authorization] (AuthorizationName, Note)
values ('Customers', 'Customers module authorization note');

Insert into [Authorization](AuthorizationName, Note)
values ('Invoices', 'Invoice module authorization note');

Insert into [Authorization](AuthorizationName, Note)
values ('Orders', 'Orders module authorization note');

update [Authorization]
set AuthorizationName = 'Customers'
where AuthorizationId = 1;

--------------------------------------------------------------------------------------------

--- Action table (akce)
------------------------
use AuthorizationStudio9;

drop table Action;

CREATE TABLE Action (
    ActionId int primary key identity(1,1),
    ACtionName varchar(255),
    Note varchar(255)
);

Select * from Action;

Insert into Action (ACtionName, Note)
values ('View', 'Action View note');

Insert into Action (ACtionName, Note)
values ('Edit', 'Action Edit note');

Insert into Action (ACtionName, Note)
values ('Add', 'Action Add note');

Insert into Action (ACtionName, Note)
values ('Delete', 'Action Delete note');

----------------------------------------------------------------------------------

--- AuthorizationAction table (oprávnìní - akce)
-------------------------------------------------
/*
Oprávnìní = modul zákazníci x Akce = edit
*/
use AuthorizationStudio9;

drop table Authorization_Action;

CREATE TABLE Authorization_Action (
	AuthorizationActionId int primary key identity(1,1),
	AuthorizationId int,
    ActionId int ,
	--CONSTRAINT Authorization_Action_pk PRIMARY KEY (AuthorizationId, ActionId),
	constraint FK_Authorization foreign key (AuthorizationId) references Authorizations (AuthorizationId),
	constraint FK_Action foreign key (ActionId) references Action (ActionId),
);

Select * from Authorization_Action;

Insert into Authorization_Action (AuthorizationId, ActionId)
values (1, 1);
Insert into Authorization_Action (AuthorizationId, ActionId)
values (1, 2);
Insert into Authorization_Action (AuthorizationId, ActionId)
values (1, 3);
Insert into Authorization_Action (AuthorizationId, ActionId)
values (1, 4);
Insert into Authorization_Action (AuthorizationId, ActionId)
values (2, 1);
Insert into Authorization_Action (AuthorizationId, ActionId)
values (2, 2);

----------------------------------------------------------------------------------

--- Role_AuthorizationAction table (role - (oprávnìní - akce))
---------------------------------------------------------------
/*
Role = Administrátor x (modul zákazníci x edit)
*/
use AuthorizationStudio9;

drop table Role_AuthorizationAction;

CREATE TABLE Role_AuthorizationAction (
	RoleId int,
    AuthorizationActionId int,
	IsAllowed bit,
	CONSTRAINT Role_Authorization_Action_pk PRIMARY KEY (RoleId, AuthorizationActionId),
	constraint  FK_Role foreign key (RoleId) references Role (RoleId),
	constraint FK_AuthorizationAction foreign key (AuthorizationActionId) references Authorization_Action (AuthorizationActionId)
);

Select * from Role_AuthorizationAction;

--Insert into Authorization_Action (AuthorizationId, ActionId)
--values (1, 1);
--Insert into Authorization_Action (AuthorizationId, ActionId)
--values (1, 2);
--Insert into Authorization_Action (AuthorizationId, ActionId)
--values (1, 3);
--Insert into Authorization_Action (AuthorizationId, ActionId)
--values (1, 4);
--Insert into Authorization_Action (AuthorizationId, ActionId)
--values (2, 1);
--Insert into Authorization_Action (AuthorizationId, ActionId)
--values (2, 2);

----------------------------------------------------------------------------------


