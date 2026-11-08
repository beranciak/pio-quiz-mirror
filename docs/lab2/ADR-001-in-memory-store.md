# ADR-001 — Magazyn pamięci dla pierwszego przyrostu

- **Status:** propozycja do przeglądu zespołu w PR.
- **Data:** 2026-11-08.

## Kontekst

LAB 2 wymaga małego działającego przyrostu i projektu rozwiązania, a nie implementacji docelowej bazy danych. Bieżące wymagania wizji mówią o początkowym przechowywaniu danych w pamięci. Logikę oceniania trzeba móc sprawdzać bez interakcji z terminalem.

## Rozważane opcje

1. Przechowywać podejścia bezpośrednio w klasie interfejsu terminalowego.
2. Oddzielić logikę od interfejsu magazynu i użyć implementacji pamięciowej.
3. Dodać bazę danych już w tym przyroście.

## Decyzja proponowana

Wprowadzić `IQuizAttemptStore` i `InMemoryQuizAttemptStore`. Interfejs terminalowy przekazuje wejście do `QuizSessionService`, który waliduje odpowiedź, wylicza wynik i zapisuje podejście przez magazyn. W tym przyroście nie dodawać bazy danych ani migracji.

## Konsekwencje

- Przyrost działa offline i nie wymaga usługi zewnętrznej.
- Logikę można testować bez uruchamiania konsoli.
- Dane znikają po zamknięciu programu; prototyp nie zapewnia trwałości.
- W kolejnym etapie trzeba zdecydować o bazie i wdrożyć trwały magazyn. SQLite i EF Core są rekomendacjami, nie obowiązkiem.
