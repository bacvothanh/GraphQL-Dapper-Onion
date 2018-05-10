using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Fighting.Core.Abstracts;
using Fighting.Core.Enums;

namespace Fighting.Core.Models
{
    public class Question : BaseAuditEntity
    {
        [MaxLength(1500)]
        public string Ask { get; set; }

        public int? Index { get; set; }
        public QuestionType Type { get; set; }
        public long OwnerId { get; set; }
        public long AssetId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual Account Owner { get; set; }
        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; }

        public virtual ICollection<QuestionDetail> Details { get; set; }
        public virtual ICollection<Arena> Arenas { get; set; }
    }
}
