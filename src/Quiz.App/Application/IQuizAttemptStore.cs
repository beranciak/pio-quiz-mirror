using Quiz.App.Domain;

namespace Quiz.App.Application;

public interface IQuizAttemptStore
{
    void Add(QuizAttempt attempt);

    IReadOnlyList<QuizAttempt> GetAll();
}
