using QuizPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }

        public double QuizTime { get; set; } = 60;

        public int UserId { get; set; }
        public  List<Test> AllTests { get; set; }
    }
}
