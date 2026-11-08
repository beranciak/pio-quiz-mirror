using Quiz.App.Domain;
using QuizModel = global::Quiz.App.Domain.Quiz;

namespace Quiz.App.Application;

public sealed class QuizSessionService(IQuizAttemptStore attemptStore)
{
    private readonly IQuizAttemptStore _attemptStore =
        attemptStore ?? throw new ArgumentNullException(nameof(attemptStore));

    public QuizAttempt SubmitAttempt(
        QuizModel quiz,
        string participantId,
        IReadOnlyDictionary<string, string?> selectedOptions)
    {
        ArgumentNullException.ThrowIfNull(quiz);
        ArgumentException.ThrowIfNullOrWhiteSpace(participantId);
        ArgumentNullException.ThrowIfNull(selectedOptions);

        var questionsById = quiz.Questions.ToDictionary(question => question.Id, StringComparer.Ordinal);
        if (selectedOptions.Keys.Any(questionId => !questionsById.ContainsKey(questionId)))
        {
            throw new ArgumentException("Odpowiedź dotyczy pytania spoza tego quizu.", nameof(selectedOptions));
        }

        var answers = new List<QuizAnswer>(quiz.Questions.Count);
        foreach (var question in quiz.Questions)
        {
            selectedOptions.TryGetValue(question.Id, out var selectedOptionId);

            if (selectedOptionId is not null &&
                !question.Options.Any(option => string.Equals(option.Id, selectedOptionId, StringComparison.Ordinal)))
            {
                throw new ArgumentException(
                    $"Wybrana opcja nie należy do pytania {question.Id}.",
                    nameof(selectedOptions));
            }

            var isCorrect = selectedOptionId is not null &&
                question.Options.Single(option =>
                    string.Equals(option.Id, selectedOptionId, StringComparison.Ordinal)).IsCorrect;

            answers.Add(new QuizAnswer(question.Id, selectedOptionId, isCorrect));
        }

        var attempt = new QuizAttempt(
            Guid.NewGuid().ToString("N"),
            participantId.Trim(),
            quiz.Id,
            answers);

        _attemptStore.Add(attempt);
        return attempt;
    }

    public IReadOnlyList<QuizAttempt> GetAttempts() => _attemptStore.GetAll();
}
