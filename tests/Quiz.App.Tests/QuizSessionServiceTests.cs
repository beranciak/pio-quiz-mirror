using Quiz.App.Application;
using Quiz.App.Domain;
using Quiz.App.Infrastructure;
using QuizModel = global::Quiz.App.Domain.Quiz;

namespace Quiz.App.Tests;

public sealed class QuizSessionServiceTests
{
    [Fact]
    public void SubmitAttempt_WithCorrectAnswer_ReturnsOneOfOneAndStoresAttempt()
    {
        var store = new InMemoryQuizAttemptStore();
        var service = new QuizSessionService(store);
        var quiz = CreateQuiz();

        var attempt = service.SubmitAttempt(
            quiz,
            "P001",
            new Dictionary<string, string?> { ["question-1"] = "option-1" });

        Assert.Equal(1, attempt.CorrectAnswers);
        Assert.Equal(1, attempt.TotalQuestions);
        Assert.Equal("1/1", attempt.Score);
        Assert.Single(store.GetAll());
    }

    [Fact]
    public void SubmitAttempt_WithIncorrectAnswer_ReturnsZeroOfOne()
    {
        var service = new QuizSessionService(new InMemoryQuizAttemptStore());

        var attempt = service.SubmitAttempt(
            CreateQuiz(),
            "P002",
            new Dictionary<string, string?> { ["question-1"] = "option-2" });

        Assert.Equal(0, attempt.CorrectAnswers);
        Assert.Equal(1, attempt.TotalQuestions);
        Assert.Equal("0/1", attempt.Score);
        Assert.False(attempt.Answers[0].IsCorrect);
    }

    [Fact]
    public void SubmitAttempt_WithSkippedQuestion_StoresUnansweredResponseAndReturnsZero()
    {
        var service = new QuizSessionService(new InMemoryQuizAttemptStore());

        var attempt = service.SubmitAttempt(
            CreateQuiz(),
            "P003",
            new Dictionary<string, string?> { ["question-1"] = null });

        Assert.Null(attempt.Answers[0].SelectedOptionId);
        Assert.Equal("0/1", attempt.Score);
    }

    [Fact]
    public void SubmitAttempt_WithMissingAnswer_TreatsQuestionAsSkipped()
    {
        var service = new QuizSessionService(new InMemoryQuizAttemptStore());

        var attempt = service.SubmitAttempt(
            CreateQuiz(),
            "P004",
            new Dictionary<string, string?>());

        Assert.Null(attempt.Answers[0].SelectedOptionId);
        Assert.Equal("0/1", attempt.Score);
    }

    [Fact]
    public void SubmitAttempt_WithBlankParticipantId_ThrowsAndDoesNotStoreAttempt()
    {
        var store = new InMemoryQuizAttemptStore();
        var service = new QuizSessionService(store);

        Assert.Throws<ArgumentException>(() => service.SubmitAttempt(
            CreateQuiz(),
            " ",
            new Dictionary<string, string?> { ["question-1"] = "option-1" }));

        Assert.Empty(store.GetAll());
    }

    [Fact]
    public void SubmitAttempt_WithUnknownOption_ThrowsAndDoesNotStoreAttempt()
    {
        var store = new InMemoryQuizAttemptStore();
        var service = new QuizSessionService(store);

        Assert.Throws<ArgumentException>(() => service.SubmitAttempt(
            CreateQuiz(),
            "P005",
            new Dictionary<string, string?> { ["question-1"] = "missing-option" }));

        Assert.Empty(store.GetAll());
    }

    [Fact]
    public void SubmitAttempt_WithQuestionOutsideQuiz_ThrowsAndDoesNotStoreAttempt()
    {
        var store = new InMemoryQuizAttemptStore();
        var service = new QuizSessionService(store);

        Assert.Throws<ArgumentException>(() => service.SubmitAttempt(
            CreateQuiz(),
            "P006",
            new Dictionary<string, string?> { ["other-question"] = "option-1" }));

        Assert.Empty(store.GetAll());
    }

    private static QuizModel CreateQuiz()
    {
        var question = new QuizQuestion(
            "question-1",
            "Który język jest używany do tworzenia tej aplikacji?",
            [
                new AnswerOption("option-1", "C#", isCorrect: true),
                new AnswerOption("option-2", "Java"),
                new AnswerOption("option-3", "Python")
            ]);

        return new QuizModel("sample-quiz", "Przykładowy quiz", [question]);
    }
}
