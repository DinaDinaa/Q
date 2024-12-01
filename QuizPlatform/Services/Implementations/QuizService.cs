using QuizPlatform.Commands;
using QuizPlatform.Models;
using QuizPlatform.Services.Abstractions;


namespace QuizPlatform.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly ITestService _testService;
        private QuizResult _quizResult  = new QuizResult();
        public Quiz _quiz { get; set; }
        

        public QuizService(IQuizRepository quizRepository, ITestService testService)
        {
            _quizRepository = quizRepository;
            _testService = testService;
            _quiz = quizRepository.GetQuiz();
        }


        public QuizResult ExecuteQuiz()
        {
            _quizResult.StartTime = DateTime.Now;
            _quizResult.EndTime = _quizResult.StartTime.AddMinutes(_quiz.QuizTime);
           

            while (true)
            {
                
                if (DateTime.Now >= _quizResult.EndTime) // || Console.ReadLine()=="f")                   
                    break;
                
            }

            return EndQuiz();




        }

        public QuizResult EndQuiz()
        {
            var testResults = _testService.SimulateTests(_quiz.AllTests);
            int totalPoints = testResults.Select(test => test.Questions.Select(quest => quest.Points).Sum()).Sum();
            int totalCorrectPoints = testResults.Select(test => test.Questions.Where( quest =>quest.Answers.All( an=>an.IsChecked == an.IsCorrect) ).Select(quest => quest.Points).Sum()).Sum();



            _quizResult.TotalPoints = totalPoints;
            _quizResult.CorrectPoints = totalCorrectPoints;
            _quizResult.Score =Math.Round((double)_quizResult.CorrectPoints /_quizResult.TotalPoints *100);

            return _quizResult;
        }


    }
}
