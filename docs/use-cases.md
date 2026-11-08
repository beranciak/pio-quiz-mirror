# Przypadki użycia

Przypadki użycia (UC) opisują, jak użytkownik osiąga swój cel w aplikacji konsolowej Quiz / Ankieta. Wymagania w formie User Stories i kryteriów akceptacji są w [requirements.md](requirements.md), a dialogi w [contract.md](contract.md).

**Aktorzy:** Prowadzący (tworzy zestawy, zbiera i analizuje odpowiedzi) i Uczestnik (odpowiada na pytania). Obie role korzystają z jednego programu.

**Oznaczenia ustaleń:** [Ustalenie] potwierdzone (źródło: wizja sponsora z LAB 1), [Założenie] przyjęte roboczo, [Pytanie] do sponsora. Pytania zbiorcze są w [architecture-drivers.md](architecture-drivers.md).

## UC1: Przygotuj i opublikuj zestaw

- **Aktor:** Prowadzący.
- **Cel:** Mieć niezmienną wersję quizu lub ankiety, którą można przekazać uczestnikom do rozwiązania.
- **Warunek początkowy:** Program jest uruchomiony i wyświetla menu główne.
- **Przepływ główny:**
  1. Prowadzący wybiera opcję tworzenia zestawu.
  2. Program pyta o rodzaj zestawu (quiz lub ankieta).
  3. Prowadzący podaje tytuł zestawu.
  4. Prowadzący dodaje pytanie: podaje treść, typ (jednokrotnego lub wielokrotnego wyboru) i opcje odpowiedzi; dla quizu wskazuje poprawne opcje.
  5. Program potwierdza dodanie pytania. Prowadzący powtarza krok 4 dla kolejnych pytań i kończy dodawanie.
  6. Prowadzący wybiera opcję publikacji zestawu.
  7. Program pyta o ścieżkę zapisu, a prowadzący ją podaje.
  8. Program sprawdza kompletność zestawu, oznacza go jako opublikowany (niezmienny) i zapisuje plik zestawu dla uczestników w formacie CSV pod podaną ścieżką.
  9. Program potwierdza publikację i podaje ścieżkę pliku.
- **Alternatywy i błędy:**
  - 3a. Tytuł jest pusty: program informuje, że tytuł jest wymagany, i ponawia pytanie o tytuł.
  - 4a. Pytanie ma mniej niż dwie opcje albo pustą treść: program wyjaśnia, co poprawić, i nie dodaje pytania.
  - 4b. W quizie pytanie nie ma wskazanej poprawnej opcji: program nie dodaje pytania i wyjaśnia dlaczego. Ankieta nie wymaga poprawnych opcji.
  - 6a. Zestaw nie zawiera pytań: program odmawia publikacji i wraca do menu; zestaw pozostaje nieopublikowany.
  - 8a. Nie można zapisać pliku (np. brak dostępu do folderu): program wyjaśnia problem, zestaw pozostaje nieopublikowany, a program ponawia pytanie o ścieżkę.
- **Rezultat:** Zestaw jest opublikowany i niezmienny, a prowadzący ma plik do przekazania uczestnikom.
- **Ustalenia i pytania:**
  - [Ustalenie] Publikacja tworzy „zamrożoną” wersję zestawu do rozwiązania. Źródło: wizja.
  - [Założenie] Plik przekazywany uczestnikom nie zawiera poprawnych odpowiedzi; klucz zostaje u prowadzącego.
  - [Pytanie] Czy po publikacji można utworzyć nową wersję zestawu na bazie istniejącego? Czy edytujemy wyłącznie zestawy niepublikowane?
- **Powiązane wymagania:** US1.

## UC2: Rozwiąż quiz lub wypełnij ankietę

- **Aktor:** Uczestnik.
- **Cel:** Odpowiedzieć na pytania zestawu bez konta i internetu i przekazać swoje odpowiedzi prowadzącemu.
- **Warunek początkowy:** Uczestnik ma plik zestawu na swoim komputerze i uruchomił program.
- **Przepływ główny:**
  1. Uczestnik wybiera opcję rozwiązywania zestawu.
  2. Program prosi o ścieżkę do pliku zestawu.
  3. Uczestnik podaje ścieżkę.
  4. Program wczytuje i sprawdza plik, a następnie informuje o tytule, rodzaju zestawu i liczbie pytań.
  5. Program prosi o identyfikator uczestnika, a uczestnik go podaje.
  6. Program wyświetla kolejne pytanie z numerem (np. „Pytanie 2/3”) i opcjami; uczestnik podaje numer wybranej opcji (dla pytań wielokrotnego wyboru: numery oddzielone przecinkami).
  7. Po ostatnim pytaniu program prosi o ścieżkę zapisu pliku odpowiedzi.
  8. Uczestnik podaje ścieżkę, a program zapisuje odpowiedzi w pliku CSV i potwierdza zapis.
- **Alternatywy i błędy:**
  - 3a. Plik nie istnieje albo ma niepoprawny format: program wyjaśnia problem i ponawia pytanie o ścieżkę; uczestnik może wrócić do menu.
  - 6a. Podany numer opcji jest spoza zakresu, nie jest liczbą lub powtarza się: program wyjaśnia, jaki wpis jest dozwolony, i ponawia to samo pytanie bez zapisywania błędnej odpowiedzi.
  - 8a. Nie można zapisać pliku odpowiedzi: program wyjaśnia problem, zachowuje odpowiedzi w pamięci i prosi o inną ścieżkę.
- **Rezultat:** Odpowiedzi uczestnika są zapisane w pliku CSV gotowym do przekazania prowadzącemu.
- **Ustalenia i pytania:**
  - [Ustalenie] Uczestnicy odpowiadają na osobnych komputerach bez internetu, a odpowiedzi eksportują do plików. Źródło: wizja.
  - [Ustalenie] Odpowiedź może zawierać identyfikator uczestnika. Źródło: wizja.
  - [Pytanie] Czy identyfikator jest wymagany, opcjonalny czy zależny od rodzaju zestawu (ankieta anonimowa, quiz z identyfikatorem)?
  - [Pytanie] Czy uczestnik widzi wynik quizu po zakończeniu? Jeśli tak, skąd program zna poprawne odpowiedzi, skoro plik zestawu ich nie zawiera?
  - [Pytanie] Czy każde pytanie jest obowiązkowe, czy uczestnik może je pominąć?
- **Powiązane wymagania:** US2.

## UC3: Wczytaj zebrane odpowiedzi

- **Aktor:** Prowadzący.
- **Cel:** Zebrać w programie odpowiedzi wszystkich uczestników do jednego zestawu.
- **Warunek początkowy:** W programie jest opublikowany lub wczytany zestaw, a prowadzący zebrał pliki odpowiedzi w jednym folderze.
- **Przepływ główny:**
  1. Prowadzący wybiera opcję wczytania odpowiedzi.
  2. Program wyświetla listę zestawów, a prowadzący wybiera jeden.
  3. Program prosi o ścieżkę do folderu z plikami odpowiedzi, a prowadzący ją podaje.
  4. Program wczytuje pliki CSV z folderu i sprawdza każdy z nich (poprawność formatu, zgodność z wybranym zestawem i jego wersją).
  5. Program podaje liczbę wczytanych plików i uczestników oraz wszystkie pominięte pliki wraz z powodem.
- **Alternatywy i błędy:**
  - 2a. W programie nie ma żadnego zestawu: program informuje o tym i wskazuje, że zestaw trzeba najpierw utworzyć lub wczytać z pliku.
  - 3a. Folder nie istnieje albo nie zawiera plików CSV: program wyjaśnia problem i ponawia pytanie o ścieżkę; prowadzący może wrócić do menu.
  - 4a. Plik jest uszkodzony lub ma niepoprawne dane: program pomija ten plik, wczytuje pozostałe i wymienia pominięty plik w podsumowaniu w kroku 5.
  - 4b. Plik dotyczy innego zestawu lub innej wersji: program pomija go i informuje o niezgodności.
  - 4c. Ten sam uczestnik występuje w kilku plikach: program zgłasza duplikat i nie liczy go podwójnie.
- **Rezultat:** Odpowiedzi poprawnych plików są dostępne w programie i mogą zostać użyte do wyników.
- **Ustalenia i pytania:**
  - [Ustalenie] Prowadzący zbiera wyeksportowane pliki i wczytuje je do programu. Źródło: wizja.
  - [Założenie] Błąd w jednym pliku nie blokuje wczytania pozostałych (import częściowy).
  - [Pytanie] Jak postępować z duplikatem: zachować pierwszy plik, ostatni czy pytać prowadzącego?
  - [Pytanie] Czy ponowne wczytanie tego samego folderu zastępuje, czy dopisuje dane?
- **Powiązane wymagania:** US3.

## UC4: Przejrzyj wyniki i wyeksportuj je do CSV

- **Aktor:** Prowadzący.
- **Cel:** Poznać wyniki i podstawowe statystyki oraz przekazać je do arkusza kalkulacyjnego.
- **Warunek początkowy:** W programie są wczytane odpowiedzi dla co najmniej jednego zestawu.
- **Przepływ główny:**
  1. Prowadzący wybiera opcję wyświetlenia wyników i wskazuje zestaw.
  2. Program wyświetla liczbę uczestników i wyniki: dla quizu odsetek poprawnych odpowiedzi na każde pytanie, dla ankiety liczbę wyborów każdej opcji.
  3. Prowadzący wybiera opcję eksportu wyników do CSV i wskazuje zestaw.
  4. Program prosi o ścieżkę zapisu, a prowadzący ją podaje.
  5. Program zapisuje plik CSV z wynikami i potwierdza zapis wraz z liczbą zapisanych uczestników.
- **Alternatywy i błędy:**
  - 1a. Dla zestawu nie wczytano odpowiedzi: program informuje o braku danych i wraca do menu.
  - 5a. Nie można zapisać pliku (np. plik jest otwarty w Excelu lub brak dostępu do folderu): program wyjaśnia problem, nie przerywa pracy i ponawia pytanie o ścieżkę; prowadzący może wrócić do menu.
- **Rezultat:** Prowadzący zna wyniki grupy i ma plik CSV do otwarcia w arkuszu.
- **Ustalenia i pytania:**
  - [Ustalenie] Wyniki i podstawowe statystyki można wyeksportować do pliku CSV nadającego się do Excela. Źródło: wizja.
  - [Pytanie] Czym różnią się wyniki quizu od ankiety i jakie statystyki są potrzebne (punkty, średnia, rozkład)?
  - [Pytanie] Jaki jest zakres eksportu: tylko podsumowanie, czy także odpowiedzi poszczególnych uczestników?
- **Powiązane wymagania:** US4, US5.
## UC5: Wczytaj zestaw z pliku

- **Aktor:** Prowadzący.
- **Cel:** Mieć w programie zapisany wcześniej zestaw pytań, aby móc wczytać do niego odpowiedzi uczestników (np. po ponownym uruchomieniu programu).
- **Warunek początkowy:** Program jest uruchomiony i wyświetla menu główne, a prowadzący ma plik zestawu zapisany na komputerze.
- **Przepływ główny:**
  1. Prowadzący wybiera opcję wczytania zestawu z pliku.
  2. Program prosi o ścieżkę do pliku zestawu, a prowadzący ją podaje.
  3. Program wczytuje i sprawdza plik.
  4. Program informuje o tytule, rodzaju zestawu i liczbie pytań oraz dodaje zestaw do listy zestawów w programie.
- **Alternatywy i błędy:**
  - 2a. Plik o podanej ścieżce nie istnieje: program wyświetla komunikat o nieistniejącej ścieżce i ponawia pytanie o ścieżkę; prowadzący może wrócić do menu.
  - 3a. Plik ma niepoprawny format albo nie jest plikiem zestawu: program wyjaśnia problem i ponawia pytanie o ścieżkę.
  - 3b. Taki sam zestaw jest już wczytany: program informuje o tym i nie dodaje go drugi raz.
- **Rezultat:** Program poprawnie wczytuje zestaw pytań, a zestaw jest dostępny do wczytania odpowiedzi (UC3) i wyświetlenia wyników (UC4).
- **Ustalenia i pytania:**
  - [Pytanie] Plik zestawu dla uczestników nie zawiera poprawnych odpowiedzi. Skąd program weźmie klucz odpowiedzi po wczytaniu zestawu, żeby ocenić quiz? Czy prowadzący ma osobny plik z kluczem?
- **Powiązane wymagania:** brak, do dodania w requirements.md.

## Powiązania

| UC | Cel | Powiązane Stories |
| --- | --- | --- |
| UC1 | Przygotuj i opublikuj zestaw | US1 |
| UC2 | Rozwiąż quiz lub wypełnij ankietę | US2 |
| UC3 | Wczytaj zebrane odpowiedzi | US3 |
| UC4 | Przejrzyj wyniki i wyeksportuj je do CSV | US4, US5 |
| UC5 | Wczytaj zestaw z pliku | — |
## Poza zakresem tej wersji

Edycja już utworzonego zestawu i przegląd listy zestawów należą do zakresu MVP z wizji, ale nie mają jeszcze własnego UC; dopiszemy je po potwierdzeniu zasad edycji ze sponsorem.
