using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;
using Fighting.Repository.Interfaces;
using Fighting.Service.Interfaces;

namespace Fighting.Service
{
    public class ArenaService : GenericService<Arena>, IArenaService
    {
        private readonly IArenaRepository _arenaRepository;
        public ArenaService(IArenaRepository repository) : base(repository)
        {
            _arenaRepository = repository;
        }

        public List<Arena> GetByAccountId(long accountId)
        {
            return  _arenaRepository.GetByAccountId(accountId);
        }
    }
}
