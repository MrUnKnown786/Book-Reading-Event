using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Book.Reading.Event.Models;

namespace Book.Reading.Event.Interfaces
{
    public interface IAccountPageService
    {
        Task<IdentityResult> CreateUser(SignUpViewModel signUp);
        Task<SignInResult> LoginUser(LoginViewModel loginModel);
        Task SignOut();
        string GetEmail(string organiser);
    }
}
