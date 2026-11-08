using Quiz.App.Application;
using Quiz.App.Domain;
using QuizModel = global::Quiz.App.Domain.Quiz;

namespace Quiz.App.Presentation;

public sealed class App(
    QuizModel quiz,
    QuizSessionService quizSessionService,
    TextReader input,
    TextWriter output)
{
    private readonly QuizModel _quiz = quiz ?? throw new ArgumentNullException(nameof(quiz));
    private readonly QuizSessionService _quizSessionService =
        quizSessionService ?? throw new ArgumentNullException(nameof(quizSessionService));
    private readonly TextReader _input = input ?? throw new ArgumentNullException(nameof(input));
    private readonly TextWriter _output = output ?? throw new ArgumentNullException(nameof(output));

    public void Run()
    {
        while (true)
        {
            ShowMenu();
            var choice = _input.ReadLine();
            if (choice is null || choice.Trim() == "0")
            {
                return;
            }

            switch (choice.Trim())
            {
                case "1":
                    if (!RunQuiz())
                    {
                        return;
                    }

                    break;
                case "2":
                    ShowAttempts();
                    break;
                default:
                    _output.WriteLine("Nieznana opcja. Wybierz 1, 2 albo 0.");
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        _output.WriteLine();
        _output.WriteLine("Quiz / Ankieta");
        _output.WriteLine("1. Rozwiąż przykładowy quiz");
        _output.WriteLine("2. Pokaż wyniki bieżącej sesji");
        _output.WriteLine("0. Zakończ");
        _output.Write("Wybierz opcję: ");
    }

    private bool RunQuiz()
    {
        var participantId = ReadParticipantId();
        if (participantId is null)
        {
            return false;
        }

        if (_quiz.Questions.Count != 1)
        {
            _output.WriteLine("Pierwszy przyrost obsługuje quiz zawierający jedno pytanie.");
            return true;
        }

        var question = _quiz.Questions[0];
        _output.WriteLine();
        _output.WriteLine(question.Text);
        for (var index = 0; index < question.Options.Count; index++)
        {
            _output.WriteLine($"{index + 1}. {question.Options[index].Text}");
        }

        _output.Write("Wybierz numer odpowiedzi lub naciśnij Enter, aby pominąć: ");
        string? selectedOptionId;
        while (true)
        {
            var answer = _input.ReadLine();
            if (answer is null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(answer))
            {
                selectedOptionId = null;
                break;
            }

            if (int.TryParse(answer, out var optionNumber) &&
                optionNumber >= 1 &&
                optionNumber <= question.Options.Count)
            {
                selectedOptionId = question.Options[optionNumber - 1].Id;
                break;
            }

            _output.Write($"Niepoprawny wybór. Wpisz numer od 1 do {question.Options.Count} lub naciśnij Enter: ");
        }

        var attempt = _quizSessionService.SubmitAttempt(
            _quiz,
            participantId,
            new Dictionary<string, string?>(StringComparer.Ordinal)
            {
                [question.Id] = selectedOptionId
            });

        if (selectedOptionId is null)
        {
            _output.WriteLine($"Pytanie pominięte. Wynik: {attempt.Score}.");
        }
        else if (attempt.CorrectAnswers == 1)
        {
            _output.WriteLine($"Poprawna odpowiedź. Wynik: {attempt.Score}.");
        }
        else
        {
            _output.WriteLine($"Niepoprawna odpowiedź. Wynik: {attempt.Score}.");
        }

        return true;
    }

    private string? ReadParticipantId()
    {
        while (true)
        {
            _output.Write("Podaj identyfikator uczestnika: ");
            var participantId = _input.ReadLine();
            if (participantId is null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(participantId))
            {
                return participantId.Trim();
            }

            _output.WriteLine("Identyfikator jest wymagany.");
        }
    }

    private void ShowAttempts()
    {
        var attempts = _quizSessionService.GetAttempts();
        if (attempts.Count == 0)
        {
            _output.WriteLine("Brak wyników w bieżącej sesji.");
            return;
        }

        _output.WriteLine("Wyniki bieżącej sesji:");
        foreach (var attempt in attempts)
        {
            _output.WriteLine($"{attempt.ParticipantId}: {attempt.Score}");
        }
    }
}
