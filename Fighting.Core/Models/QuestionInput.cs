using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;
using Fighting.Core.Abstracts;

namespace Fighting.Core.Models
{
    public class QuestionInput : BaseAuditEntity
    {
        public long AccountArenaId { get; set; }
        public long QuestionId { get; set; }
        [MaxLength(200)]
        public string Value { get; set; }
        [ForeignKey("AccountArenaId")]
        public virtual AccountArena AccountArena { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
