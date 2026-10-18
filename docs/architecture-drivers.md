# Architecture Drivers

Dokument porządkuje czynniki, które ukierunkowują projekt architektury aplikacji Quiz / Ankieta. Nie wybieramy tu bazy danych ani bibliotek; to decyzje na kolejne zajęcia (C4, ADR).

**Oznaczenia przy wpisach:**

- **[Ustalenie]**: informacja potwierdzona; podajemy źródło.
- **[Założenie]**: przyjmujemy roboczo, wymaga potwierdzenia.
- **[Pytanie]**: brakuje odpowiedzi potrzebnej do dalszej pracy; pytania kierujemy do sponsora na głównym kanale przedmiotu w MS Teams.

**Źródła:** „Wizja” to opis produktu przekazany przez sponsora na LAB 1. „Zasady kursu” to dokument Zasady Zaliczenia i Harmonogram Zajęć.

## Technical Constraints

- **[Ustalenie]** Aplikacja konsolowa (CLI) w C#/.NET z interfejsem tekstowym (TUI): menu z numerowanymi opcjami i dialog tekstowy. Źródło: wizja, skrypt LAB 1.
- **[Ustalenie]** Docelowe środowisko: typowy komputer uczelniany z Windows 11, bez dostępu do internetu. Źródło: wizja.
- **[Ustalenie]** Aplikacja działa bez kont, logowania i mechanizmu uprawnień (poza zakresem projektu). Źródło: wizja.
- **[Ustalenie]** Na początku dane są przechowywane w pamięci operacyjnej. Wybór bazy danych do trwałego zapisu i sposobu dostępu do niej to późniejsza decyzja projektowa, uzasadniona wymaganiami. Źródło: wizja.
- **[Ustalenie]** Import i eksport danych odbywają się przez pliki CSV; wyniki mają nadawać się do Excela lub innego arkusza. Źródło: wizja.
- **[Ustalenie]** Na tym etapie nie ma centralnego serwera ani współdzielenia danych online. Źródło: wizja.
- **[Ustalenie]** Zestawy pytań i odpowiedzi mają być łatwe do przenoszenia między komputerami, a aplikacja ma uruchamiać się bez złożonej instalacji. Źródło: wizja.
- **[Pytanie]** Jak dokładnie przekazujemy pliki (nośnik USB, udział sieciowy, inaczej) i jakie są warunki uruchomienia: czy na komputerach uczelnianych jest środowisko .NET, czy aplikacja ma być samodzielnym plikiem?
- **[Założenie]** Schemat CSV: separator `;` i kodowanie UTF-8, bo domyślna polska konfiguracja Excela rozpoznaje `;` jako separator. Do potwierdzenia testem otwarcia przykładowego pliku w Excelu (dotyczy też ewentualnego BOM).

## Business Constraints

- **[Ustalenie]** Projekt rozwijamy przyrostowo w zespole czteroosobowym w semestrze zimowym 2026/2027. Etapy i harmonogram są wspólne dla wszystkich zespołów: LAB 1–4 po 90 minut, LAB 5 (odbiór) 45 minut. Źródło: zasady kursu.
- **[Ustalenie]** Większość pracy odbywa się między zajęciami; zespół sam organizuje podział prac (GitHub Flow, GitHub Projects, kanał zespołu w MS Teams). Źródło: zasady kursu.
- **[Ustalenie]** Końcowe artefakty: działający produkt, raport PDF i slajdy PDF, demo i obrona techniczna. Źródło: zasady kursu.
- **[Założenie]** Korzystamy wyłącznie z darmowych narzędzi (GitHub, VS Code lub Visual Studio, MS Teams).
- **[Pytanie]** Czy zakres MVP z wizji jest zakresem wymaganym na demo, czy część funkcji (np. edycja zestawu, statystyki) może zostać na później, jeśli zabraknie czasu?

## Functional Requirements

**Funkcje istotne dla budowy systemu:**

- **[Ustalenie]** Zakres MVP: tworzenie i edycja quizu lub ankiety; pytania jednokrotnego i wielokrotnego wyboru; publikacja zestawu jako wersji „zamrożonej” do rozwiązania; zapis i eksport odpowiedzi; zebranie plików przez prowadzącego; wczytanie zebranych odpowiedzi; wyniki, podstawowe statystyki i eksport do pliku; czytelne komunikaty błędów. Źródło: wizja.
- **[Ustalenie]** Jedno narzędzie dla prowadzącego i uczestników; sposób obsługi obu ról dopracujemy podczas projektowania. Źródło: wizja.
- **[Ustalenie]** Uczestnicy mogą pracować w tym samym czasie, każdy lokalnie na swoim komputerze, bez internetu. Źródło: wizja.
- **[Ustalenie]** Odpowiedź może zawierać identyfikator uczestnika, ale nie tworzymy rozbudowanych profili osobowych. Źródło: wizja.

**Wpływ na budowę (wnioski zespołu, do weryfikacji w projekcie):**

- Opublikowany zestaw musi być niezmienny, a odpowiedzi muszą wskazywać zestaw i jego wersję. Inaczej nie da się poprawnie policzyć wyników.
- Import odpowiedzi z wielu plików wymaga walidacji, wykrywania niezgodności z zestawem i obsługi duplikatów.
- Rola prowadzącego i rola uczestnika działają w jednym programie, więc menu i dialogi muszą rozdzielać ich czynności.

**Pytania otwarte:**

- **[Pytanie]** Czym różnią się wyniki quizu od wyników ankiety (np. punkty i poprawność kontra rozkład odpowiedzi)? Wizja każe to ustalić w discovery.
- **[Pytanie]** Co oznacza „odpowiedź” w liczbach skali: jedna wybrana opcja w jednym pytaniu czy całe wypełnienie zestawu przez uczestnika? Od tego zależy, ile danych musi obsłużyć aplikacja.
- **[Pytanie]** Jakie są zasady oceniania pytań wielokrotnego wyboru (wszystko albo nic, punkty częściowe)?
- **[Pytanie]** Czy uczestnik widzi wynik quizu od razu po zakończeniu? Wizja mówi o „jasnym wyniku”, ale plik zestawu przekazywany uczestnikom nie powinien zawierać klucza poprawnych odpowiedzi.
- **[Pytanie]** Czy ankieta ma być anonimowa, a quiz identyfikowany? Jak postępujemy z danymi (jak długo przechowujemy, kiedy usuwamy)?
- **[Pytanie]** Czy edycja dotyczy wyłącznie zestawów jeszcze niepublikowanych? Co zrobić z odpowiedziami już zebranymi, gdy prowadzący zechce poprawić pytanie?
- **[Założenie]** Plik zestawu przekazywany uczestnikom nie zawiera poprawnych odpowiedzi; klucz pozostaje u prowadzącego. Do potwierdzenia ze sponsorem.

## Quality Attributes

- **Skala i wydajność**
  - **[Ustalenie]** Typowa grupa liczy 20–40 uczestników, sporadycznie do 100. Prowadzący może zgromadzić kilkaset quizów i ankiet oraz dziesiątki tysięcy odpowiedzi. Źródło: wizja.
  - **[Ustalenie]** Podczas zajęć nie chcemy czekać na podstawowe operacje. Źródło: wizja.
  - **[Pytanie]** Których operacji dotyczy oczekiwanie (np. wczytanie odpowiedzi z folderu, obliczenie wyników, eksport CSV) i jaki czas jest akceptowalny przy uzgodnionej skali? Nie wpisujemy liczb, dopóki sponsor ich nie potwierdzi.
- **Niezawodność i trwałość danych**
  - **[Ustalenie]** Aktualizacja aplikacji nie może powodować utraty istniejących quizów ani wyników. Źródło: wizja.
  - **[Ustalenie]** Aplikacja działa także bez internetu i bez usług chmurowych. Źródło: wizja.
  - **[Pytanie]** Jaki poziom ochrony przed awarią jest wymagany (kopie zapasowe, odtwarzanie danych)? Dane w pamięci operacyjnej znikną po zamknięciu programu, więc musimy wiedzieć, kiedy i jak prowadzący zapisuje wyniki.
- **Użyteczność**
  - **[Ustalenie]** Prowadzący tworzy i uruchamia quiz lub ankietę na miejscu w kilka minut; uczestnik odpowiada szybko. Źródło: wizja.
  - **[Pytanie]** Co oznaczają „kilka minut” i „szybko” (dla ilu pytań, ile kroków)?
  - **[Ustalenie]** Komunikaty błędów są czytelne dla osoby nietechnicznej: mówią, co się stało i co zrobić dalej. Źródło: wizja, materiały LAB 1.
- **Przenośność i uruchomienie**
  - **[Ustalenie]** Aplikacja jest łatwa do przeniesienia i uruchamia się bez złożonej instalacji. Źródło: wizja.
- **Zgodność danych**
  - **[Ustalenie]** Wyeksportowane wyniki nadają się do użycia w Excelu lub innym arkuszu. Źródło: wizja.
  - **[Założenie]** Kryterium sprawdzenia: plik eksportu otwiera się w Excelu z poprawnym podziałem na kolumny i polskimi znakami.
- **Prywatność**
  - **[Ustalenie]** Dane przechowujemy lokalnie, bez rozbudowanych profili osobowych. Źródło: wizja.

## Rozpoznane kompromisy

1. **Dane w pamięci operacyjnej a trwałość.** Zyskujemy prostotę i szybki start. Kosztem jest utrata danych po zamknięciu programu, jeśli prowadzący nie wyeksportuje wyników; trwały zapis wymaga osobnej decyzji projektowej. Wymaga wyjaśnienia ze sponsorem (pytanie o kopie i odtwarzanie).
2. **Offline i pliki CSV zamiast serwera.** Zyskujemy niezawodność w salach bez internetu i brak instalacji usług. Kosztem jest ręczne zbieranie plików przez prowadzącego oraz ryzyko zgubionych, zduplikowanych lub niezgodnych plików.
3. **Jedno narzędzie dla dwóch ról.** Zyskujemy prostszą dystrybucję (jeden program). Kosztem jest bardziej rozbudowane menu i brak mechanizmu uprawnień, więc uczestnik technicznie może użyć funkcji prowadzącego. Brak uprawnień jest świadomie poza zakresem.
4. **Anonimowość a identyfikacja uczestnika.** Identyfikator ułatwia ocenianie i eksport wyników do ocen, ale zwiększa wrażliwość danych. Anonimowość chroni uczestników, lecz uniemożliwia przypisanie wyniku do osoby.
5. **Zamrożona wersja zestawu a możliwość poprawek.** Niezmienny zestaw gwarantuje spójność wyników. Kosztem jest brak możliwości szybkiego poprawienia błędu w pytaniu po publikacji.
