namespace MayaBinance.Domain.SeedWork
{
    public class AggregateRoot<TKey, TUser> :FullAuditBaseEntity<TKey, TUser>,IAggregateRoot<TKey,TUser>
    {
    }
}
