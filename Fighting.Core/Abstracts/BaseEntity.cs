using Fighting.Core.Interfaces;

namespace Fighting.Core.Abstracts
{
    public abstract class BaseEntity : IEntity<long>
    {
        public long Id { get; set; }
    }
}
