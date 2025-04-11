using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using QuizTower.IDP.Entities;

namespace QuizTower.IDP.PasswordValidators
{
    public class ForbiddenPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : AspNetUser
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            if (PasswordHasForbiddenWords(user, password))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "ForbiddenPassword",
                    Description = "The password must not contain the username or easy to guess passwords."
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }

        private static bool PasswordHasForbiddenWords(TUser user, string password)
        {
            var passwordLower = password.ToLower();
            var forbiddenWords = new[]
            {
                user.UserName,
                user.Email,
                "test",
                "admin",
                "password",
                "12345678"
            }.Select(word => word.ToLower()).ToList();
            return forbiddenWords.Any(forbidden => passwordLower.Contains(forbidden));
        }
    }
}