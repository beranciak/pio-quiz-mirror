# Kontrakt interfejsu konsolowego

Kontrakt opisuje, w jaki sposób użytkownik rozmawia z programem: co wpisze, co zobaczy i co się stanie, gdy popełni błąd. Nie opisuje kodu. Przyjmujemy interfejs tekstowy (TUI): menu z numerowanymi opcjami i dialog tekstowy.

Kontrakt jest spójny z przypadkami użycia ([use-cases.md](use-cases.md)) i wymaganiami ([requirements.md](requirements.md)). Formaty plików CSV są **propozycją zespołu do potwierdzenia** (patrz [architecture-drivers.md](architecture-drivers.md)).

## Zasady ogólne

- Program prowadzi użytkownika krok po kroku w języku polskim, prostymi zdaniami.
- Błędne dane wejściowe nie kończą programu: komunikat mówi, **co się stało i co zrobić dalej**, a program ponawia pytanie lub wraca do menu. Nie pokazujemy nazw wyjątków.
- Wpisanie `0` w pytaniu o ścieżkę lub wybór oznacza rezygnację i powrót do menu głównego.
- Ścieżki mogą być względne lub bezwzględne.
- Nieznana opcja menu powoduje komunikat „Nieznana opcja. Wybierz numer od 0 do 7.” i ponowne wyświetlenie menu.

## Menu główne

```
Program: === Quiz / Ankieta ===
Program: 1. Utwórz zestaw
Program: 2. Opublikuj zestaw
Program: 3. Wczytaj zestaw z pliku CSV
Program: 4. Rozwiąż quiz / wypełnij ankietę
Program: 5. Wczytaj odpowiedzi uczestników
Program: 6. Pokaż wyniki
Program: 7. Eksportuj wyniki do CSV
Program: 0. Zakończ
Program: Wybierz opcję:
```

Szczegółowo opisujemy pierwszy fragment operacji 1 oraz operacje
4, 5, 7 i 0. Operacje 2, 3 i 6 oraz dalsza część operacji 1
będą rozwijane w kolejnych iteracjach.

## Operacja 1: Utwórz zestaw — pierwszy przyrost

**Powiązanie:** UC1 „Przygotuj i opublikuj zestaw”, kroki 1–3
oraz alternatywa zachowania niedokończonego zestawu; fragment US1.

**Status:** propozycja doprecyzowania dialogu do uzgodnienia przez zespół.

**Zakres:** wybór rodzaju, podanie tytułu i zachowanie pustego,
nieopublikowanego zestawu w pamięci programu.

Pierwszy przyrost nie obejmuje dodawania pytań ani publikacji.
Po przygotowaniu pustego zestawu następuje pytanie o jego zachowanie
przed powrotem do menu. Dalsze kroki UC1 będą dodane później.

### Dialog poprawny

```text
Użytkownik: 1
Program: Wybierz rodzaj: 1 — quiz, 2 — ankieta, 0 — powrót:
Użytkownik: 1
Program: Podaj tytuł lub 0, aby wrócić:
Użytkownik: Stolice
Program: Czy zachować niedokończony zestaw? (t/n):
Użytkownik: t
Program: Zachowano roboczy zestaw w pamięci. Zawiera 0 pytań.
Program: [ponownie wyświetla menu główne]
```

**Wynik:** jeden zestaw rodzaju quiz, z tytułem „Stolice”,
w stanie roboczym (nieopublikowanym), bez pytań.

Dane pozostają dostępne tylko do zamknięcia programu.
Ta operacja nie tworzy pliku ani rekordu w bazie danych.

### Błędny rodzaj

Wpis inny niż `1`, `2` albo `0` powoduje komunikat:

```text
Program: Wybierz 1, 2 albo 0.
```

Program ponawia pytanie o rodzaj. Nie tworzy zestawu.

### Pusty tytuł

Pusty wpis albo same białe znaki powodują komunikat:

```text
Program: Tytuł jest wymagany. Podaj tytuł zestawu.
```

Program ponawia pytanie o tytuł i zachowuje wcześniej wybrany rodzaj.

### Rezygnacja i zachowanie zestawu

- `0` przy wyborze rodzaju lub wpisywaniu tytułu oznacza powrót
  do menu bez utworzenia zestawu.
- Po podaniu poprawnego rodzaju i tytułu program przygotowuje
  pusty zestaw i pyta, czy zachować go przed powrotem do menu.
- Odpowiedź `t` dodaje zestaw do pamięci programu.
- Odpowiedź `n` odrzuca zestaw i wyświetla:
  „Anulowano tworzenie zestawu.”
- Inna odpowiedź powoduje komunikat „Wpisz t (tak) lub n (nie).”
  i ponowienie pytania.

**Założenia do uzgodnienia:** tytuł równy dokładnie `0` jest
zarezerwowany dla rezygnacji. Przed otrzymaniem poprawnego rodzaju
i tytułu nie ma jeszcze zestawu, który można zachować.

## Operacja 2: Opublikuj zestaw — dalsza część UC1

Publikacja jest osobną operacją od utworzenia roboczego zestawu.

Prowadzący wskazuje przygotowany zestaw oraz ścieżkę zapisu.
Program sprawdza kompletność i zapisuje plik zestawu dla uczestników.

Sukces oznacza utworzenie pliku i oznaczenie zestawu jako
opublikowanego oraz niezmiennego.
Jeżeli zapis się nie powiedzie, zestaw pozostaje nieopublikowany,
a program wyjaśnia problem i ponawia pytanie o ścieżkę.

Pusty zestaw nie może zostać opublikowany.
Szczegółowy dialog publikacji zostanie rozwinięty osobno.

## Operacja 3: Wczytaj zestaw z pliku CSV

**Powiązanie:** UC5 „Wczytaj zestaw z pliku”.

1. Użytkownik wybiera opcję 3.
2. Program prosi o ścieżkę do pliku CSV.
3. Użytkownik podaje ścieżkę albo wpisuje `0`, aby wrócić do menu.
4. Program wczytuje i sprawdza plik.
5. Po poprawnym wczytaniu dodaje zestaw do pamięci i podaje
   jego tytuł, rodzaj oraz liczbę pytań.

Brak pliku lub niepoprawny format powoduje komunikat błędu
i ponowienie pytania o ścieżkę. Ten sam zestaw nie jest dodawany
ponownie, zgodnie z UC5.

Odtworzenie klucza poprawnych odpowiedzi prowadzącego pozostaje
otwartym pytaniem opisanym w UC5.

## Formaty plików CSV (propozycja)

Wszystkie pliki: kodowanie UTF-8, separator pól `;`, pierwszy wiersz to nagłówek. Listy wartości w jednym polu oddzielamy znakiem `|`.

| Plik | Rola | Kolumny |
| --- | --- | --- |
| Zestaw dla uczestników | Wyjście operacji 2, wejście operacji 4 | `id_zestawu;wersja;rodzaj;tytul;nr_pytania;tresc;wybor;opcje` |
| Odpowiedzi uczestnika | Wyjście operacji 4, wejście operacji 5 | `id_zestawu;wersja;id_uczestnika;nr_pytania;wybrane` |
| Wyniki quizu | Wyjście operacji 7 | `id_uczestnika;punkty;maks_punkty;procent` |
| Wyniki ankiety | Wyjście operacji 7 | `nr_pytania;opcja;liczba_wyborow` |

Znaczenie pól: `rodzaj` to `quiz` lub `ankieta`; `wybor` to `jednokrotny` lub `wielokrotny`; `opcje` to lista tekstów opcji; `wybrane` to numery wybranych opcji (np. `1|3`). Plik zestawu dla uczestników nie zawiera poprawnych odpowiedzi.

## Operacja 4: Rozwiąż quiz / wypełnij ankietę

**Powiązanie:** UC2, US2 (AC1–AC5).

**Wejście użytkownika:** ścieżka do pliku zestawu, identyfikator uczestnika, numer lub numery opcji dla każdego pytania, ścieżka zapisu pliku odpowiedzi.

**Pliki:** czyta plik zestawu dla uczestników, zapisuje plik odpowiedzi uczestnika (formaty w tabeli powyżej).

### Dialog poprawny (AC1)

```
Program: Podaj ścieżkę do pliku zestawu (CSV) lub 0, aby wrócić do menu:
Użytkownik: dane/podstawy-csharp.csv
Program: Wczytano zestaw „Podstawy C#” (quiz, 3 pytania).
Program: Podaj swój identyfikator uczestnika:
Użytkownik: s12345
Program: Pytanie 1/3: Który typ przechowuje liczby całkowite?
Program: 1. int
Program: 2. string
Program: 3. bool
Program: Twoja odpowiedź (numer opcji):
Użytkownik: 1
Program: Pytanie 2/3: Które z poniższych są pętlami? (wybierz wszystkie poprawne, numery po przecinku)
Program: 1. for
Program: 2. if
Program: 3. while
Program: Twoja odpowiedź:
Użytkownik: 1,3
Program: Pytanie 3/3: Który zapis deklaruje zmienną tekstową?
Program: 1. int x = 5;
Program: 2. string s = "abc";
Program: 3. bool b = true;
Program: Twoja odpowiedź (numer opcji):
Użytkownik: 2
Program: To były wszystkie pytania. Podaj ścieżkę zapisu pliku odpowiedzi:
Użytkownik: odpowiedzi/s12345.csv
Program: Zapisano odpowiedzi w pliku odpowiedzi/s12345.csv. Przekaż ten plik prowadzącemu.
Program: [ponownie wyświetla menu główne]
```

**Wynik poprawny:** plik odpowiedzi zawiera po jednym wierszu na pytanie, np. `csharp-01;1;s12345;2;1|3` (zestaw `csharp-01`, wersja 1, uczestnik `s12345`, pytanie 2, wybrane opcje 1 i 3).

### Dialog błędny: brak pliku zestawu (AC2)

```
Program: Podaj ścieżkę do pliku zestawu (CSV) lub 0, aby wrócić do menu:
Użytkownik: dane/brak.csv
Program: Nie znaleziono pliku. Sprawdź ścieżkę i podaj ją ponownie albo wpisz 0, aby wrócić do menu:
```

**Dalsze zachowanie:** program ponawia pytanie o ścieżkę; stan odpowiedzi się nie zmienia.

### Dialog błędny: wpis spoza zakresu (AC3)

```
Program: Pytanie 1/3: Który typ przechowuje liczby całkowite?
Program: 1. int
Program: 2. string
Program: 3. bool
Program: Twoja odpowiedź (numer opcji):
Użytkownik: 7
Program: Nie ma opcji 7. Wybierz numer od 1 do 3.
Program: Twoja odpowiedź (numer opcji):
```

**Dalsze zachowanie:** program ponawia to samo pytanie; błędny wpis nie jest zapisywany. Wpis, który nie jest liczbą (np. „abc”), daje komunikat „Podaj numer opcji, np. 2.” i to samo zachowanie. Dla pytań wielokrotnego wyboru powtórzenie numeru (np. „1,1”) daje komunikat „Numer 1 podano dwa razy. Podaj każdy numer tylko raz.” (AC4, do potwierdzenia).

### Dialog błędny: zapis pliku się nie udał (AC5)

```
Program: To były wszystkie pytania. Podaj ścieżkę zapisu pliku odpowiedzi:
Użytkownik: Z:/brak-dostepu/s12345.csv
Program: Nie udało się zapisać pliku. Sprawdź, czy folder istnieje i czy masz do niego dostęp. Twoje odpowiedzi nadal są w programie.
Program: Podaj inną ścieżkę zapisu:
```

**Dalsze zachowanie:** program zachowuje odpowiedzi w pamięci i ponawia pytanie o ścieżkę zapisu. Użytkownik może wpisać `0` i wtedy program prosi o potwierdzenie wyjścia bez zapisu (odpowiedzi zostaną utracone); to rozwiązanie jest założeniem do potwierdzenia.

## Operacja 5: Wczytaj odpowiedzi uczestników

**Powiązanie:** UC3, US3 (AC1–AC5).

**Wejście użytkownika:** numer zestawu z listy, ścieżka do folderu z plikami odpowiedzi.

**Pliki:** czyta wszystkie pliki CSV z folderu (format „Odpowiedzi uczestnika”).

### Dialog poprawny (AC1)

```
Program: Wybierz zestaw (numer) lub 0, aby wrócić do menu:
Program: 1. Podstawy C# (quiz, wersja 1)
Użytkownik: 1
Program: Podaj ścieżkę do folderu z plikami odpowiedzi:
Użytkownik: zebrane/
Program: Wczytano 3 pliki odpowiedzi (uczestnicy: s12345, s12346, s12347).
Program: [ponownie wyświetla menu główne]
```

### Dialog błędny: część plików pominięta (AC2, AC3, AC5)

```
Program: Wczytano 2 pliki odpowiedzi (uczestnicy: s12345, s12346). Pominięto 3 pliki:
Program: - s12348.csv: brak wymaganej kolumny „nr_pytania”.
Program: - s12349.csv: dotyczy innego zestawu lub wersji (oczekiwano zestawu „Podstawy C#”, wersja 1).
Program: - s12345-kopia.csv: uczestnik s12345 został już wczytany, duplikat pominięto.
Program: Popraw pliki i wczytaj je ponownie. Wczytane dane zostały zachowane.
Program: [ponownie wyświetla menu główne]
```

**Dalsze zachowanie:** program wczytuje poprawne pliki, a każdy pominięty wymienia z powodem; wraca do menu głównego (import częściowy i obsługa duplikatu są założeniami do potwierdzenia).

### Dialog błędny: folder nie istnieje albo jest pusty (AC4)

```
Program: Podaj ścieżkę do folderu z plikami odpowiedzi:
Użytkownik: zebrane-brak/
Program: Nie znaleziono folderu lub nie ma w nim plików CSV. Sprawdź ścieżkę i podaj ją ponownie albo wpisz 0, aby wrócić do menu:
```

**Dalsze zachowanie:** program ponawia pytanie o ścieżkę. Gdy w programie nie ma żadnego zestawu, program informuje: „Nie ma żadnego zestawu. Najpierw utwórz zestaw (opcja 1) lub wczytaj go z pliku (opcja 3).” i wraca do menu.

## Operacja 7: Eksportuj wyniki do CSV

**Powiązanie:** UC4, US5 (AC1–AC4).

**Wejście użytkownika:** numer zestawu z listy, ścieżka zapisu pliku wyników.

**Pliki:** zapisuje plik wyników (quizu lub ankiety, zależnie od rodzaju zestawu).

### Dialog poprawny (AC1)

```
Program: Wybierz zestaw (numer) lub 0, aby wrócić do menu:
Program: 1. Podstawy C# (quiz, wersja 1)
Użytkownik: 1
Program: Podaj ścieżkę zapisu pliku wyników:
Użytkownik: wyniki/podstawy-csharp.csv
Program: Zapisano wyniki 3 uczestników w pliku wyniki/podstawy-csharp.csv.
Program: [ponownie wyświetla menu główne]
```

**Wynik poprawny:** plik z nagłówkiem `id_uczestnika;punkty;maks_punkty;procent` i jednym wierszem na uczestnika, który otwiera się w Excelu z podziałem na kolumny (AC2, do potwierdzenia testem).

### Dialog błędny: brak wczytanych odpowiedzi

```
Program: Dla zestawu „Podstawy C#” nie wczytano jeszcze odpowiedzi. Wczytaj je (opcja 5) i spróbuj ponownie.
Program: [ponownie wyświetla menu główne]
```

**Dalsze zachowanie:** program wraca do menu głównego bez zapisywania pliku.

### Dialog błędny: zapis pliku się nie udał (AC4)

```
Program: Podaj ścieżkę zapisu pliku wyników:
Użytkownik: wyniki/podstawy-csharp.csv
Program: Nie udało się zapisać pliku. Jeśli jest otwarty w innym programie (np. w Excelu), zamknij go. Sprawdź też, czy folder istnieje.
Program: Podaj ścieżkę ponownie albo wpisz 0, aby wrócić do menu:
```

**Dalsze zachowanie:** program nie przerywa pracy, a wyniki pozostają w pamięci do czasu skutecznego zapisu.

## Operacja 0: Zakończ

**Powiązanie:** ryzyko R2 ([risks.md](risks.md)).

**Wejście użytkownika:** wybór opcji 0; odpowiedź `t` lub `n` na pytanie o potwierdzenie.

### Dialog poprawny: brak niezapisanych danych

```
Użytkownik: 0
Program: Do widzenia.
```

### Dialog z ostrzeżeniem: są niewyeksportowane dane

```
Użytkownik: 0
Program: W programie są dane, które nie zostały wyeksportowane. Po zamknięciu programu zostaną utracone. Czy na pewno zakończyć? (t/n):
Użytkownik: n
Program: [wraca do menu głównego]
```

**Dalsze zachowanie:** odpowiedź `t` kończy program; `n` wraca do menu. Inny wpis powoduje komunikat „Wpisz t (tak) lub n (nie).” i ponowienie pytania.
