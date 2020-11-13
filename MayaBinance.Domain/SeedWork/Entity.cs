using System;

namespace MayaBinance.Domain.SeedWork
{


    [Serializable]
    public abstract class Entity<TKey> :IEntity<TKey>
    {
        public TKey Id { get; protected set; }
        public byte[] RowVersion { get; set; }
        protected Entity()
        {

        }

        protected Entity(TKey id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Id = {Id}";
        }
    }
}
