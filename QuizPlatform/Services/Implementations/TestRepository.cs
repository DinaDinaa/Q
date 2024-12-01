
using QuizPlatform.Models;
using QuizPlatform.Services.Abstractions;

namespace QuizPlatform.Services.Implementations
{
    public class TestRepository : ITestRepository
    {
        private readonly List<Test> _tests;
        public TestRepository( int testCount, int questionCount, IQuestionRepository questionRepository)
        {
            _tests = Enumerable.Range(1, testCount).Select(ind =>
                                 new Test
                                 {
                                     TestId = ind,
                                     TestName = "test" + ind,
                                     TestTime = ind,
                                     Questions = questionRepository.GetQuestions().OrderBy(quest=>Guid.NewGuid()).Take(questionCount).ToList(),

                                 }).ToList();

        }

        public void AddTest(Test test)
        {
           _tests.Add(test);
        }
        public void DeleteTest(int testId)
        {
            _tests.Remove(_tests.Find(t => t.TestId == testId));
        }

        public List<Test> GetTests()
        {
            return _tests;
        }

       
    }
   
}
