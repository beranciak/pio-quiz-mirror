# LAB 2 — pierwszy przyrost: rozwiązanie quizu

## Cel i granice

Przyrost realizuje fragment przypadku użycia [UC2: Rozwiąż quiz lub wypełnij ankietę](../use-cases.md): uczestnik rozwiązuje jeden przykładowy quiz offline, widzi wynik, a aplikacja przechowuje podejście w pamięci do końca działania procesu.

To pionowy, demonstracyjny wycinek produktu, a nie komplet funkcji z UC2. Nie obejmuje tworzenia zestawów, importu ani eksportu CSV, ankiet, wielu pytań, bazy danych, trwałego zapisu ani logowania. Uczestnik podaje wymagany identyfikator, ponieważ przyrost dotyczy ocenianego quizu. Pominięcie pytania jest dozwolone. Zwykłe pytanie zamknięte ma jedną poprawną odpowiedź.

## Scenariusz

1. Uczestnik wybiera w menu rozwiązanie przykładowego quizu.
2. Podaje niepusty identyfikator.
3. Czyta jedno pytanie i wybiera numer opcji albo naciska Enter, aby pominąć pytanie.
4. Aplikacja sprawdza odpowiedź, zapisuje podejście w pamięci i pokazuje wynik.
5. Uczestnik może wyświetlić wyniki wszystkich podejść z bieżącej sesji.

## Kryteria akceptacji

| ID | Warunek | Oczekiwany rezultat |
| --- | --- | --- |
| AC1 | Uczestnik rozpoczyna quiz i podaje identyfikator | Aplikacja pokazuje przykładowe pytanie i ponumerowane opcje |
| AC2 | Identyfikator jest pusty lub zawiera tylko białe znaki | Aplikacja wyświetla komunikat i ponawia prośbę o identyfikator |
| AC3 | Uczestnik wybiera poprawną opcję | Podejście trafia do pamięci, a wynik to 1/1 |
| AC4 | Uczestnik wybiera błędną opcję | Podejście trafia do pamięci, a wynik to 0/1 |
| AC5 | Uczestnik naciska Enter bez wyboru | Odpowiedź zostaje oznaczona jako pominięta, a wynik to 0/1 |
| AC6 | Uczestnik wpisuje tekst lub numer spoza dostępnych opcji | Aplikacja pokazuje błąd i ponawia prośbę o wybór; nie zapisuje błędnego wejścia |
| AC7 | W bieżącej sesji zapisano podejścia | Opcja wyników pokazuje identyfikator i wynik każdego podejścia |
| AC8 | W bieżącej sesji nie ma podejść | Opcja wyników wyświetla czytelny komunikat o braku wyników |
| AC9 | Aplikacja zostaje zamknięta | Podejścia z pamięci znikają; trwały zapis nie jest częścią tego przyrostu |

## Ustalenia zastosowane w tym przyroście

- Quiz/test wymaga identyfikatora uczestnika; brak identyfikatora może dotyczyć anonimowej ankiety, która jest poza zakresem.
- Uczestnik może pozostawić pytanie bez odpowiedzi.
- Pytanie jednokrotnego wyboru ma domyślnie jedną poprawną opcję. Pytania otwarte nie są automatycznie oceniane, a wielokrotny wybór jest poza tym przyrostem.
- Odpowiedź oraz wynik są przechowywane w pamięci operacyjnej w trakcie sesji. Trwała baza danych należy do kolejnego etapu projektu.
- Są to wskazówki prowadzącego przekazane w odpowiedziach na pytania zespołów; zakres powyżej zawęża je do pierwszego przyrostu.

## Projekt i weryfikacja

- [Model domenowy](domain-model.md)
- [Diagram sekwencji](sequence.md)
- [ADR-001: magazyn pamięci](ADR-001-in-memory-store.md)
- [Strategia testów](test-strategy.md)
- [Kontrakt interfejsu terminalowego](../contract.md)

Implementacja i testy jednostkowe są w `src/Quiz.App` i `tests/Quiz.App.Tests`. Przed scaleniem zespół powinien przejrzeć zakres i decyzję o wersji .NET oraz sprawdzić działanie prototypu na środowisku, na którym będzie prezentowany.
