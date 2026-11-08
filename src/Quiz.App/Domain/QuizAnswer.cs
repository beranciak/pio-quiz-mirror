namespace Quiz.App.Domain;

public sealed record QuizAnswer(string QuestionId, string? SelectedOptionId, bool IsCorrect);
