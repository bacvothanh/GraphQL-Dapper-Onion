using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;

namespace Fighting.Service.Interfaces
{
    public interface IArenaService : IGenericService<Arena>
    {
        List<Arena> GetByAccountId(long accountId);
    }
}
