using QuizPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Services.Abstractions
{
   public interface IUserRepository
    {

        Task<List<User>> GetUsers();
        Task AddUser(User user);

        User GetActiveUser();
    }
}
