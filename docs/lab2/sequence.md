# Diagram sekwencji — rozwiązanie przykładowego quizu

Diagram przedstawia główny scenariusz UC2 realizowany w pierwszym przyroście.

~~~mermaid
sequenceDiagram
    actor U as Uczestnik
    participant T as App (TUI)
    participant S as QuizSessionService
    participant M as InMemoryQuizAttemptStore

    U->>T: Wybiera rozwiązanie przykładowego quizu
    T-->>U: Prośba o identyfikator
    U->>T: Podaje identyfikator
    T-->>U: Pytanie i numerowane opcje
    U->>T: Wybiera opcję albo naciska Enter
    T->>S: SubmitAttempt(quiz, participantId, answer)
    S->>S: Waliduje wejście i oblicza wynik
    S->>M: Add(attempt)
    M-->>S: Podejście zapisane w pamięci
    S-->>T: Podejście i wynik
    T-->>U: Informacja o poprawności i wynik

    alt Identyfikator jest pusty
        T-->>U: Komunikat i ponowna prośba o identyfikator
    else Wybór jest nieprawidłowy
        T-->>U: Komunikat i ponowienie prośby o wybór
    end
~~~

Przechowywanie jest nietrwałe: zamknięcie aplikacji kończy sesję i usuwa zapisane w niej podejścia.
