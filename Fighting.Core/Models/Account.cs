using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Abstracts;
using Fighting.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Fighting.Core.Models
{
    public class Account :  IdentityUser<long>, IEntity<long>, IAuditEntity, IDeleteEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Bithday { get; set; }
        public long CreateBy { get; set; }
        public DateTimeOffset TimeCreatedOffset { get; set; }
        public long? ModifyBy { get; set; }
        public DateTimeOffset? TimeModifyOffset { get; set; }
        public DateTimeOffset? TimeDeleteOffset { get; set; }
        public long? DeleteBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Arena> Arenas { get; set; }
        public virtual ICollection<AccountArena> Fightings { get; set; }
        public virtual AccountRole Role { get; set; }
    }
}
