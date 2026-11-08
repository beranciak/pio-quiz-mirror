namespace Quiz.App.Domain;

public sealed class Quiz
{
    public Quiz(string id, string title, IEnumerable<QuizQuestion> questions)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentNullException.ThrowIfNull(questions);

        var questionList = questions.ToArray();
        if (questionList.Length == 0)
        {
            throw new ArgumentException("Quiz musi zawierać co najmniej jedno pytanie.", nameof(questions));
        }

        if (questionList.Select(question => question.Id).Distinct(StringComparer.Ordinal).Count() != questionList.Length)
        {
            throw new ArgumentException("Identyfikatory pytań muszą być unikalne.", nameof(questions));
        }

        Id = id;
        Title = title;
        Questions = Array.AsReadOnly(questionList);
    }

    public string Id { get; }

    public string Title { get; }

    public IReadOnlyList<QuizQuestion> Questions { get; }
}
