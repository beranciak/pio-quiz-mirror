# Aplikacja konsolowa: Quiz / Ankieta

## Problem

Dostępne narzędzia online do prostych zadań dydaktycznych i ewaluacyjnych bywają zbyt rozbudowane i rozpraszające. W salach komputerowych problemem jest także niestabilny dostęp do internetu, konieczność logowania oraz restrykcyjne polityki IT. Rozproszone wyniki utrudniają ich eksport do ocen i raportów.

## Odbiorcy

- **Prowadzący zajęcia, trenerzy i HR:** chcą szybko przygotować quiz lub ankietę i zebrać wyniki bez logowania, kont i dostępu do sieci.
- **Studenci i uczestnicy szkoleń:** chcą szybko udzielić odpowiedzi i poznać jasny wynik, bez zakładania kont i przeklikiwania reklam.
- **Uczelnie i firmy:** potrzebują prostego narzędzia działającego w salach komputerowych, na słabszych laptopach i w środowiskach z ograniczeniami.

## Wartość produktu

- **Błyskawiczny start:** prowadzący przygotowuje zestaw na miejscu, uruchamia go i zbiera wyniki w kilka minut.
- **Prostota:** brak kont i przeglądarki oraz łatwe przenoszenie aplikacji bez złożonej instalacji.
- **Pełna kontrola nad danymi:** odpowiedzi są początkowo przechowywane w pamięci operacyjnej. Wybór bazy danych do trwałego zapisu będzie późniejszą decyzją projektową. Wyniki będzie można łatwo wyeksportować do arkusza kalkulacyjnego, na przykład w formacie CSV.
- **Niezawodność:** aplikacja działa w pełni offline, bez dostępu do usług chmurowych.

## Zespół

- Paweł Kościelak
- Jakub Świątek
- Mikołaj Bernaciak
- Karol Staszewski

---

## Jak pracujemy w zespole

### Od zadania do zmiany

Wszystkie zmiany wprowadzamy zgodnie z GitHub Flow: `Issue` → `branch` (gałąź) → `Pull Request (PR)` → `review` → `merge`. Od drugiego warsztatu nie commitujemy bezpośrednio do gałęzi `main`.

### Review

Podczas przeglądu sprawdzamy dokumentację, kod oraz wszystkie pozostałe wprowadzane zmiany. Weryfikujemy zgodność rozwiązania z zasadami kursu i celami zadania `Issue`, a także jednoznaczność i użyteczność ustaleń. Akceptujemy zmianę (`Approve`), gdy jej rezultat został sprawdzony, ewentualne uwagi wyjaśniono i uwzględniono, a praca spełnia założenia Definition of Done (DoD).

### Tablica zadań

Pracę organizujemy na tablicy GitHub Project.

- **To do:** zadanie czeka na rozpoczęcie.
- **In progress:** praca jest w trakcie realizacji, na przykład utworzono branch i trwają prace.
- **In review:** zmiana jest gotowa i czeka na weryfikację przez innego członka zespołu; otwarto PR.
- **Done:** rezultat został sprawdzony (`Approve`), uwagi z review rozpatrzono, PR scalono z gałęzią `main`, powiązane zadanie (`Issue`) zamknięto, a status karty na tablicy GitHub Project zmieniono na Done.

### Komunikacja

- Pytania z fazy *discovery* oraz odpowiedzi prowadzącego (sponsora) publikujemy na głównym kanale przedmiotu w MS Teams.
- Bieżące sprawy organizacyjne, konsultacje, problemy zespołu i blokery, na przykład konflikty scalania, omawiamy na wewnętrznym kanale zespołu w MS Teams.

## Pierwszy przyrost — LAB 2

Przyrost obejmuje rozwiązanie przykładowego quizu z jednym pytaniem, zapis podejść w pamięci podczas działania programu oraz wyświetlenie wyników. Zakres, kryteria akceptacji, model domenowy, diagram sekwencji i strategia testów opisuje [dokumentacja przyrostu LAB 2](docs/lab2/first-increment.md).

Prototyp jest obecnie zbudowany dla .NET 10; wersję dostępną na komputerach uczelnianych należy potwierdzić przed prezentacją.

~~~powershell
dotnet build Quiz.sln
dotnet run --project src/Quiz.App/Quiz.App.csproj
dotnet test Quiz.sln
~~~
