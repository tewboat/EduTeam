using System;

namespace Infrastructure
{
    public interface IEntity
    {
        Guid Guid { get; set; }
    }
}