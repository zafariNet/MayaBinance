using System;

namespace MayaBinance.Domain.SeedWork
{
    public abstract class ModifyAuditedEntity<TKey,TModifier>:
        CreationAuditedEntity<TKey,TModifier>,IModifyAuditedObject<TModifier>
    {
        public TModifier Modifier { get; set; }
        public Guid? ModifierId { get; set; }
    }
}
