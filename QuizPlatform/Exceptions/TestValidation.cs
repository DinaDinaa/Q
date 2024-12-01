using QuizPlatform.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizPlatform.Models;

namespace QuizPlatform.Exceptions
{
    public static class TestValidation
    {

        public static void ValidateTests(string testName, int testTime)
        {
            if (testName.Length < 1 || testName.Length > 100)
                throw new ValidationException("Minimum 1 and maximum 100 symbols.");

            if (testTime < 1 || testTime > 60)
                throw new ValidationException("Minimum 1 and maximum 60 minutes.");
        }
        public static void ValidateQuestions(List<Question> questions) 
        {
            if (questions.Count >= 100)
                throw new ValidationException("Maximum 100 questions.");
        }
    }
}
