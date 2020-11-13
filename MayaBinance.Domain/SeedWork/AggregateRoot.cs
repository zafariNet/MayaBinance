namespace MayaBinance.Domain.SeedWork
{
    public class AggregateRoot<TKey, TUser> :FullAuditEntity<TKey, TUser>,IAggregateRoot<TKey,TUser>
    {
    }
}
