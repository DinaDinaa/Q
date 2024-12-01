using QuizPlatform.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizPlatform.Models;


namespace QuizPlatform.Exceptions
{
    public static class QuestionValidation
    {
        public static void ValidateQuestion(string questionText)
        {
            if (questionText.Length < 1 || questionText.Length > 2000)
                throw new ValidationException("Minimum 1 and maximum 2000 symbols.");
        }

        public static void ValidateQuestion(List<Answer> possibleAnswers)
        {
            if (possibleAnswers.Count < 2 || possibleAnswers.Count > 8)
                throw new ValidationException("Minumum 2 and maximum 8 possible answers.");

            foreach (var answer in possibleAnswers)
            {
                if (answer.AnswerText.Length < 1 || answer.AnswerText.Length > 250)
                    throw new ValidationException("Minimum 1 and maximum 250 symbols.");
            }
        }

        public static void ValidateQuestion(int points)
        {

            if (points < 1 || points > 5)
                throw new ValidationException("Minimum 1 and maximum 5 points.");
        }

        public static void ValidateQuestion( List<Answer> possibleAnswers, List<Answer> correctAnswers, int points)
        {
            foreach (var answItem  in correctAnswers)
            {
                if(!possibleAnswers.Contains(answItem))
                {
                    throw new ValidationException("possible answers do not contains all correct answers.");
                }
            }

           

            if (correctAnswers.Distinct().Count() != correctAnswers.Count)
                throw new ValidationException("Correct answers must be unique.");

            if (correctAnswers.Count < 1)
                throw new ValidationException("At least 1 correct answer.");

            if (!correctAnswers.All(an=>an.IsCorrect ))
                throw new ValidationException("Correct answers contains false IsCorrect property");

        }
    }
}
