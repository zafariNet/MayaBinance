using System;
using JetBrains.Annotations;

namespace MayaBinance.Domain.SeedWork
{
    public interface IMayHaveModifier<out TModifier>:IMayHaveCreator<TModifier>
    {

        [CanBeNull]
        TModifier Modifier { get; }

         Guid? ModifierId { get; }
    }


}
