using QuizPlatform.Commands;
using QuizPlatform.Services.Abstractions;
using QuizPlatform.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace BalanceMaster.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {

        var serviceProvider = RegisterServices().BuildServiceProvider();

        var quizService = serviceProvider.GetService<IQuizService>();

        var quizResults = quizService.ExecuteQuiz();

        Console.WriteLine($" Score : {quizResults.Score}%");
        Console.ReadLine();

        //var json = File.ReadAllText("Data.json");
    }

    public static IServiceCollection RegisterServices()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfiguration config = builder.Build();

        int userCount = int.Parse(config["UserOptions:UserCount"]);
        int questionCount = int.Parse(config["QuestionOptions:QuestionCount"]);

        int testCount = int.Parse(config["TestOptions:TestCount"]);
        int tekenQuestionsCount = int.Parse(config["QuestionOptions:TekenQuestionsCount"]);

        int quizId = int.Parse(config["QuizOptions:DefaultQuizId"]);
        string quizName = config["QuizOptions:QuizName"];
        double quizDurationInMinutes = double.Parse(config["QuizOptions:QuizDurationInMinutes"]);

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IUserRepository>(sp => new UserRepository(userCount));
        serviceCollection.AddSingleton<IQuestionRepository>(sp => new QuestionRepository(questionCount));
        serviceCollection.AddSingleton<ITestRepository>(sp => new TestRepository(testCount, tekenQuestionsCount, sp.GetService<IQuestionRepository>()));
        serviceCollection.AddSingleton<IQuizRepository>(sp => new QuizRepository(quizId, quizName, quizDurationInMinutes, sp.GetService<ITestRepository>(), sp.GetService<IUserRepository>()));
        serviceCollection.AddSingleton(sp => new QuestionCommands(sp.GetService<IQuestionRepository>()));
        serviceCollection.AddSingleton(sp => new TestCommands(sp.GetService<ITestRepository>()));

        serviceCollection.AddSingleton<ITestService>(sp => new TestService(sp.GetService<ITestRepository>(), sp.GetService<TestCommands>()));
        serviceCollection.AddSingleton<IQuizService>(sp => new QuizService(sp.GetService<IQuizRepository>(), sp.GetService<ITestService>()));


        return serviceCollection;
    }







}