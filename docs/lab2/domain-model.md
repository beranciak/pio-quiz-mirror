# Model domenowy — pierwszy przyrost

Model obejmuje quiz z pytaniami zamkniętymi oraz podejścia uczestników. Konsola i magazyn danych są szczegółami aplikacyjnymi, a nie encjami domeny.

~~~mermaid
classDiagram
    class Quiz {
        +string Id
        +string Title
        +IReadOnlyList~QuizQuestion~ Questions
    }
    class QuizQuestion {
        +string Id
        +string Text
        +IReadOnlyList~AnswerOption~ Options
    }
    class AnswerOption {
        +string Id
        +string Text
        +bool IsCorrect
    }
    class QuizAttempt {
        +string Id
        +string ParticipantId
        +string QuizId
        +IReadOnlyList~QuizAnswer~ Answers
        +int CorrectAnswers
        +int TotalQuestions
        +string Score
    }
    class QuizAnswer {
        +string QuestionId
        +string? SelectedOptionId
        +bool IsCorrect
    }
    Quiz "1" *-- "1..*" QuizQuestion : zawiera
    QuizQuestion "1" *-- "2..*" AnswerOption : udostępnia
    Quiz "1" <-- "0..*" QuizAttempt : identyfikowany przez quizId
    QuizAttempt "1" *-- "1..*" QuizAnswer : zawiera
    QuizAnswer "*" --> "1" QuizQuestion : dotyczy
    QuizAnswer "*" --> "0..1" AnswerOption : wybrana opcja; null oznacza pominięcie
~~~

## Reguły

- Pytanie zamknięte ma co najmniej dwie opcje i dokładnie jedną poprawną opcję w tym przyroście.
- Podejście ma niepusty identyfikator uczestnika i najwyżej jedną odpowiedź na pytanie.
- Brak wybranej opcji oznacza pominięcie pytania i nie zwiększa liczby poprawnych odpowiedzi.
- Wynik ma postać `liczba_poprawnych/liczba_pytań`.
- `IQuizAttemptStore` przechowuje podejścia na czas działania procesu; `InMemoryQuizAttemptStore` jest implementacją dla tego przyrostu.
