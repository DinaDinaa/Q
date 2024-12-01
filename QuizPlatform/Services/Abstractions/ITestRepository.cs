using QuizPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Services.Abstractions
{
    public interface ITestRepository
    {
        void AddTest(Test test);
        void DeleteTest(int testId);
        List<Test> GetTests();
    }
}
