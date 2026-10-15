# Wymagania produktu: Quiz / Ankieta

## Status dokumentu

To wstępny punkt odniesienia dla zespołu, przygotowany na podstawie opisu projektu i materiałów do LAB 1. Założenia podane jako początkowe traktujemy jako bazę projektu. Kontrakt CLI, format CSV i szczegóły funkcji poniżej są propozycjami do omówienia oraz zatwierdzenia przez zespół.

## Cel i problem

Proste quizy i ankiety powinny dać się przygotować i przeprowadzić bez ciężkich narzędzi online, logowania i stabilnego internetu. Wyniki powinny być łatwe do sprawdzenia i wyeksportowania do dalszej pracy, na przykład przy ocenianiu lub tworzeniu raportów.

## Użytkownicy

- **Prowadzący / trener / HR** tworzy lub importuje zestaw, uruchamia go i analizuje odpowiedzi.
- **Uczestnik** odpowiada na pytania bez zakładania konta i otrzymuje jasną informację o zakończeniu.
- **Uczelnia / firma** korzysta z aplikacji offline w środowisku z ograniczeniami technicznymi.

## Uzgodnione założenia początkowe

- Aplikacja konsolowa w C#/.NET.
- Praca offline; aplikacja nie opiera się na usługach chmurowych ani logowaniu.
- Odpowiedzi są początkowo przechowywane w pamięci operacyjnej.
- Trwały zapis danych jest decyzją projektową do podjęcia po analizie wymagań.
- Import i eksport danych odbywają się przez pliki CSV.

## Czynniki wpływające na architekturę

- Aplikacja musi działać offline i na komputerach o ograniczonych możliwościach, dlatego rozwiązanie powinno być proste do uruchomienia i nie wymagać usług zewnętrznych.
- Interfejsem użytkownika jest konsola; przebieg operacji powinien być czytelny i obsługiwany klawiaturą.
- Dane w pamięci oraz import/eksport CSV sugerują oddzielenie logiki quizu i ankiety od sposobu wczytywania i zapisu danych.
- Trwałego sposobu przechowywania jeszcze nie wybrano. Projekt powinien pozostawić miejsce na tę późniejszą decyzję bez udawania, że baza danych jest już ustalona.

Podział na warstwę konsolową, logikę aplikacji i wymienialny mechanizm dostępu do danych może być punktem wyjścia do projektowania, ale wymaga uzasadnienia i akceptacji zespołu.

## Wymagania funkcjonalne — wersja początkowa

1. Prowadzący może przygotować quiz lub ankietę.
2. Prowadzący może wczytać zestaw pytań z pliku CSV.
3. Uczestnik może wypełnić ankietę lub rozwiązać quiz bez konta.
4. Aplikacja przechowuje zebrane odpowiedzi w pamięci operacyjnej.
5. Prowadzący może przeglądać zebrane wyniki i wyeksportować je do CSV.
6. Aplikacja informuje o niepoprawnych danych wejściowych czytelnym komunikatem i pozwala poprawić błąd, o ile to możliwe.

**Do uzgodnienia:** rodzaje pytań, zasady oceniania quizu, szczegółowy widok wyników, identyfikacja uczestników oraz to, czy i kiedy dane są usuwane.

## Przypadki użycia

### UC-1: Przygotowanie zestawu

Prowadzący wybiera quiz albo ankietę, podaje tytuł, dodaje pytania i zapisuje zestaw w bieżącej sesji aplikacji.

### UC-2: Import zestawu z CSV

Prowadzący wskazuje plik. Aplikacja sprawdza, czy zawiera wymagane kolumny i poprawne dane, a następnie informuje o wczytaniu zestawu albo wskazuje błędy.

### UC-3: Udzielenie odpowiedzi

Uczestnik wybiera dostępny zestaw, odpowiada na pytania i kończy wypełnianie. Nie musi tworzyć konta ani łączyć się z internetem.

### UC-4: Przegląd i eksport wyników

Prowadzący przegląda odpowiedzi z bieżącej sesji i eksportuje je do pliku CSV.

## User Stories i kryteria akceptacji

### US-1: Tworzenie zestawu

**Jako prowadzący chcę utworzyć quiz lub ankietę, aby zebrać odpowiedzi na zajęciach albo szkoleniu.**

- Mogę nadać zestawowi tytuł i wybrać jego rodzaj.
- Mogę dodać co najmniej jedno pytanie.
- Aplikacja sprawdza wymagane pola i wyświetla zrozumiałe komunikaty przy błędach.
- Szczegółowe rodzaje pytań i reguły quizu zostaną ustalone osobno.

### US-2: Import pytań

**Jako prowadzący chcę wczytać zestaw z CSV, aby szybciej przygotować quiz lub ankietę.**

- Aplikacja akceptuje plik zgodny z uzgodnionym schematem CSV.
- Jeśli plik jest niepoprawny, aplikacja wyjaśnia problem i nie wczytuje niekompletnego zestawu.
- Schemat kolumn, kodowanie i separator zostaną ustalone przed implementacją importu.

### US-3: Udział bez konta i internetu

**Jako uczestnik chcę odpowiedzieć na pytania offline i bez zakładania konta, aby szybko wykonać zadanie.**

- Pytania i dostępne odpowiedzi są prezentowane w czytelnej kolejności.
- Aplikacja waliduje odpowiedzi zgodnie z ustalonymi regułami.
- Po zakończeniu aplikacja potwierdza przyjęcie odpowiedzi; sposób prezentacji wyniku quizu zostanie doprecyzowany.

### US-4: Eksport odpowiedzi

**Jako prowadzący chcę wyeksportować zebrane odpowiedzi do CSV, aby użyć ich w arkuszu kalkulacyjnym lub raporcie.**

- Eksport zawiera nagłówki i dane w uzgodnionym schemacie.
- Pola zawierające separator, cudzysłów lub nową linię są zapisywane zgodnie z regułami CSV.
- Aplikacja informuje o powodzeniu albo wyjaśnia błąd zapisu.
- Zakres danych w eksporcie i format pliku wymagają potwierdzenia przez zespół.

## Propozycja kontraktu CLI

Poniższy szkic jest propozycją do zatwierdzenia, a nie deklaracją gotowej implementacji.

### Uruchomienie

W środowisku developerskim: `dotnet run`. Aplikacja otwiera menu tekstowe i prowadzi użytkownika krok po kroku.

### Proponowane menu główne

1. Utwórz quiz lub ankietę.
2. Importuj zestaw z CSV.
3. Rozwiąż quiz lub wypełnij ankietę.
4. Przeglądaj i eksportuj wyniki.
0. Zakończ.

### Zachowanie interfejsu

- Użytkownik może poruszać się po opcjach za pomocą klawiatury.
- Nieznana opcja powoduje krótki komunikat i ponowne wyświetlenie menu.
- Błąd walidacji wyjaśnia, co należy poprawić; aplikacja nie kończy pracy bez potrzeby.
- Operacja zakończona sukcesem kończy się czytelnym potwierdzeniem.
- Dokładne pola formularzy, sposób powrotu do menu oraz formaty pytań zostaną ustalone podczas analizy i projektowania.

## Ryzyka i otwarte decyzje

| Temat | Ryzyko / pytanie | Następny krok |
| --- | --- | --- |
| Dane w pamięci | Odpowiedzi z bieżącej sesji mogą nie być dostępne po zakończeniu programu. | Ustalić oczekiwany czas przechowywania i moment eksportu. |
| Format CSV | Różne separatory, kodowanie i nagłówki mogą utrudnić wymianę danych. | Zdefiniować schemat importu i eksportu oraz przykładowe pliki. |
| Quiz i ankieta | Quiz wymaga zasad punktacji, ankieta — sposobu podsumowania. | Ustalić typy pytań i różnice w wynikach. |
| Uczestnicy | Nie wiadomo, czy odpowiedzi mają być anonimowe, czy przypisane do osoby. | Rozstrzygnąć wymagania dotyczące identyfikacji i prywatności. |
| Środowisko offline | Dostępna wersja .NET i sposób uruchomienia mogą różnić się między komputerami. | Ustalić docelowe środowisko i instrukcję uruchomienia. |

## Kryteria produktu do weryfikacji

- Aplikację można uruchomić i używać bez dostępu do internetu.
- Uczestnik może odpowiedzieć bez konta.
- Prowadzący może przygotować zestaw lub wczytać go z CSV.
- Odpowiedzi z bieżącej sesji można przejrzeć i wyeksportować do CSV.
- Błędne dane wejściowe prowadzą do zrozumiałej informacji, a nie do nieoczekiwanego zakończenia programu.
