using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizPlatform.Models;

namespace QuizPlatform.Services.Abstractions
{
    public interface IQuizRepository
    {
        public void UpdateQuiz(Quiz quiz);
        public Quiz GetQuiz();
       
    }
}
