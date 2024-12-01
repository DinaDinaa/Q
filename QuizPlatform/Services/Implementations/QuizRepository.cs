using QuizPlatform.Models;
using QuizPlatform.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Services.Implementations
{
    public class QuizRepository : IQuizRepository
    {
        private  readonly Quiz _quiz;
        public QuizRepository(int quizId, string quizName, double quizTimeInMinutes , ITestRepository testRepository, IUserRepository userRepository )
        {
            _quiz = new Quiz
            {
                QuizId = quizId,
                QuizName = quizName, 
                AllTests = testRepository.GetTests(),
                UserId = userRepository.GetActiveUser().UserId,
                QuizTime = quizTimeInMinutes,
            };

        }

         


        public void UpdateQuiz(Quiz quiz)
        {
            _quiz.UserId = quiz.UserId;

        }

        public Quiz GetQuiz()
        {
            return _quiz;
        }

      
    }
}
