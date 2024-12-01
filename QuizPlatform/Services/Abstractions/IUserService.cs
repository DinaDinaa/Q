using QuizPlatform.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Services.Abstractions
{
    public interface IUserService
    {
        Task RegisterUser(RegisterUserCommand command);
    }
}
