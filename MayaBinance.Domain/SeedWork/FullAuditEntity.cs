using System;

namespace MayaBinance.Domain.SeedWork
{
    public abstract class FullAuditEntity<TKey,TUser>:ModifyAuditedEntity<TKey,TUser>,IFullAuditEntity<TUser>
    {
        public bool SoftDelete { get; set; }
        public TUser Deleter { get; set; }
        public Guid? DeleterId { get; set; }

    }
}
