using System;
using Fighting.Core.Interfaces;

namespace Fighting.Core.Abstracts
{
    public abstract class BaseAuditDeleteEntity : IEntity<long>, IAuditEntity, IDeleteEntity
    {
        public long Id { get; set; }
        public long CreateBy { get; set; }
        public DateTimeOffset TimeCreatedOffset { get; set; }
        public long? ModifyBy { get; set; }
        public DateTimeOffset? TimeModifyOffset { get; set; }
        public DateTimeOffset? TimeDeleteOffset { get; set; }
        public long? DeleteBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
