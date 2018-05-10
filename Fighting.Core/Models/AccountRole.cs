using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Fighting.Core.Abstracts;

namespace Fighting.Core.Models
{
    public class AccountRole : BaseEntity
    {
        public string Name { get; set; }
        public long AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
