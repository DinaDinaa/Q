using static QuizPlatform.Commands.TestCommands;
using  QuizPlatform.Models; 
namespace QuizPlatform.Services.Abstractions
{
    public interface ITestService
    {
        public void RegisterTest(TestCommand command);
        public void UnregisterTest(TestCommand command);

        public  List<Test> SimulateTests(List<Test> currentTests);
    }
}
