using Quiz.App.Application;
using Quiz.App.Domain;

namespace Quiz.App.Infrastructure;

public sealed class InMemoryQuizAttemptStore : IQuizAttemptStore
{
    private readonly List<QuizAttempt> _attempts = [];

    public void Add(QuizAttempt attempt)
    {
        ArgumentNullException.ThrowIfNull(attempt);
        _attempts.Add(attempt);
    }

    public IReadOnlyList<QuizAttempt> GetAll() => _attempts.AsReadOnly();
}
