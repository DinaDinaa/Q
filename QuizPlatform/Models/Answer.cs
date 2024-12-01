using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuizPlatform.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public string? AnswerText { get; set; }
        public bool IsChecked { get; set; }
        
        public Answer() { }

        public Answer(int answerId, int questionId, bool isCorrect, string answerText)
        {
            AnswerId = answerId;
            QuestionId = questionId;
            AnswerText = answerText;
            IsCorrect = isCorrect;
        }
    }
}
