using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Models
{
    public class QuizResult
    {

        public int CorrectPoints { get; set; }
        public int TotalPoints { get; set; }

        public double Score { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
       public bool  QuizIsFinished { get; set; }
    }
}
