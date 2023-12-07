# Authorization
.net core Web API pro řešení autorizace dle zadání popsaného v níže. Pro komunikace s SQL serverem a CRUD operace je použito ADO.Net

## Zadání
Navrhněte databázovou strukturu pro správu oprávnění. V systému budou figurovat uživatelé, role, oprávnění, akce.
- Uživatel – vlastnosti: jméno, příjmení, emailová adresa, poznámka, datum registrace a příznak, zda se jedná o aktivního uživatele, výchozí hodnota je ano.
- Role – představuje roli uživatele v systému, například Administrátor. Jeden uživatel může mít více rolí. Vlastnosti role: unikátní kód, název, poznámka.
- Oprávnění – například oprávnění na modul Zákazníci. Vlastnosti: unikátní kód, název, poznámka.
- Akce – specifikuje akci vázanou na oprávnění, akcí může být například editace. Pomocí akcí lze dosáhnout stavu, kdy uživatel může vidět modul Zákazníci, ale už nemůže editovat data. V tuto chvíli uvažujme 4 akce: View, Add, Edit a Delete. Připravte databázi tak, aby mohly v budoucnu vznikat další.
Další pravidla:
- Každé oprávnění může být svázáno s N akcemi, ne všechna oprávnění musí být nutně se všemi.
- Vztah role ke dvojici Oprávnění-Akce může nabývat 3 stavů:
- Role má dvojici Oprávnění-Akce přiřazenu (může tedy například editovat data v modulu Zákazníci).
- Role má dvojici Oprávnění-Akce zakázánu.
- Role nemá dvojici Oprávnění-Akce definovánu.
- Kromě nastavení práv rolí lze úplně stejně nastavit práva samotným uživatelům, přičemž toto nastavení má vyšší prioritu. Příklad: Uživatelé dané role mohou editovat data v modulu Zákazníci, ale jednomu z nich je toto zakázáno. A platí to i naopak, uživatelé dané role nemohou editovat data v modulu Zákazníci (editace zakázána nebo nedefinována), ale jednomu z nich je tato editace povolena.
Očekávány výstup:
- SQL skripty pro vytvoření tabulek.
- SQL skripty pro naplnění testovacími daty včetně zvolených vazeb mezi entitami. Uvažujme 2 role, 3 uživatele a 3 oprávnění (a již zmíněné 4 akce).
- SQL skript pro vytvoření tabulky s „nakešovanými“ dvojicemi { Uživatel, Oprávnění-Akce }. Vysvětlení: Bylo by neefektivní při každém dotazu na práva uživatele zjišťovat tato znovu a znovu ze všech tabulek, mějme tedy jednu pomocnou tabulku obsahující přesně to, co aplikace potřebuje vědět, tedy např. „Má přihlášený uživatel právo mazat data v modulu Zákazníci?“. 
- SQL skripty pro vytvoření triggerů/procedur pro udržování aktuálního stavu této pomocné tabulky.
Aplikace
Vytvořte webovou nebo desktopovou aplikaci, která umožní zobrazit a modifikovat přiřazení práv rolím.
Použité technologie
- MS SQL Server
- Desktopová aplikace: .Net Windows.Forms nebo WPF
- Webová aplikace: Backend .Net Core 3.0 a výš, Frontend libovolný

# SQL složka
SQLQuery2.sql --- soubor obsahuje sql skripty pro vytvoření databáze a potřebných tabulek dle zadání
##
SQLQuery1.sql --- soubor obsahuje skripty pro vytvoření stored procedures které se volají v backendu.
##
AuthorizationStudio9BackUp --- soubor back up databáze

# Řešení
Controller UserCacheController.cs obsahuje výstup pro cache tabulku uživatele { Uživatel, Oprávnění-Akce }. 
