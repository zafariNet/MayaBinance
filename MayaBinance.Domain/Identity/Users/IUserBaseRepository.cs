using System;
using MayaBinance.Domain.SeedWork;

namespace MayaBinance.Domain.Identity.Users
{
    public interface IUserRepository:IBaseRepository<Guid,User>
    {
        IUnitOfWork UnitOfWork { get; }

    }
}
