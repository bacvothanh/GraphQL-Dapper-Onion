using System;
using Fighting.Core.Interfaces;

namespace Fighting.Core.Abstracts
{
    public abstract class BaseAuditEntity : IEntity<long>, IAuditEntity
    {
        public long Id { get; set; }
        public long CreateBy { get; set; }
        public DateTimeOffset TimeCreatedOffset { get; set; }
        public long? ModifyBy { get; set; }
        public DateTimeOffset? TimeModifyOffset { get; set; }
    }
}
