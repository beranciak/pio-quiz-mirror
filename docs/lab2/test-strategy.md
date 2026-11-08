# Strategia testów — pierwszy przyrost

## Poziomy

| Poziom | Zakres | Sposób |
| --- | --- | --- |
| Jednostkowy | Walidacja identyfikatora i opcji, ocenianie poprawnej, błędnej i pominiętej odpowiedzi, zapis podejścia | xUnit; test `QuizSessionService` i magazynu w pamięci |
| Ręczny | Menu, tekst pytania, błędne wejście, pominięcie, podgląd wyników i wyjście | Uruchomienie programu w terminalu według [kontraktu TUI](../contract.md) |

## Powiązanie scenariuszy

| Kryterium | Przypadek testowy | Rezultat |
| --- | --- | --- |
| AC2 | Pusty identyfikator | Błąd walidacji; brak zapisanego podejścia |
| AC3 | Poprawna opcja | Wynik 1/1; podejście zachowane w magazynie |
| AC4 | Błędna, ale dostępna opcja | Wynik 0/1; podejście zachowane w magazynie |
| AC5 | Pominięte pytanie | Brak wybranej opcji; wynik 0/1 |
| AC6 | Opcja spoza pytania lub pytanie spoza quizu | Błąd walidacji; brak niepoprawnego podejścia |
| AC7–AC8 | Lista wyników z podejściami lub bez nich | Czytelne podsumowanie albo komunikat o braku wyników |

Przed zamknięciem PR autor i recenzent powinni uruchomić build oraz testy, a także ręcznie przejść poprawną, błędną i pominiętą odpowiedź. Testy są w `tests/Quiz.App.Tests`.

## Poza zakresem

Testy importu/eksportu CSV, bazy danych i wydajności wejdą do strategii po zaprojektowaniu tych funkcji. Nie zakładamy ich obecności w pierwszym przyroście.
