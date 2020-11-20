using System;

namespace MayaBinance.Domain.SeedWork
{
    public abstract class FullAuditBaseEntity<TKey,TUser>:ModifyAuditedBaseEntity<TKey,TUser>,IFullAuditEntity<TUser>
    {
        public bool SoftDelete { get; set; }
        public TUser Deleter { get; set; }
        public Guid? DeleterId { get; set; }

    }
}
