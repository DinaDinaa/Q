using QuizPlatform.Exceptions;
using QuizPlatform.Models;
using QuizPlatform.Services.Abstractions;

namespace QuizPlatform.Services.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        public UserRepository(int userCount)
        {
            _users = Enumerable.Range(1, userCount).Select(ind =>
                                   new User
                                   {
                                       UserId = ind,
                                       Name = "User" + ind,
                                       UserName = $"email{ind}@gmail.com",
                                       Password = (ind + 1000).ToString() ,
                                   }).ToList();
        }

        

        public async  Task AddUser(User user)
        {
            UserValidation.ExistingEmails = _users.Select(user => user.UserName).ToList();
            _users.Add(user);
        }

        public User GetActiveUser()
        {
            return _users.First();
        }

        public async  Task<List<User>> GetUsers()
        {
            return _users;
        }

    }
}
