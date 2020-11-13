using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace MayaBinance.Domain.SeedWork
{

    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken =
            default(CancellationToken));

        Task<Result> SaveEntitiesAsync(CancellationToken cancellationToken =
            default(CancellationToken));
    }

}
