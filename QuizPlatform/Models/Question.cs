using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuizPlatform.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
        public bool AllowMultipleCorrectAnswers { get; set; }
        public int Points { get; set; }

        public Question() { }
        public Question(int id, string questionText, List<Answer> answers, bool allowMultipleCorrectAnswers, int points)
        {
            QuestionId = id;
            QuestionText = questionText;
            Answers = answers;
            AllowMultipleCorrectAnswers = allowMultipleCorrectAnswers;
            Points = points;
        }

    }
}
