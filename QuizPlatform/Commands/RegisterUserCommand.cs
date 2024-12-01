using QuizPlatform.Models;
using QuizPlatform.Exceptions;
namespace QuizPlatform.Commands
{
    public class RegisterUserCommand
    { 
     
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public RegisterUserCommand( string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }
        public async Task Validate()
        {
            await  Name.ValidateName();
            await  Email.ValidateEmail();
            await Password.ValidatePassword();
        }
    }
}
