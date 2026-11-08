# Wymagania: User Stories i kryteria akceptacji

User Stories opisują potrzeby użytkowników i ich wartość. Kryteria akceptacji (AC) to sprawdzalne warunki spełnienia każdej potrzeby: dane wejściowe i oczekiwany wynik. Przebieg działań opisują przypadki użycia w [use-cases.md](use-cases.md), a dialogi w [contract.md](contract.md).

**Oznaczenia:** AC oznaczone „(do potwierdzenia)” zależą od założenia lub pytania otwartego (szczegóły w [architecture-drivers.md](architecture-drivers.md)). Przykładowe dane w AC są ilustracją; schematy CSV są propozycją zespołu.

## US1: Tworzenie i publikacja zestawu

**Powiązanie:** UC1.

Jako prowadzący chcę utworzyć i opublikować quiz lub ankietę, aby przekazać uczestnikom niezmienną wersję do rozwiązania.

### Kryteria akceptacji

- **AC1:** Dla quizu „Podstawy C#” z jednym pytaniem jednokrotnego wyboru (opcje: int, string, bool; poprawna: int) po wybraniu publikacji i podaniu poprawnej ścieżki program potwierdza publikację i podaje ścieżkę zapisanego pliku zestawu.
- **AC2:** Dla pustego tytułu program informuje, że tytuł jest wymagany, i ponownie pyta o tytuł.
- **AC3:** Dla pytania z jedną opcją odpowiedzi program informuje, że potrzebne są co najmniej dwie opcje, i nie dodaje pytania.
- **AC4:** Dla pytania quizu bez wskazanej poprawnej opcji program nie dodaje pytania i wyjaśnia, że quiz wymaga poprawnej odpowiedzi. Dla ankiety to samo pytanie jest akceptowane bez wskazania poprawnej opcji.
- **AC5:** Dla zestawu bez pytań program odmawia publikacji z komunikatem, a zestaw pozostaje nieopublikowany.
- **AC6 (do potwierdzenia):** Po publikacji próba zmiany zestawu jest odrzucona z komunikatem, że opublikowana wersja jest niezmienna.
- **AC7:** Gdy treść pytania lub opcja odpowiedzi składa się tylko z białych znaków, program zgłasza błąd i prosi o ponowne wprowadzenie.
- **AC8:** Treść pytania nie może przekraczać 500 znaków. Po przekroczeniu program informuje o błędzie limitu znaków.

## US2: Rozwiązanie quizu lub ankiety bez konta i internetu

**Powiązanie:** UC2.

Jako uczestnik chcę rozwiązać quiz lub wypełnić ankietę na swoim komputerze, bez konta i internetu, aby szybko przekazać swoje odpowiedzi prowadzącemu.

### Kryteria akceptacji

- **AC1:** Dla poprawnego pliku zestawu z 3 pytaniami program wyświetla pytania kolejno z numeracją „1/3”, „2/3”, „3/3”, a po ostatnim zapisuje plik odpowiedzi pod podaną ścieżką i potwierdza zapis.
- **AC2:** Dla nieistniejącej ścieżki do pliku zestawu program informuje o braku pliku i ponownie pyta o ścieżkę.
- **AC3:** Dla pytania jednokrotnego wyboru z opcjami 1–3 wpis „7” powoduje komunikat o dozwolonym zakresie (1–3) i ponowienie tego samego pytania; błędny wpis nie jest zapisywany.
- **AC4 (do potwierdzenia):** Dla pytania wielokrotnego wyboru wpis „1,3” zapisuje obie opcje, a wpis „1,1” jest odrzucony z komunikatem o powtórzeniu, po czym program prosi o ponowne podanie odpowiedzi dla tego pytania.
- **AC5:** Gdy zapis pliku odpowiedzi nie jest możliwy, program wyjaśnia problem, zachowuje odpowiedzi z bieżącego podejścia i pozwala podać inną ścieżkę.
- **AC6:** W każdym pytaniu wpisanie komendy „q” powoduje przerwanie rozwiązywania quizu/ankiety i niezapisanie dotychczasowych odpowiedzi w pliku wyjściowym.

## US3: Wczytanie zebranych odpowiedzi

**Powiązanie:** UC3.

Jako prowadzący chcę wczytać pliki odpowiedzi uczestników z jednego folderu, aby mieć wszystkie odpowiedzi do zestawu w jednym miejscu.

### Kryteria akceptacji

- **AC1:** Dla folderu z 3 poprawnymi plikami odpowiedzi do wybranego zestawu program informuje, że wczytano 3 pliki i 3 uczestników.
- **AC2 (do potwierdzenia):** Dla folderu z 2 poprawnymi plikami i 1 nieprawidłowym (np. uszkodzonym, pustym lub bez odpowiednich kolumn) program wczytuje 2 pliki, a w podsumowaniu wymienia nazwę pominiętego pliku i powód.
- **AC3:** Dla pliku odpowiedzi dotyczącego innego zestawu lub innej wersji program pomija go i informuje o niezgodności.
- **AC4:** Dla nieistniejącego folderu lub folderu bez plików CSV program informuje o problemie i ponownie pyta o ścieżkę.
- **AC5 (do potwierdzenia):** Gdy ten sam identyfikator uczestnika (zapisany w pierwszej linii pliku CSV) występuje w dwóch plikach, program zgłasza duplikat i nie liczy go podwójnie.

## US4: Przegląd wyników i podstawowych statystyk

**Powiązanie:** UC4.

Jako prowadzący chcę zobaczyć wyniki i podstawowe statystyki zestawu, aby szybko ocenić, jak grupa poradziła sobie z quizem albo co odpowiedziała w ankiecie.

### Kryteria akceptacji

- **AC1:** Dla quizu z 2 pytaniami i 3 wczytanymi uczestnikami, gdzie na pytanie 1 poprawnie odpowiedziało 2 z 3 osób, a na pytanie 2 wszystkie 3 osoby, program wyświetla: pytanie 1: 2/3 (67%), pytanie 2: 3/3 (100%).
- **AC2:** Dla ankiety program wyświetla przy każdym pytaniu liczbę wyborów każdej opcji i nie ocenia ich poprawności.
- **AC3:** Dla zestawu bez wczytanych odpowiedzi program informuje o braku danych i wraca do menu.
- **AC4:** Dla ankiety, oprócz liczby wyborów (np. Opcja A: 12), program wyświetla także procentowy udział każdej opcji (np. Opcja A: 60%).

## US5: Eksport wyników do CSV

**Powiązanie:** UC4.

Jako prowadzący chcę wyeksportować wyniki do pliku CSV, aby otworzyć je w Excelu i wykorzystać do oceny lub raportu.

### Kryteria akceptacji

- **AC1 (do potwierdzenia):** Dla quizu z 3 wczytanymi uczestnikami po podaniu poprawnej ścieżki program zapisuje plik z wierszem nagłówkowym (np. ID Uczestnika, Wynik całkowity, P1, P2, P3...) i jednym wierszem na uczestnika oraz potwierdza zapis 3 wierszy.
- **AC2 (do potwierdzenia):** Zapisany plik po otwarciu w Excelu ma podział na kolumny i poprawnie wyświetla polskie znaki.
- **AC3:** Pole zawierające separator, cudzysłów lub znak nowej linii jest zapisane zgodnie z regułami CSV (ujęte w cudzysłów, z podwojonym cudzysłowem wewnątrz).
- **AC4:** Gdy zapis się nie udaje (np. plik jest otwarty w innym programie), program wyjaśnia przyczynę, nie przerywa pracy i prosi o inną ścieżkę.

## Śledzenie powiązań

| Story | Przypadek użycia | Operacja w kontrakcie |
| --- | --- | --- |
| US1 | UC1 | Utwórz zestaw, Opublikuj zestaw (opisane tylko w menu) |
| US2 | UC2 | Operacja 4: Rozwiąż quiz / wypełnij ankietę |
| US3 | UC3 | Operacja 5: Wczytaj odpowiedzi uczestników |
| US4 | UC4 | Pokaż wyniki (opisane tylko w menu) |
| US5 | UC4 | Operacja 7: Eksportuj wyniki do CSV |

Zakres i kryteria działającego prototypu LAB 2 są wyszczególnione w [opisie pierwszego przyrostu](lab2/first-increment.md); jego ograniczeń nie należy traktować jako kompletnej implementacji wszystkich User Stories.
