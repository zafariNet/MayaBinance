using System;
using System.Collections.Generic;
using MediatR;

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

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> Events => _domainEvents?.AsReadOnly();

        public void AddEvent(INotification notification)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(notification);
        }

        public void RemoveEvent(INotification notification)
        {
            _domainEvents?.Remove(notification);
        }

        public void CLearEvent()
        {
            _domainEvents?.Clear();
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
