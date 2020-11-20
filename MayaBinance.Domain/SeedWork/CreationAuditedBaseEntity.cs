using System;

namespace MayaBinance.Domain.SeedWork
{
    [Serializable]
    public abstract class CreationAuditedBaseEntity<TType, TCreator> : BaseEntity<TType>, 
        ICreationAuditedObject<TCreator>
    {
        public TCreator Creator { get; set; }
        public Guid? CreatorId { get; set; }
    }
}
