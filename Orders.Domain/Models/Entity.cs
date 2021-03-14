using System;

namespace Orders.Domain
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
    }

}