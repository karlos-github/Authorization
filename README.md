# Authorization
------------------------------

# branch main
-------------
##
SQLQuery2.sql --- soubor obsahuje sql skripty pro vytvoření databáze a potřebných tabulek dle zadání
##
SQLQuery1.sql --- soubor obsahuje skripty pro vytvoření stored procedures které se volají v backendu.
##
AuthorizationStudio9BackUp --- soubor back up databáze

# branch master
-------------
backend realizovaný jako .net core web api. Pro CRUD operace používám ADO.net, controller UserCacheController.cs obsahuje výstup pro cache tabulku uživatele { Uživatel, Oprávnění-Akce }. 


