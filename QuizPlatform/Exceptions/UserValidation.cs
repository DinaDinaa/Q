using QuizPlatform.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizPlatform.Models;

namespace QuizPlatform.Exceptions
{
    public static class UserValidation
    {

        public static List<string> ExistingEmails;
        public static  async Task ValidateName(this string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 1 || name.Length > 100)
                throw new ValidationException("Minimum1 and maximum 100 symbols.");
        }

        public static async Task ValidateEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ValidationException("UserName must not be empty.");
            if (!email.Contains('@') || !email.Contains('.'))
                throw new ValidationException("UserName format must be example@mail.com");
            if (email[0] == '@' || email[0] == '.')
                throw new ValidationException("UserName is started with @ , . symbols");
            if (email[^1] == '@' || email[^1] == '.')
                throw new ValidationException("UserName is ended  with @ , .  symbols");
            if (email.Contains(' '))
                throw new ValidationException("UserName must not contain whitespace");
            if (email.Count(x => x == '@') > 1) 
                throw new ValidationException("UserName contains more than one  @  symbols");
            if (email.Length >= 100)
                throw new ValidationException("Maximum 100 symbols");

            if (ExistingEmails.Contains(email))
                throw new ValidationException("UserName is already registered");

            if (email.IndexOf("@") > email.LastIndexOf(".")) 
                throw new ValidationException("Format is not correct");
            
        }

        public static async Task ValidatePassword(this string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 16)
                throw new ValidationException("Minimum 8 and maximum 8 symbols");
        }
    }
}
