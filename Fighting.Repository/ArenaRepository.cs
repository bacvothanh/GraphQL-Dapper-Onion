using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Fighting.Core.Models;
using Fighting.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Fighting.Repository
{
    public class ArenaRepository :GenericRepository<Arena>, IArenaRepository
    {
        public ArenaRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }

        public List<Arena> GetByAccountId(long accountId)
        {
            return Connection.GetList<Arena>("where accountId=@accountId", new {accountId}).ToList();
        }
    }
}
