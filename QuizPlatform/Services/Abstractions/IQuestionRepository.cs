using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizPlatform.Models;

namespace QuizPlatform.Services.Abstractions
{
    public interface IQuestionRepository
    {
        void AddQuestion(Question question);
        void DeleteQuestion(int questionID);
        List<Question> GetQuestions();
    }
}
