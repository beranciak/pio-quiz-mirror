namespace Quiz.App.Domain;

public sealed class QuizAttempt
{
    public QuizAttempt(
        string id,
        string participantId,
        string quizId,
        IEnumerable<QuizAnswer> answers)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(participantId);
        ArgumentException.ThrowIfNullOrWhiteSpace(quizId);
        ArgumentNullException.ThrowIfNull(answers);

        var answerList = answers.ToArray();
        if (answerList.Length == 0)
        {
            throw new ArgumentException("Podejście musi zawierać odpowiedź co najmniej na jedno pytanie.", nameof(answers));
        }

        if (answerList.Select(answer => answer.QuestionId).Distinct(StringComparer.Ordinal).Count() != answerList.Length)
        {
            throw new ArgumentException("Podejście może zawierać tylko jedną odpowiedź na pytanie.", nameof(answers));
        }

        Id = id;
        ParticipantId = participantId;
        QuizId = quizId;
        Answers = Array.AsReadOnly(answerList);
    }

    public string Id { get; }

    public string ParticipantId { get; }

    public string QuizId { get; }

    public IReadOnlyList<QuizAnswer> Answers { get; }

    public int CorrectAnswers => Answers.Count(answer => answer.IsCorrect);

    public int TotalQuestions => Answers.Count;

    public string Score => $"{CorrectAnswers}/{TotalQuestions}";
}
