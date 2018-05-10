using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;
using Fighting.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Fighting.Repository
{
    public class AccountRoleRepository : GenericRepository<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }
    }
}
