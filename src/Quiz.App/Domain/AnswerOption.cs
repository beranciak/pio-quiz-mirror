namespace Quiz.App.Domain;

public sealed record AnswerOption
{
    public AnswerOption(string id, string text, bool isCorrect = false)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(text);

        Id = id;
        Text = text;
        IsCorrect = isCorrect;
    }

    public string Id { get; }

    public string Text { get; }

    public bool IsCorrect { get; }
}
