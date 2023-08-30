using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Book.Reading.Event.Application.Models;

namespace Book.Reading.Event.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUser(SignUpModel signUp);
        Task<SignInResult> LoginUser(LoginModel loginModel);
        Task SignOut();
        string GetEmail(string organiser);
    }
}
