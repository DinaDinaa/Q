
using QuizPlatform.Commands;


namespace QuizPlatform.Services.Abstractions
{
     public interface IQuestionService
    {

       public void RegisterQuestion(QuestionCommands.QuestionCommand command);
       public void UnregisterQuestion(QuestionCommands.QuestionCommand command);

    }
}
