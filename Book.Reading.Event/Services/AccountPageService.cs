using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Book.Reading.Event.Interfaces;
using Book.Reading.Event.Application.Interfaces;
using Book.Reading.Event.Models;
using Book.Reading.Event.Application.Models;

namespace Book.Reading.Event.Services
{
    public class AccountPageService : IAccountPageService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountPageService(IAccountService accountService,IMapper mapper)
        {
            this._accountService = accountService;
            this._mapper = mapper;
        }

        public async Task<IdentityResult> CreateUser(SignUpViewModel signUpViewModel)
        {
            var mapped = _mapper.Map<SignUpModel>(signUpViewModel);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped.");
            }
            var entityDto = await _accountService.CreateUser(mapped);
            return entityDto;
        }

        public async Task<SignInResult> LoginUser(LoginViewModel loginViewModel)
        {
            var mapped = _mapper.Map<LoginModel>(loginViewModel);
            if (mapped == null)
            {
                throw new Exception($"Entity could not be mapped");
            }
            var entityDto = await _accountService.LoginUser(mapped);
            return entityDto;
        }

        public async Task SignOut()
        {
            await _accountService.SignOut();
        }

        public string GetEmail(string organiser)
        {
            return _accountService.GetEmail(organiser);
        }
    }
}
