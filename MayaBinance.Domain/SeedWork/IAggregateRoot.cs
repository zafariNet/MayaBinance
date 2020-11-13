namespace MayaBinance.Domain.SeedWork
{

    public interface IAggregateRoot<TKey, out TUser> : IFullAuditEntity<TUser>
    {

    }

  
}
