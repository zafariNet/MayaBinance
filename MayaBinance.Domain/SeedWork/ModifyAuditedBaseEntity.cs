using System;

namespace MayaBinance.Domain.SeedWork
{
    public abstract class ModifyAuditedBaseEntity<TKey,TModifier>:
        CreationAuditedBaseEntity<TKey,TModifier>,IModifyAuditedObject<TModifier>
    {
        public TModifier Modifier { get; set; }
        public Guid? ModifierId { get; set; }
    }
}
