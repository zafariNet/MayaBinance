﻿namespace MayaBinance.Domain.SeedWork
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity
    {
        TKey Id { get; }
    }
}
