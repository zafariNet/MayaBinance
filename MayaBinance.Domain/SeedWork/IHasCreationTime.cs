using System;

namespace MayaBinance.Domain.SeedWork
{
    public interface IHasCreationTime
    {
        /// <summary>
        /// Creation time.
        /// </summary>
        DateTime CreationTime { get; }
    }
}
