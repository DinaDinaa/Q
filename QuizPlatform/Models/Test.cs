using QuizPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Models
{
  public class Test
    {
        public int TestId { get; set; } 
        public string TestName { get; set; }
        public int TestTime { get; set; }
        public List<Question> Questions { get; set; }

        public Test(int testId, string testName, int testTime, List<Question> questions)
        {
            TestId = testId;
            TestName = testName;
            TestTime = testTime;
            Questions = new List<Question>();

        }
        public Test()
        {
            
        }

    }
}
