using System;

namespace MayaBinance.Domain.SeedWork
{
    [Serializable]
    public abstract class CreationAuditedEntity<TType, TCreator> : Entity<TType>, 
        ICreationAuditedObject<TCreator>
    {
        public TCreator Creator { get; set; }
        public Guid? CreatorId { get; set; }
    }
}
