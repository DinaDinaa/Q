using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizPlatform.Models;
using QuizPlatform.Services.Abstractions;


namespace QuizPlatform.Services.Implementations
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly List<Question> _questions;
        public QuestionRepository(int questionCount )
        {
            _questions = Enumerable.Range(1, questionCount).Select(ind =>
                                  new Question
                                  {
                                      QuestionId = ind,
                                      Points = ind % 3 + 1,
                                      AllowMultipleCorrectAnswers = false,
                                      QuestionText = "text"+ ind,

                                      Answers = (new List<Answer> { new Answer { 
                                          AnswerId = ind,
                                          AnswerText = "answer" + ind,
                                          IsCorrect = true,
                                          QuestionId = ind },
                                      })
                                      .Concat(Enumerable.Range(100, 2).Select(ind1 => new Answer
                                      {
                                          AnswerId = ind1,
                                          AnswerText = "answer" + ind1,
                                          IsCorrect = false,
                                          QuestionId = ind
                                      }))
                                      .ToList()
                                  }).ToList();
        
        }

    public List<Question> GetQuestions()
        {
            return _questions;
        }


        public void AddQuestion(Question question)
    {

            _questions.Add(question);

    }

    public void DeleteQuestion(int questionID)
    {

            _questions.Remove(_questions.Find(quest => quest.QuestionId == questionID));
    }

    
    }
}
