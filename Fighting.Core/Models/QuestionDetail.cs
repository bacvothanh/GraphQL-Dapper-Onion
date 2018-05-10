using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Fighting.Core.Abstracts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fighting.Core.Models
{
    public class QuestionDetail : BaseEntity
    {
        [MaxLength(1000)]
        public string Content { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public long QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
