using Quiz.App.Application;
using Quiz.App.Domain;
using Quiz.App.Infrastructure;
using Quiz.App.Presentation;
using QuizModel = global::Quiz.App.Domain.Quiz;

var question = new QuizQuestion(
    id: "question-1",
    text: "Który język jest używany do tworzenia tej aplikacji?",
    options:
    [
        new AnswerOption("option-1", "C#", isCorrect: true),
        new AnswerOption("option-2", "Java"),
        new AnswerOption("option-3", "Python")
    ]);

var quiz = new QuizModel(
    id: "sample-quiz",
    title: "Przykładowy quiz",
    questions: [question]);

var attemptStore = new InMemoryQuizAttemptStore();
var quizSessionService = new QuizSessionService(attemptStore);
var app = new App(quiz, quizSessionService, Console.In, Console.Out);

app.Run();
