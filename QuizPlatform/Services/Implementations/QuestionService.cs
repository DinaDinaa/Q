using QuizPlatform.Commands;
using QuizPlatform.Models;
using QuizPlatform.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Services.Implementations
{
   public class QuestionService: IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly QuestionCommands _commands;

        public QuestionService( IQuestionRepository questionRepository, QuestionCommands commands )
        {
            _questionRepository = questionRepository;
            
            _commands = commands;
        }

        public void RegisterQuestion(QuestionCommands.QuestionCommand command)
        {
           _commands.ValidateQuestion(command);
            var question = new Question
            {
                 QuestionId = command.QuestionId,
                 QuestionText = command.QuestionText,
                 Points = command.Points,
                 Answers = command.Answers,
   
            };

            _questionRepository.AddQuestion( question );
        }

        public void UnregisterQuestion(QuestionCommands.QuestionCommand command)
        {
            _questionRepository.DeleteQuestion(command.QuestionId);
        }
    }
}
