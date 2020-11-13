using System;

namespace MayaBinance.Domain.SeedWork
{
    public interface IHasModifyTime:IHasCreationTime
    {
        DateTime ModifyTime { get; }
    }
}
