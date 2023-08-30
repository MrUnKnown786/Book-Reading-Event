using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Book.Reading.Event.Application.Interfaces;
using Book.Reading.Event.Application.Mapper;
using Book.Reading.Event.Application.Models;
using Book.Reading.Event.Core.Entities;
using Book.Reading.Event.Core.IRepositories;

namespace Book.Reading.Event.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public async Task<IdentityResult> CreateUser(SignUpModel signUpModel)
        {
            var mapped = ObjectMapper.Mapper.Map<SignUp>(signUpModel);
            if (mapped == null)
            {
                throw new ApplicationException($"Entity could not be mapped.");
            }
            var entityDto = await _accountRepository.CreateUser(mapped);
            return entityDto;
        }

        public async Task<SignInResult> LoginUser(LoginModel loginModel)
        {
            var mapped = ObjectMapper.Mapper.Map<Login>(loginModel);
            if (mapped == null)
            {
                throw new ApplicationException($"Entity could not be mapped");
            }
            var entityDto = await _accountRepository.LoginUser(mapped);
            return entityDto;
        }

        public async Task SignOut()
        {
            await _accountRepository.SignOut();
        }

        public string GetEmail(string organiser)
        {
            return _accountRepository.GetEmail(organiser);
        }
    }
}
