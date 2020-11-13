using System;
using JetBrains.Annotations;

namespace MayaBinance.Domain.SeedWork
{
    public interface IMayHaveCreator<out TCreator>
    {

        [CanBeNull]
        TCreator Creator { get; }

        Guid? CreatorId { get; }
    }

}
