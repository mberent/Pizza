# Pizza

Projekt zaliczeniowy z przedmiotu "Wielowarstwowe aplikacje internetowe".

Wymagania projektowe:
http://www.cs.put.poznan.pl/mwojciechowski/

> .NET - Projekt
> 
> Opis projektu
> 
> Celem projektu jest implementacja fragmentu systemu dla pizzerii. W ramach projektu powinna zostać zaimplementowana funkcjonalność zarządzania ofertą dostępnych pizz (menu wiążące nazwy pizz z dodatkami oraz utrzymywanie katalogu dostępnych dodatków).
> Szczegółowe wymagania funkcjonalne:
> 
> * Pizza jest opisana nazwą, ceną (w wariantach: mała, średnia, duża), rodzajem ciasta (cienkie/grube) i zbiorem/listą dodatków (ser i sos te same dla wszystkich pizz w menu)
> * Ten sam dodatek może występować na wielu rodzajach pizz, pizza może mieć dowolną liczbę dodatków (w tym zero)
> * Aplikacja musi umożliwiać:
> * Dodawanie nowej pizzy do menu
> * Usuwanie pizzy z menu
> * Wyświetlenie listy wszystkich dostępnych w menu pizz
> * Wyszukiwanie pizz wg początku nazwy (np. poprzez formularz nad listą pizz)
> * Podgląd szczegółowych informacji o wybranej pizzy
> * Utrzymywanie listy dostępnych składników tj. dodawanie, usuwanie i zmianę nazwy składnika. (Usunięcie składnika powinno być możliwe tylko wtedy gdy nie jest on użyty na żadnej pizzy.)
> * Na zakończenie procesu usuwania pizzy powinna być prezentowana użytkownikowi strona z prośbą o potwierdzenie swojej decyzji z możliwością wycofania się z niej
> * Wszystkie pola formularzy do dodawania i edycji powinny być obowiązkowe
> * Wymagania w zakresie wykorzystywanych w projekcie technologii
> 
> * Framework dla warstwy prezentacji: ASP.NET MVC (wersja dostępna w laboratorium lub ewentualnie nowsza jeśli prezentacja na własnym komputerze)
> * Obsługa trwałości danych (komunikacja z b.d.): ADO.NET Entity Framework (Code First)
> * Serwer bazy danych: Microsoft SQL Server (LocalDB lub Express)
