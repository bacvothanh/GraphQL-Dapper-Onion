using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fighting.Core.Models;
using Fighting.Repository.Interfaces;
using Fighting.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Fighting.Service
{
    public class AccountService : GenericService<Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository repository) : base(repository)
        {
            _accountRepository = repository;
        }
        
        public Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.FromResult(0);
        }

        public Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken)
        {
            _accountRepository.Insert(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken)
        {
            _accountRepository.Update(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken)
        {
            _accountRepository.DeleteById(user.Id);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<Account> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var account = _accountRepository.GetById(userId);
            return Task.FromResult(account);
        }

        public Task<Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var account = _accountRepository.Gets(new {userName = normalizedUserName}).FirstOrDefault();
            return Task.FromResult(account);
        }

        public void Dispose()
        {

        }
    }
}
