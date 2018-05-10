using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Fighting.Core.Abstracts;
using Fighting.Core.Enums;

namespace Fighting.Core.Models
{
    public class AccountArena: BaseAuditEntity
    {
        public long AccountId { get; set; }
        public long ArenaId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        [ForeignKey("ArenaId")]
        public virtual Arena Arena { get; set; }

        public int TotalPoint { get; set; }
        public AccountArenaStatus Status { get; set; }
    }
}
