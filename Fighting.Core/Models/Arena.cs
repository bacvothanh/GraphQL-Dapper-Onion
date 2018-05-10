using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fighting.Core.Abstracts;

namespace Fighting.Core.Models
{
    [Table("Arenas")]
    public class Arena : BaseAuditDeleteEntity
    {
        [MaxLength(1000)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Alias { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public long AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<AccountArena> Fightings { get; set; }
    }
}
