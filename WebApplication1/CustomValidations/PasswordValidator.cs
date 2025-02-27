using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace WebApplication1.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var errors = new List<IdentityError>();

            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new() { Code = "PasswordContainUserName", 
               
                    Description = "Şifre alanı kullanıcı adını içeremez."
                });
            }
            if (password!.ToLower().Contains("1234"))
            {
                errors.Add(new()
                {
                    Code = "PasswordNoContain1234",
                    Description = "Şifre alanı ardışık sayı içeremez."
                });
            }


            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
