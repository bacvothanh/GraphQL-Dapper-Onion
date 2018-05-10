using System;
using Fighting.Core.Interfaces;

namespace Fighting.Core.Abstracts
{
    public abstract class BaseDeleteEntity: IEntity<long>, IDeleteEntity
    {
        public long Id { get; set; }
        public DateTimeOffset? TimeDeleteOffset { get; set; }
        public long? DeleteBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
