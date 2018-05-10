using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;
using Fighting.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Fighting.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }
    }
}
