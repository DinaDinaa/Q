using QuizPlatform.Models;
using QuizPlatform.Exceptions;
using QuizPlatform.Services.Abstractions;

namespace QuizPlatform.Commands
{
    public class QuestionCommands
    {
        private List<QuestionCommand> _questionCommands;

        public QuestionCommands(IQuestionRepository questionRepository)
        {

            _questionCommands = questionRepository.GetQuestions().Select(quest => new QuestionCommand
            {
                Answers = quest.Answers,
                Points = quest.Points,
                QuestionText = quest.QuestionText
            }).ToList();


        }
        public void Validate()
        {
            foreach (var questionCommand in _questionCommands)
            {
                ValidateQuestion(questionCommand);
            }

        }

        public void ValidateQuestion (QuestionCommand command)
        {
            QuestionValidation.ValidateQuestion(command.QuestionText);
            QuestionValidation.ValidateQuestion(command.Answers);
            QuestionValidation.ValidateQuestion(command.Points);

        }

        public class QuestionCommand
        {
            public  int QuestionId { get; set; }
            public string? QuestionText { get; set; }
            public List<Answer> Answers { get; set; }
            public int Points { get; set; }
        }

    }
}
