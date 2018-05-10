using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;

namespace Fighting.Repository.Interfaces
{
    public interface IArenaRepository : IGenericRepository<Arena>
    {
        List<Arena> GetByAccountId(long accountId);
    }
}
