namespace Quiz.App.Domain;

public sealed class QuizQuestion
{
    public QuizQuestion(
        string id,
        string text,
        IEnumerable<AnswerOption> options)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        ArgumentNullException.ThrowIfNull(options);

        var optionList = options.ToArray();
        if (optionList.Length < 2)
        {
            throw new ArgumentException("Pytanie musi mieć co najmniej dwie opcje.", nameof(options));
        }

        if (optionList.Select(option => option.Id).Distinct(StringComparer.Ordinal).Count() != optionList.Length)
        {
            throw new ArgumentException("Identyfikatory opcji muszą być unikalne.", nameof(options));
        }

        if (optionList.Count(option => option.IsCorrect) != 1)
        {
            throw new ArgumentException("Pytanie musi mieć dokładnie jedną poprawną opcję.", nameof(options));
        }

        Id = id;
        Text = text;
        Options = Array.AsReadOnly(optionList);
    }

    public string Id { get; }

    public string Text { get; }

    public IReadOnlyList<AnswerOption> Options { get; }

}
