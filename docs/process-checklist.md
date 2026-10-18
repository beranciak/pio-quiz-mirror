# Zasady procesu: DoR i DoD

Krótkie zasady zespołu dopasowane do obecnego etapu (praca analityczna i dokumentacyjna). Gdy powstanie aplikacja, dopiszemy warunki dotyczące budowania i testów. Zasady pracy z `Issue`, `branch`, `PR` i tablicą opisuje sekcja „Jak pracujemy w zespole” w [README](../README.md).

AC (kryteria akceptacji) dotyczą konkretnego wymagania lub zadania. DoD to wspólne warunki ukończenia każdej pracy.

## Definition of Ready (DoR): kiedy można zacząć

Zadanie jest gotowe do rozpoczęcia, gdy:

- jest to `Issue` (nie szkic) w repozytorium zespołu, dodane do tablicy ze statusem To do;
- opisano cel (po co robimy zadanie) i zakres, który mieści się w jednym małym PR;
- opisano oczekiwany rezultat i miejsce, w którym powstanie (np. konkretny plik w `docs/`);
- wiadomo, jak sprawdzimy wykonanie (kryteria akceptacji lub krótka lista kontrolna);
- przypisano jedną osobę odpowiedzialną (Assignees);
- zapisano zależności i pytania; ustalenia potrzebne do pracy są dostępne, a braki są oznaczone jako pytania otwarte ze wskazaniem, gdzie czekamy na odpowiedź.

## Definition of Done (DoD): kiedy zadanie jest skończone

### Przed scaleniem (sprawdza autor i recenzent w PR)

- Rezultat spełnia cel i kryteria akceptacji `Issue`.
- Treść jest spójna z README, wymaganiami i ustaleniami sponsora; domysły są oznaczone jako założenia lub pytania, a nie podane jako ustalenia.
- Dokument sprawdzono w podglądzie Markdown (struktura nagłówków, listy, linki).
- PR ma opis: cel i zakres zmiany, powiązane `Issue` (`Closes #numer` lub `Refs #numer`) oraz sposób sprawdzenia rezultatu.
- W PR nie ma plików tymczasowych ani niepowiązanych zmian; commity mają czytelne opisy.
- Inna osoba wykonała review, uwagi rozpatrzono (poprawiono lub uzasadniono), a recenzent wybrał Approve.

### Po scaleniu (sprawdza autor)

- PR jest scalony do `main` (scala autor po Approve).
- Powiązane `Issue` jest zamknięte, a karta na tablicy ma status Done.
- Autor pobrał `main` i sprawdził wynik.
- Nowe pytania lub zadania wynikające z pracy zapisano jako `Issue` albo na właściwym kanale MS Teams.

DoR i DoD to wstępna propozycja zespołu; doprecyzujemy je w miarę zdobywania doświadczenia.
