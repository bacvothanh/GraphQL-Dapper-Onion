using System;

namespace Fighting.Core.Interfaces
{
    public interface IAuditEntity
    {
        long CreateBy { get; set; }
        DateTimeOffset TimeCreatedOffset { get; set; }
        long? ModifyBy { get; set; }
        DateTimeOffset? TimeModifyOffset { get; set; }
    }
}
