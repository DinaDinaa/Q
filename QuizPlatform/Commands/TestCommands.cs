using QuizPlatform.Exceptions;
using QuizPlatform.Models;
using QuizPlatform.Services.Abstractions;
using QuizPlatform.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuizPlatform.Commands.TestCommands;

namespace QuizPlatform.Commands
{
    public class TestCommands
    {

        private List<TestCommand> _testCommands;
        public TestCommands( ITestRepository testRepository)
        {

            _testCommands = testRepository.GetTests().Select (test => new TestCommand
            {
                TestId = test.TestId,
                TestName = test.TestName,
                TestTime = test.TestTime
            }).ToList();
        }

        
        
        public void Validate()
        {
            //foreach (var testCommand in _testCommands)
            //{
            //    ValidateTest(testCommand);
            //}
            _testCommands.ForEach( testCommand => { ValidateTest(testCommand); });
           
        }

        public void ValidateTest(TestCommand testCommand)
        {
            TestValidation.ValidateTests(testCommand.TestName, testCommand.TestTime);

        }

        public  class TestCommand
        {
            public int TestId { get; set; }
            public string? TestName { get; set; }
            public int TestTime { get; set; }

        }
    }
}
