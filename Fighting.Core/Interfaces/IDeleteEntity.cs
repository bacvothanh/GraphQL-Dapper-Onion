using System;

namespace Fighting.Core.Interfaces
{
    public interface IDeleteEntity
    {
        DateTimeOffset? TimeDeleteOffset { get; set; }
        long? DeleteBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
