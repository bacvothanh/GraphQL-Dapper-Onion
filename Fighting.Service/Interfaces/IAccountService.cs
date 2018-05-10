using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Fighting.Service.Interfaces
{
    public interface IAccountService : IGenericService<Account>, IUserStore<Account>
    {
    }
}
