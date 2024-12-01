using QuizPlatform.Commands;
using QuizPlatform.Models;
using QuizPlatform.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuizPlatform.Commands.TestCommands;

namespace QuizPlatform.Services.Implementations
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testrepository;
        private readonly TestCommands _testCommands;

        public TestService(ITestRepository testrepository, TestCommands testCommands)
        {
            _testrepository = testrepository;
            _testCommands = testCommands;
        }

        public void RegisterTest(TestCommand command)
        {
            _testCommands.ValidateTest(command);

            var test = new Test
            {
                TestId = command.TestId,
                TestName = command.TestName,
                TestTime = command.TestTime,


            };

            _testrepository.AddTest(test);
        }

        public List<Test> SimulateTests(List<Test> currentTests)
        {
            currentTests.ForEach(test =>
            {
                test.Questions.ForEach(question =>
                                                    {
                                                        var shuffleAnswers = question.Answers.OrderBy(x => Guid.NewGuid()).ToList();

                                                        shuffleAnswers.Last().IsChecked = true;
                                                    });
                });

            return currentTests;
        }

        public void UnregisterTest(TestCommands.TestCommand command)
        {
            _testrepository.DeleteTest(command.TestId);
        }
    }
}
